using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.SocioNegocio
{
    public class ResponsePaymentTermsTypes
    {
        public List<PaymentTermsTypes> value { get; set; }
    }
    public class PaymentTermsTypes
    {
        public int GroupNumber { get; set; }
        public string PaymentTermsGroupName { get; set; }
        public int PriceListNo { get; set; }
    }
}
