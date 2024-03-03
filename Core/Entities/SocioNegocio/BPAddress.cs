using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.SocioNegocio
{
    public class BPAddress
    {
        public string AddressName { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string FederalTaxId { get; set; }
        public string TaxCode { get; set; }
        public string BuildingFloorRoom { get; set; }
        public string AddressType { get; set; }
        public string AddressName2 { get; set; }
        public string AddressName3 { get; set; }
        public string TypeOfAddress { get; set; }
        public string StreetNo { get; set; }
        public string BpCode { get; set; }
        public long? RowNum { get; set; }
        public string GlobalLocationNumber { get; set; }
        public string Nationality { get; set; }
        public string TaxOffice { get; set; }
        public string Gstin { get; set; }
        public string GstType { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? CreateTime { get; set; }
        public string MyfType { get; set; }
        public string TaasEnabled { get; set; }
    }
}
