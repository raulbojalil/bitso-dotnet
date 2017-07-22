using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class OrdersRequest
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("marker")]
        public string Marker { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
