using Core.Entities.SocioNegocio;

namespace WebApi.DTOs.SocioNegocio
{
    public class CondicionPagoDTO
    {
        public int NumeroGrupo { get; set; }
        public string NombreCondicionPago { get; set; }
        public int IdListaPrecio { get; set; }
    }

    public class MapeoPaymentTermsTypes
    {
        public static CondicionPagoDTO MapToDTO(PaymentTermsTypes data)
        {
            return new CondicionPagoDTO
            {
                NumeroGrupo = data.GroupNumber,
                NombreCondicionPago = data.PaymentTermsGroupName,
                IdListaPrecio = data.PriceListNo
            };
        }
    }
}
