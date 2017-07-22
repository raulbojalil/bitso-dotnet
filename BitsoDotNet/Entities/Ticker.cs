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
        public string High { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("vwap")]
        public string Vwap { get; set; }

        [JsonProperty("ask")]
        public string Ask { get; set; }

        [JsonProperty("bid")]
        public string Bid { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
