using Core.Entities.Errors;
using Core.Entities.SocioNegocio;
using Core.Entities.Ventas;
using Core.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;

        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MemoryStream GenerarPDF(Order order)
        {
            var stream = new MemoryStream();
            using (var writer = new PdfWriter(stream))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    using (var document = new iText.Layout.Document(pdf))
                    {
                        // Agregar metadatos al documento (opcional)
                        pdf.GetDocumentInfo().SetTitle("Documento de Venta");

                        #region CABECERA

                        // Crear una tabla con dos columnas
                        Table tableHeader = new Table(new float[] { 1, 2 })
                            .UseAllAvailableWidth();

                        // Definir el borde común
                        Border commonBorder = new SolidBorder(1);

                        // Añadir la celda de "Código de Cliente" que abarca dos filas
                        Cell codigoClienteCell = new Cell(1, 2)
                            .Add(new Paragraph($"Para : {order.CardName}"))
                            .SetBorder(Border.NO_BORDER);
                        Cell fechaDelDocumentoCell = new Cell(1, 2)
                            .Add(new Paragraph($"Fecha del Documento: {order.DocDate}"))
                            .SetBorder(Border.NO_BORDER);
                        // Añadir la celda "Código de Cliente" al inicio de la tabla
                        tableHeader.AddCell(codigoClienteCell);
                        tableHeader.AddCell(fechaDelDocumentoCell);


                        // Añadir la tabla al documento
                        document.Add(tableHeader);

                        #endregion

                        Paragraph title = new Paragraph($"Pedido de Cliente Nro. {order.DocEntry}")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20)
                            .SetBold();

                        document.Add(title);


                        Table table = new Table(UnitValue.CreatePercentArray(new float[] {1,3,1,1,1,1})).UseAllAvailableWidth();
                        table.SetBorder(Border.NO_BORDER);

                        // Añadir celdas de encabezado
                        table.AddHeaderCell("Número");
                        table.AddHeaderCell("Descripción");
                        table.AddHeaderCell("Unidad de medida");
                        table.AddHeaderCell("Cantidad");
                        table.AddHeaderCell("Precio");
                        table.AddHeaderCell("Total");

                        int count = 0;
                        foreach (var item in order.DocumentLines)
                        {
                            count ++;  
                            // Añadir una fila de ejemplo, como en la imagen proporcionada
                            table.AddCell(count.ToString());
                            table.AddCell($"{item.ItemCode} - {item.ItemDescription}");
                            table.AddCell($"{item.MeasureUnit}");
                            table.AddCell($"{item.Quantity}");
                            table.AddCell($"{item.Currency} {item.U_PrecioItemVenta}");
                            table.AddCell($"{item.Currency} {item.LineTotal}");

                        }

                        // Añadir la tabla al documento
                        document.Add(table);

                        // Crear un párrafo para la fecha de entrega
                        Paragraph fechaEntrega = new Paragraph($"Fecha de entrega {order.DocDueDate}").SetBold();

                        // Crear una tabla para la información del empleado y condiciones de pago
                        Table employeeTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 1 })).UseAllAvailableWidth().SetBorder(Border.NO_BORDER);

                        employeeTable.AddCell(new Cell().Add(new Paragraph("Empleado del departamento de ventas:").SetBold()).SetBorder(Border.NO_BORDER));
                        employeeTable.AddCell(new Cell().Add(new Paragraph($"{order.SalesPersonCode}")).SetBorder(Border.NO_BORDER));
                        // employeeTable.AddCell(new Cell().Add(new Paragraph("Condiciones de pago:").SetBold()).SetBorder(Border.NO_BORDER));
                        // employeeTable.AddCell(new Cell().Add(new Paragraph("30 días Precio Contado")).SetBorder(Border.NO_BORDER));
                        employeeTable.AddCell(new Cell(1, 2).Add(new Paragraph($"Comentario:").SetBold()).SetBorder(Border.NO_BORDER));
                        employeeTable.AddCell(new Cell(1, 2).Add(new Paragraph($"{order.Comments}").SetItalic()).SetBorder(Border.NO_BORDER));

                        // Asegurarse de que no hay bordes
                        employeeTable.SetBorder(Border.NO_BORDER);

                        // Crear una tabla para el resumen de impuestos y totales
                        Table totalsTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 1 }))
                            .UseAllAvailableWidth().SetBorder(Border.NO_BORDER);

                        // Agregar celdas al resumen
                        totalsTable.AddCell(new Cell().Add(new Paragraph("Descuento").SetBold().SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER)).SetBorder(Border.NO_BORDER));
                        totalsTable.AddCell(new Cell().Add(new Paragraph($"{order.DocCurrency} {order.TotalDiscount}").SetTextAlignment(TextAlignment.RIGHT)).SetBorder(Border.NO_BORDER));
                        totalsTable.AddCell(new Cell().Add(new Paragraph("Total").SetBold().SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER)).SetBorder(Border.NO_BORDER));
                        totalsTable.AddCell(new Cell().Add(new Paragraph($"{order.DocCurrency} {order.DocTotal}").SetTextAlignment(TextAlignment.RIGHT)).SetBorder(Border.NO_BORDER));

                        // Alinear la tabla de totales a la derecha
                        totalsTable.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

                        // Agregar todos los elementos al documento
                        document.Add(fechaEntrega);
                        document.Add(employeeTable);
                        document.Add(totalsTable);

                        // Cerrar el documento
                        document.Close();
                    }
                }
            }
            // stream.Position = 0; // Reset the stream position for reading
            return stream;
        }

        #region CRUD ORDEN DE COMPRA
        public async Task<(List<Order> Result, CodeErrorException Error)> GetAll(string sessionID, int top, int skip)
        {
            string url = _configuration["UrlSap"] + $"/Orders?$orderby=DocEntry desc&$top={top}&$skip={skip}";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
                        return (result.value, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (null, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (null, codeError);
            }
        }

        public async Task<(Order Result, CodeErrorException Error)> GetById(string sessionID, int id)
        {
            string url = _configuration["UrlSap"] + $"/Orders({id})";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Order>(responseBody);
                        return (result, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (null, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (null, codeError);
            }
        }

        public async Task<(List<Order> Result, CodeErrorException Error)> GetForText(string sessionID, string search)
        {
            string url = _configuration["UrlSap"] + @$"/Orders?$filter=contains(DocNum, '{search}') or contains(DocEntry, '{search}') 
                or contains(CardCode, '{search}') or contains(CardName, '{search}')&$orderby=DocEntry desc";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
                        return (result.value, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (null, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (null, codeError);
            }
        }

        public async Task<(Order Result, CodeErrorException Error)> SaveOrder(string sessionID, OrderGuardar order)
        {
            string url = _configuration["UrlSap"] + "/Orders";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));

                    var json = JsonConvert.SerializeObject(order);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Order>(responseBody);
                        return (result, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (null, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (null, codeError);
            }
        }

        public async Task<(bool Result, CodeErrorException Error)> UpdateOrder(string sessionID, int idOrder, OrderModificar order)
        {
            string url = _configuration["UrlSap"] + $"/Orders({idOrder})";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));

                    var json = JsonConvert.SerializeObject(order);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PatchAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (false, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (false, codeError);
            }
        }

        public async Task<(bool Result, CodeErrorException Error)> UpdateStatusLineOrder(string sessionID, int idOrder, OrderModificarLinea order)
        {
            string url = _configuration["UrlSap"] + $"/Orders({idOrder})";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));

                    var json = JsonConvert.SerializeObject(order);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PatchAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (false, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (false, codeError);
            }
        }
        #endregion

    }
}
