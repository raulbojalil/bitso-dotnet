using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BitsoDotNet.Entities
{
    public class Funding
    {
        [JsonProperty("fid")]
        public string Fid { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("details")]
        public JObject Details { get; set; }

        public decimal AmountAsDecimal { get { return Convert.ToDecimal(Amount); } }

    }
}
