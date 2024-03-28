using Core.Entities.Producto;
using Core.Entities.Ventas;

namespace WebApi.DTOs.Ventas
{
    public class OrdenVentaUpdateDTO
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
        public int? IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public SalesPersonsDTO Empleado { get; set; }
        public string Moneda { get; set; }
        public int? PersonaContacto { get; set; }
        public List<LinesPedidoActualizarDTO> LinesPedido { get; set; }
        public string Ubicacion { get; set; }
    }

    public class MapeoModificarOrdenVenta
    {
        public static OrdenVentaUpdateDTO MapToDTO(Order order)
        {
            // TODO: Completar este codigo
            return new OrdenVentaUpdateDTO()
            {

            };
        }

        public static OrderModificar DTOToMap(OrdenVentaUpdateDTO dto)
        {
            List<DocumentLineModificarOrder> lines = new List<DocumentLineModificarOrder>();
            foreach (var item in dto.LinesPedido)
            {
                lines.Add(MapeoLinesActualizarOrdenVenta.DTOToMap(item));
            }
            return new OrderModificar()
            {
                DocEntry = dto.CodigoSap,
                //CardCode = dto.Cliente.CodigoSN,
                DocDueDate = dto.FechaEntrega,
                DocDate = dto.FechaRegistro,
                SalesPersonCode = dto.IdEmpleado,
                ContactPersonCode = dto.PersonaContacto,
                Comments = dto.Observacion,
                DocumentLines = lines,
                //PickRemark = dto.Ubicacion
            };
        }
    }

    public class LinesPedidoActualizarDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAdicional { get; set; }
        public double? Cantidad { get; set; }
        public double? PrecioPorUnidad { get; set; }
        public double? Descuento { get; set; }
        public string IndicadorDeImpuestos { get; set; }
    }

    public class MapeoLinesActualizarOrdenVenta
    {
        public static DocumentLineModificarOrder DTOToMap(LinesPedidoActualizarDTO dto)
        {
            DocumentLineModificarOrder line = new DocumentLineModificarOrder();
            line.ItemCode = dto.Codigo;
            line.U_descitemfacil = dto.DescripcionAdicional;
            line.Quantity = dto.Cantidad;
            line.TaxCode = "IVA";
            line.UnitPrice = dto.PrecioPorUnidad - (13 * dto.PrecioPorUnidad / 100);
            line.PriceAfterVAT = dto.PrecioPorUnidad - (dto.Descuento / 100 * dto.PrecioPorUnidad);
            line.U_PrecioVenta = dto.PrecioPorUnidad;
            line.DiscountPercent = dto.Descuento;
            line.Volume = dto.PrecioPorUnidad;
            return line;
        }
    }
}
