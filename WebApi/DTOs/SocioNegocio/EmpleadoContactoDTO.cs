using Core.Entities.SocioNegocio;

namespace WebApi.DTOs.SocioNegocio
{
    public class EmpleadoContactoDTO
    {
        public int NumeroInterno { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
    }

    public class MapeoEmpleadoContacto
    {
        public static EmpleadoContactoDTO MapToDTO(ContactEmployee data)
        {
            return new EmpleadoContactoDTO
            {
                NumeroInterno= (int)data.InternalCode,
                CodigoCliente = data.CardCode,
                NombreCliente = data.Name,
                NombreContacto = data.FirstName,
                ApellidoContacto = data.LastName, 
            };
        }
    }
}
