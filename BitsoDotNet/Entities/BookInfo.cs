using Newtonsoft.Json;
using System;

namespace BitsoDotNet.Entities
{
    public class BookInfo
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("minimum_amount")]
        public string MinimumAmount { get; set; }

        [JsonProperty("maximum_amount")]
        public string MaximumAmount { get; set; }

        [JsonProperty("minimum_price")]
        public string MinimumPrice { get; set; }

        [JsonProperty("maximum_price")] 
        public string MaximumPrice { get; set; }

        [JsonProperty("minimum_value")]
        public string MinimumValue { get; set; }

        [JsonProperty("maximum_value")]
        public string MaximumValue { get; set; }

        public decimal MinimumAmountAsDecimal { get { return Convert.ToDecimal(MinimumAmount); } }
        public decimal MaximumAmountAsDecimal { get { return Convert.ToDecimal(MaximumAmount); } }
        public decimal MinimumPriceAsDecimal { get { return Convert.ToDecimal(MinimumPrice); } }
        public decimal MaximumPriceAsDecimal { get { return Convert.ToDecimal(MaximumPrice); } }
        public decimal MinimumValueAsDecimal { get { return Convert.ToDecimal(MinimumValue); } }
        public decimal MaximumValueAsDecimal { get { return Convert.ToDecimal(MaximumValue); } }

    }
}
