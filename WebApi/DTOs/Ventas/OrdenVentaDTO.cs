using Core.Entities.Producto;
using Core.Entities.Ventas;
using System.Reflection.Metadata.Ecma335;
using WebApi.DTOs.SocioNegocio;

namespace WebApi.DTOs.Ventas
{
    public class OrdenVentaDTO
    {
        public int? Id { get; set; }
        public int? CodigoSap { get; set; }
        public string NombreFactura { get; set; }
        public string NitFactura { get; set; }
        public double? DiasPlazo { get; set; }
        public DateTimeOffset? FechaEntrega { get; set; }
        public double? Total { get; set; }
        public double? TipoCambio { get; set; }
        public double? Descuento { get; set; }
        public string Observacion { get; set; }
        public DateTimeOffset? FechaRegistro { get; set; }
        public string Estado { get; set; }
        public string EstadoCancelado { get; set; }
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public BusinessPartnersDTO Cliente { get; set; }
        public double? IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public SalesPersonsDTO Empleado { get; set; }
        public string Moneda { get; set; }
        public int? PersonaContacto { get; set; }
        public int? IdCondicionDePago { get; set; }
        public EmpleadoContactoDTO Contacto { get; set; }
        public List<LinesPedidoDTO> LinesPedido { get; set; }
        public string UsuarioVentaFacil { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTimeOffset? FechaRegistroApp { get; set; }
        public DateTimeOffset? HoraRegistroApp { get; set; }
    }

    public class MapeoGuardarOrdenVenta
    {
        public static OrdenVentaDTO MapToDTO(Order order)
        {
            List<LinesPedidoDTO> lines = new List<LinesPedidoDTO>();
            foreach (var item in order.DocumentLines)
            {
                lines.Add(MapeoLinesOrdenVenta.MapToDTO(item));
            }
            // TODO: Completar este codigo
            return new OrdenVentaDTO()
            {
                Id = order.DocEntry,
                CodigoSap = order.DocEntry,
                NombreFactura = order.Indicator,
                NitFactura = order.FederalTaxId,
                DiasPlazo = 0,
                FechaEntrega = order.DocDueDate,
                Total = order.DocTotal,
                TipoCambio = 0,
                Descuento = order.TotalDiscount,
                Observacion = order.Comments,
                FechaRegistro = order.DocDate,
                Estado = order.DocumentStatus,
                EstadoCancelado = order.CancelStatus,
                IdCliente = order.CardCode,
                NombreCliente = order.CardName,
                Cliente = new BusinessPartnersDTO(),
                IdEmpleado = order.SalesPersonCode,
                NombreEmpleado = "",
                Empleado = new SalesPersonsDTO(),
                Moneda = order.DocCurrency,
                PersonaContacto = order.ContactPersonCode,
                Contacto = new EmpleadoContactoDTO(),
                LinesPedido = lines,
                UsuarioVentaFacil = order.U_usrventafacil,
                Latitud = order.U_latitud,
                Longitud = order.U_longitud,
                FechaRegistroApp = order.U_fecharegistroapp,
                HoraRegistroApp = order.U_horaregistroapp
            };
        }

        public static OrderGuardar DTOToMap(OrdenVentaDTO dto)
        {
            List<DocumentLineGuardarOrder> lines = new List<DocumentLineGuardarOrder>();
            foreach (var item in dto.LinesPedido)
            {
                lines.Add(MapeoLinesOrdenVenta.DTOToMap(item));
            }
            return new OrderGuardar()
            {
                DocEntry = dto.CodigoSap,
                CardCode = dto.Cliente.CodigoSN,
                DocDueDate = dto.FechaEntrega,
                DocDate = dto.FechaRegistro,
                SalesPersonCode = dto.Empleado.CodigoEmpleado,
                ContactPersonCode = dto.PersonaContacto,
                PaymentGroupCode = dto.IdCondicionDePago,
                Comments = dto.Observacion,
                DocumentLines = lines,
                U_usrventafacil= dto.UsuarioVentaFacil,
                U_latitud = dto.Latitud,
                U_longitud = dto.Longitud,
                U_fecharegistroapp = dto.FechaRegistroApp,
                U_horaregistroapp = dto.HoraRegistroApp
            };
        }
    }

    public class LinesPedidoDTO
    {
        public int? NumeroDeLinea { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAdicional { get; set; }
        public double? Cantidad { get; set; }
        public double? PrecioPorUnidad { get; set; }
        public double? Descuento { get; set; }
        public string IndicadorDeImpuestos { get; set; }
        public int? CodigoUnidadMedida { get; set; }
        public DateTimeOffset? FechaDeEntrega { get; set; }
    }

    public class MapeoLinesOrdenVenta
    {
        public static LinesPedidoDTO MapToDTO(DocumentLineOrder data)
        {
            return new LinesPedidoDTO()
            {
                NumeroDeLinea = data.LineNum,
                Codigo = data.ItemCode,
                Descripcion = data.ItemDescription,
                DescripcionAdicional = data.U_descitemfacil,
                Cantidad = data.Quantity,
                PrecioPorUnidad = data.U_PrecioItemVenta,
                Descuento = data.DiscountPercent,
                IndicadorDeImpuestos = "IVA",
                CodigoUnidadMedida = data.UoMEntry,
                FechaDeEntrega = data.ShipDate
            };
        }
        public static DocumentLineGuardarOrder DTOToMap(LinesPedidoDTO dto)
        {
            DocumentLineGuardarOrder line = new DocumentLineGuardarOrder();
            line.ItemCode = dto.Codigo;
            line.U_descitemfacil = dto.DescripcionAdicional;
            line.Quantity = dto.Cantidad;
            line.TaxCode = "IVA";
            line.UnitPrice = dto.PrecioPorUnidad - (13 * dto.PrecioPorUnidad / 100);
            line.PriceAfterVAT = dto.PrecioPorUnidad - (dto.Descuento / 100 * dto.PrecioPorUnidad);
            line.U_PrecioVenta = dto.PrecioPorUnidad;
            line.U_PrecioItemVenta = dto.PrecioPorUnidad;
            line.DiscountPercent = dto.Descuento;
            line.UoMEntry = dto.CodigoUnidadMedida;
            line.ShipDate = dto.FechaDeEntrega;
            return line;
        }
    }
}
