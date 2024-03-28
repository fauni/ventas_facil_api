using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.SocioNegocio
{
    public class ContactEmployee
    {
        public string CardCode { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string Pager { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Password { get; set; }
        public int? InternalCode { get; set; }
        public long? PlaceOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string Title { get; set; }
        public string CityOfBirth { get; set; }
        public string Active { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailGroupCode { get; set; }
        public string BlockSendingMarketingContent { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? CreateTime { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public DateTimeOffset? UpdateTime { get; set; }
        public string ConnectedAddressName { get; set; }
        public string ConnectedAddressType { get; set; }
        public string ForeignCountry { get; set; }
        public List<string> ContactEmployeeBlockSendingMarketingContents { get; set; }
    }
}
