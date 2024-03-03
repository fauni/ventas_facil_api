using Core.Entities.Producto;
using Core.Entities.SocioNegocio;
using WebApi.DTOs.Items;

namespace WebApi.DTOs
{
    public class ItemDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string NombreExtranjero { get; set; }
        public string ClaseArticulo { get; set; }
        public ItemGrupoDTO GrupoItem { get; set; }
        public string EsArticuloDeInventario { get; set;}
        public string EsArticuloDeVenta { get; set; }
        public string EsGestionadoNumeroLote { get; set; }
        public string UnidadMedidaVenta { get; set; }
        public string UnidadMedidaInventario { get; set; }
        public List<PrecioItemDTO> ListaPrecios { get; set; }
    }

    public class MapeoItem
    {
        public static ItemDTO MapToDTO(Item item, ItemGrupoDTO grupo)
        {
            List<PrecioItemDTO> precios = new List<PrecioItemDTO>();
            foreach (var precio in item.ItemPrices)
            {
                precios.Add(MapeoPrecioItem.MapToDTO(precio));
            }
            return new ItemDTO()
            {
                Codigo = item.ItemCode,
                Descripcion = item.ItemName,
                NombreExtranjero = item.ForeignName,
                ClaseArticulo = item.ItemType,
                GrupoItem = grupo,
                EsArticuloDeInventario = item.InventoryItem,
                EsArticuloDeVenta = item.SalesItem,
                EsGestionadoNumeroLote = item.ManageBatchNumbers,
                UnidadMedidaVenta = item.SalesUnit,
                UnidadMedidaInventario = item.InventoryUom,
                ListaPrecios = precios
            };
        }
    }
    /*
    public class ItemDTO
    {
        public int Id { get; set; }
        public string CodigoSap { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double? PrecioUnitario { get; set; }
        public double? Stock { get; set; }
        public double? Peso { get; set; }
        public string Imagen { get; set; }
        public DateTimeOffset? FechaRegistro { get; set; }
        // public int Estado { get; set; }
        public string UnidadMedida { get; set; }
        // public int IdPorcentajeDescuento { get; set; }
        // public int IdUnidadNegocio { get; set; }
        // public bool Bonificacion { get; set; }
        // public bool Descuento { get; set; }
        // public string Lote { get; set; }
        // public int TipoVenta { get; set; }
        // public int TipoConsignacion { get; set; }
        // public int TipoDevolucion { get; set; }
        // public int TipoReposicion { get; set; }
    }*/
    
    /*

    public class MapeoItem
    {
        public static ItemDTO MapToDTO(Item item)
        {
            return new ItemDTO()
            {
                Id = 0,
                CodigoSap = item.ItemCode,
                Nombre = item.ItemName,
                Descripcion = item.ItemName,
                PrecioUnitario = item.PricingUnit,
                Stock = item.QuantityOnStock,
                Peso = item.SalesUnitVolume,
                Imagen = item.Picture,
                FechaRegistro = item.CreateDate,
                // Estado = item.,
                UnidadMedida = item.SalesUnit,
                // IdPorcentajeDescuento = item.,
                // IdUnidadNegocio = item.,
                // Bonificacion = item.,
                // Descuento = item.,
                // Lote = null,
                // TipoVenta = item.,
                // TipoConsignacion = item.,
                // TipoDevolucion = item.,
                // TipoReposicion = item.,
            };
        }
    }
    */
}
