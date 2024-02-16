using Core.Entities.SocioNegocio;

namespace WebApi.DTOs
{
    public class BusinessPartnersDTO
    {
        public string Id { get; set; }
        public string CodigoSap { get; set; }
        public double? Ci { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class MapeoBusinessPartner
    {
        public static BusinessPartnersDTO MapToDTO(BusinessPartners bpartner)
        {
            return new BusinessPartnersDTO()
            {
                Id = bpartner.CardCode,
                CodigoSap = bpartner.CardCode,
                Ci = bpartner.FederalTaxId,
                Nombre= bpartner.CardCode,
                Nit = bpartner.FederalTaxId.ToString(),
                RazonSocial = bpartner.CardName,
                Direccion = bpartner.Address,
                Telefono = bpartner.Phone1,
                Email = bpartner.EmailAddress
            };
        }
    }
}
