using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class Trade
    {
        
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("maker_side")]
        public string MakerSide { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("tid")]
        public long Tid { get; set; }

        public decimal AmountAsDecimal { get { return Convert.ToDecimal(Amount); } }
        public decimal PriceAsDecimal { get { return Convert.ToDecimal(Price); } }

    }
}
