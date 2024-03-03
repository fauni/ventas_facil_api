using Core.Entities.SocioNegocio;

namespace WebApi.DTOs.SocioNegocio
{
    public class BPDireccionDTO
    {
        public string CodigoCliente { get; set; }
        public string Direccion { get; set; }
    }

    public class MapeoBPDireccion
    {
        public static BPDireccionDTO MapToDTO(BPAddress data)
        {
            return new BPDireccionDTO
            {
                CodigoCliente = data.BpCode,
                Direccion = data.AddressName,
            };
        }
    }
}
