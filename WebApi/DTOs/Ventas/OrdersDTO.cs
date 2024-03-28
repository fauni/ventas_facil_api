using Core.Entities.Ventas;
using System.Reflection.Metadata.Ecma335;
using WebApi.DTOs.SocioNegocio;

namespace WebApi.DTOs.Ventas
{
    public class OrdersDTO
    {
        public int? Id { get; set; }
        public int? CodigoSap { get; set; }
        public long? NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTimeOffset? FechaDeEntrega{ get; set; }
        public DateTimeOffset? FechaDelDocumento { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public BusinessPartnersDTO Cliente { get; set; }
        public int? CodigoPersonaDeContacto { get; set; }
        public EmpleadoContactoDTO Contacto { get; set; }
        public string Moneda { get; set; }
        public string Comentarios { get; set; }
        public int? CodigoEmpleadoDeVentas { get; set; }
        public SalesPersonsDTO Empleado { get; set; }
        public string NombreFactura { get; set; }
        public string NitFactura { get; set; }
        public string Estado { get; set; }
        public string EstadoCancelado { get; set; }
        public double? Descuento { get; set; }
        public double? Impuesto { get; set; }
        public double? Total { get; set; }
        public List<LinesOrdersDTO> LinesOrder { get; set; }
        public string UsuarioVentaFacil { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTimeOffset? FechaRegistroApp { get; set; }
        public DateTimeOffset? HoraRegistroApp { get; set; }

        public double? TotalAntesDelDescuento()
        {
            return Total - Impuesto;
        }
    }

    public class LinesOrdersDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAdicional { get; set; }
        public double? Cantidad { get; set; }
        public double? PrecioUnitario { get; set; }
        public double? PrecioDespuesImpuestos { get; set; }
        public string Moneda { get; set; }
        public double? Descuento { get; set; }
        public double? TotalLinea { get; set; }
        public string CodigoDeAlmacen { get; set; }
        public string UnidadDeMedida { get; set; }
        public string EstadoLinea { get; set; }
    }
    public class MapeoOrderDTO
    {
        public static OrdersDTO MapToDTO(Order data) {
            List<LinesOrdersDTO> lines = new List<LinesOrdersDTO>();
            foreach (var item in data.DocumentLines)
            {
                lines.Add(MapeoLinesOrder.MapToDTO(item));
            }
            return new OrdersDTO() {
                Id = data.DocEntry,
                CodigoSap = data.DocEntry,
                NumeroDocumento = data.DocNum,
                TipoDocumento = data.DocType,
                FechaDeEntrega = data.DocDueDate,
                FechaDelDocumento = data.DocDate,
                CodigoCliente = data.CardCode,
                NombreCliente = data.CardName,
                Cliente = new BusinessPartnersDTO(),
                CodigoPersonaDeContacto = data.ContactPersonCode,
                Contacto = new EmpleadoContactoDTO(),
                Moneda = data.DocCurrency,
                Comentarios = data.Comments,
                CodigoEmpleadoDeVentas = data.SalesPersonCode,
                Empleado = new SalesPersonsDTO(),
                NombreFactura = data.Indicator,
                NitFactura = data.FederalTaxId,
                Estado = data.DocumentStatus,
                EstadoCancelado = data.CancelStatus,
                Descuento = data.TotalDiscount,
                Impuesto = data.VatSum,
                Total = data.DocTotal,
                LinesOrder = lines,
                UsuarioVentaFacil = data.U_usrventafacil,
                Latitud = data.U_latitud,
                Longitud = data.U_longitud,
                FechaRegistroApp = data.U_fecharegistroapp,
                HoraRegistroApp = data.U_horaregistroapp
            }; 
        }
        
    }

    public class MapeoLinesOrder
    {
        public static LinesOrdersDTO MapToDTO(DocumentLineOrder data)
        {
            return new LinesOrdersDTO()
            {
                Codigo = data.ItemCode,
                Descripcion = data.ItemDescription,
                DescripcionAdicional = data.U_descitemfacil,
                Cantidad = data.Quantity,
                PrecioUnitario = data.PriceAfterVat,
                PrecioDespuesImpuestos = data.PriceAfterVat,
                Moneda = data.Currency,
                Descuento = data.DiscountPercent,
                TotalLinea = data.LineTotal,
                CodigoDeAlmacen = data.WarehouseCode,
                UnidadDeMedida = data.MeasureUnit,
                EstadoLinea = data.LineStatus
            };
        }
    }
}
