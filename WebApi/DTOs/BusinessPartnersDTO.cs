using Core.Entities.SocioNegocio;
using WebApi.DTOs.SocioNegocio;

namespace WebApi.DTOs
{
    public class BusinessPartnersDTO
    {
        public string Id { get; set; }
        public string CodigoSN { get; set; }
        public string NombreSN { get; set; }
        public string CardFName { get; set; }
        public string ClaseSN { get; set; }
        public int CodigoGrupo { get; set; }
        public string MonedaSN { get; set; }
        public string NIT { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string PersonaContacto { get; set; }
        public List<EmpleadoContactoDTO> ContactosEmpleado { get; set; }
        public int? CodigoEmpleadoVentas { get; set; }
        public string Direccion { get; set; }
        public int? CodigoCondicionPago { get; set; }
        public int? NumeroListaPrecio { get; set; }
    }

    public class MapeoBusinessPartner
    {
        public static BusinessPartnersDTO MapToDTO(BusinessPartners bpartner)
        {
            List<EmpleadoContactoDTO> lista = new List<EmpleadoContactoDTO>();
            foreach (var item in bpartner.ContactEmployees)
            {
                lista.Add(MapeoEmpleadoContacto.MapToDTO(item));
            }

            return new BusinessPartnersDTO()
            {
                Id = bpartner.CardCode,
                CodigoSN = bpartner.CardCode,
                NombreSN = bpartner.CardName,
                CardFName = bpartner.CardCode,
                ClaseSN = bpartner.CardType,
                CodigoGrupo = bpartner.GroupCode,
                MonedaSN = bpartner.Currency,
                NIT = bpartner.FederalTaxId,
                Telefono1 = bpartner.Phone1,
                Telefono2 = bpartner.Phone2,
                TelefonoMovil = bpartner.Cellular,
                CorreoElectronico = bpartner.EmailAddress,
                PersonaContacto = bpartner.ContactPerson,
                ContactosEmpleado = lista,
                CodigoEmpleadoVentas = bpartner.SalesPersonCode,
                Direccion = bpartner.BilltoDefault,
                CodigoCondicionPago = bpartner.PayTermsGrpCode,
                NumeroListaPrecio = bpartner.PriceListNum,
            };
        }
    }
}
