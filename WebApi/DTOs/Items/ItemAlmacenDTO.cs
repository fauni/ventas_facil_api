using Core.Entities.Producto;

namespace WebApi.DTOs.Items
{
    public class ItemAlmacenDTO
    {
        public string CodigoItem { get; set; }
        public string CodigoAlmacen { get; set; }
        public double? EnStock { get; set; }
        public double? Comprometida { get; set; }
        public double? Solicitada { get; set; }
        
        public double? Disponible {
            get
            {
                double enStock = EnStock ?? 0;
                double comprometida = Comprometida ?? 0;
                double solicitada = Solicitada ?? 0;
                double disponible = enStock - comprometida + solicitada;
                return disponible;
            }
        }
    }

    public class MapeoItemAlmacen
    {
        public static ItemAlmacenDTO MapToDTO(ItemWarehouseInfoCollection data)
        {
            return new ItemAlmacenDTO
            {
                CodigoItem = data.ItemCode,
                CodigoAlmacen = data.WarehouseCode,
                EnStock = data.InStock,
                Comprometida = data.Committed,
                Solicitada = data.Ordered,
            };
        }
    }
}
