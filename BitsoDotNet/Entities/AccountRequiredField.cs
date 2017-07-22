using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class AccountRequiredField
    {
        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("field_description")]
        public string FieldDescription { get; set; }
    }
}
