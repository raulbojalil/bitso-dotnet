using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class Ticker
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("high")]
        public string PriceHigh { get; set; }

        [JsonProperty("last")]
        public string LastTradedPrice { get; set; }

        [JsonProperty("low")]
        public string PriceLow { get; set; }

        [JsonProperty("vwap")]
        public string VolumeWeightedAvgPrice { get; set; }

        [JsonProperty("ask")]
        public string Ask { get; set; }

        [JsonProperty("bid")]
        public string Bid { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        public decimal VolumeAsDecimal { get { return Convert.ToDecimal(Volume); } }
        public decimal PriceHighAsDecimal { get { return Convert.ToDecimal(PriceHigh); } }
        public decimal LastTradedPriceAsDecimal { get { return Convert.ToDecimal(LastTradedPrice); } }
        public decimal PriceLowAsDecimal { get { return Convert.ToDecimal(PriceLow); } }
        public decimal VolumeWeightedAvgPriceAsDecimal { get { return Convert.ToDecimal(VolumeWeightedAvgPrice); } }
        public decimal AskAsDecimal { get { return Convert.ToDecimal(Ask); } }
        public decimal BidAsDecimal { get { return Convert.ToDecimal(Bid); } }
    }
}
