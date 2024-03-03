using Core.Entities.Producto;

namespace WebApi.DTOs.Items
{
    public class PrecioItemDTO
    {
        public int? Numero { get; set; }
        public double? Precio { get; set; }
        public string Moneda { get; set; }
    }

    public class MapeoPrecioItem
    {
        public static PrecioItemDTO MapToDTO(ItemPrice data) {
            return new PrecioItemDTO {
                Numero = data.PriceList,
                Precio = data.Price,
                Moneda = data.Currency
            };
        }
    }
}