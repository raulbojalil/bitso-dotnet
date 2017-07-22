using BitsoDotNet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.APIs
{
    public class AccountCreationAPI : BitsoAPI
    {

        internal AccountCreationAPI(Bitso bitsoClient) : base(bitsoClient)
        {
        }

        //https://bitso.com/api_info#account_required_fields/
        public AccountRequiredField[] GetAccountRequiredFields()
        {
            var rawResponse = BitsoClient.SendRequest("account_required_fields", "GET");
            return JsonConvert.DeserializeObject<AccountRequiredField[]>(rawResponse);
        }

        //https://bitso.com/api_info#account-creation
        public NewAccountInfo CreateAccount(Dictionary<string, string> requiredFieldValues, string webhookUrl = null)
        {
            if(!string.IsNullOrEmpty(webhookUrl))
                requiredFieldValues.Add("webhook_url", webhookUrl);
            var rawResponse = BitsoClient.SendRequest("accounts", "POST", true, BitsoUtils.BuildJson(requiredFieldValues));
            return JsonConvert.DeserializeObject<NewAccountInfo>(rawResponse);
        }
    }
}
