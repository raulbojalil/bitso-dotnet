using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class PlaceOrderRequest
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("major")]
        public string MajorAmount { get; set; }

        [JsonProperty("minor")]
        public string MinorAmount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
