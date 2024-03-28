using Core.Entities.Producto;

namespace WebApi.DTOs.Items
{
    public class ItemAlmacenDTO
    {
        public string CodigoItem { get; set; }
        public string CodigoAlmacen { get; set; }
        public double? EnStock { get; set; }
    }

    public class MapeoItemAlmacen
    {
        public static ItemAlmacenDTO MapToDTO(ItemWarehouseInfoCollection data)
        {
            return new ItemAlmacenDTO
            {
                CodigoItem = data.ItemCode,
                CodigoAlmacen = data.WarehouseCode,
                EnStock = data.InStock
            };
        }
    }
}
