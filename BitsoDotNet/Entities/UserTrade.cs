using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class UserTrade
    {
        
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("major")]
        public string Major { get; set; }

        [JsonProperty("minor")]
        public string Minor { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("fees_currency")]
        public string FeesCurrency { get; set; }

        [JsonProperty("fees_amount")]
        public string FeesAmount { get; set; }

        [JsonProperty("tid")]
        public long Tid { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }


        public decimal MajorAsDecimal { get { return Convert.ToDecimal(Major); } }
        public decimal MinorAsDecimal { get { return Convert.ToDecimal(Minor); } }
        public decimal PriceAsDecimal { get { return Convert.ToDecimal(Price); } }
        public decimal FeesAmountAsDecimal { get { return Convert.ToDecimal(FeesAmount); } }

    }
}
