using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BitsoDotNet.Entities
{
    public class FundingDestination
    {
        [JsonProperty("account_identifier_name")]
        public string AccountIdentifierName { get; set; }

        [JsonProperty("account_identifier")]
        public string AccountIdentifier { get; set; }

    }
}
