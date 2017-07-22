using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class NewAccountInfo
    {
        [JsonProperty("client_id")]
        public long ClientId { get; set; }

        [JsonProperty("account_level")]
        public string AccountLevel { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
