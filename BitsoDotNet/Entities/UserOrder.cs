using Newtonsoft.Json;
using System;

namespace BitsoDotNet.Entities
{
    public class UserOrder
    {
        [JsonProperty("original_value")]
        public string OriginalValue { get; set; }

        [JsonProperty("unfilled_amount")]
        public string UnfilledAmount { get; set; }

        [JsonProperty("original_amount")]
        public string OriginalAmount { get; set; }

        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("created_at")] //"2017-07-20T22:17:02-05:00"
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }


        public decimal OriginalValueAsDecimal { get { return Convert.ToDecimal(OriginalValue); } }
        public decimal PriceAsDecimal { get { return Convert.ToDecimal(Price); } }

    }
}
