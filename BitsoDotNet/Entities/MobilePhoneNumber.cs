using System;
using Newtonsoft.Json;

namespace BitsoDotNet.Entities
{
    public class MobilePhoneNumber
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }
    }
}