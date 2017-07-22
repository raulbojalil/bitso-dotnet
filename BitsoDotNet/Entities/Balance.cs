using Newtonsoft.Json;
using System;

namespace BitsoDotNet.Entities
{
    public class Balance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("locked")]
        public string Locked { get; set; }

        [JsonProperty("available")]
        public string Available { get; set; }

        public decimal TotalAsDecimal { get { return Convert.ToDecimal(Total); } }
        public decimal LockedAsDecimal { get { return Convert.ToDecimal(Locked); } }
        public decimal AvailableAsDecimal { get { return Convert.ToDecimal(Available); } }

    }
}
