using Core.Entities.Ventas;

namespace WebApi.DTOs.Ventas
{
    public class SalesPersonsDTO
    {
        public int? CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Observaciones { get; set; }
        public string Email { get; set; }
    }

    public class MapeoSalesPerson
    {
        public static SalesPersonsDTO MapToDTO(SalesPersons data)
        {
            return new SalesPersonsDTO()
            {
                CodigoEmpleado = data.SalesEmployeeCode,
                NombreEmpleado = data.SalesEmployeeName,
                Observaciones = data.Remarks,
                Email = data.Email
            };
        }
    }
}
