using Newtonsoft.Json;
using System;

namespace BitsoDotNet.Entities
{
    public class OrderBook
    {
        [JsonProperty("asks")]
        public OrderInfo[] Asks { get; set; }

        [JsonProperty("bids")]
        public OrderInfo[] Bids { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }

    public class OrderInfo
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }
    }
}
