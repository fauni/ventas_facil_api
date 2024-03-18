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
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public BusinessPartnersDTO Cliente { get; set; }
        public double? IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public SalesPersonsDTO Empleado { get; set; }
        public string Moneda { get; set; }
        public int? PersonaContacto { get; set; }
        public List<LinesPedidoDTO> LinesPedido { get; set; }
        public string Ubicacion { get; set; }
    }

    public class MapeoGuardarOrdenVenta
    {
        public static OrdenVentaDTO MapToDTO(Order order)
        {
            // TODO: Completar este codigo
            return new OrdenVentaDTO()
            {
                
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
                Comments = dto.Observacion,
                DocumentLines = lines,
                PickRemark = dto.Ubicacion
            };
        }
    }

    public class LinesPedidoDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double? Cantidad { get; set; }
        public double? Precio { get; set; }
        public string IndicadorDeImpuestos { get; set; }
    }

    public class MapeoLinesOrdenVenta
    {
        public static DocumentLineGuardarOrder DTOToMap(LinesPedidoDTO dto)
        {
            return new DocumentLineGuardarOrder()
            {
                ItemCode = dto.Codigo,
                Quantity = dto.Cantidad,
                TaxCode = "IVA",
                UnitPrice = dto.Precio
            };
        }
    }
}
