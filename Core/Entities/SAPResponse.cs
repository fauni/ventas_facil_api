using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SAPResponse<TValue>
    {
        [JsonPropertyName("@odata.context")]
        public Uri? OdataContext { get; set; }

        [JsonPropertyName("value")]
        public TValue? Value { get; set; }

        [JsonPropertyName("@odata.nextLink")]
        public string? OdataNextLink { get; set; }
    }
}
