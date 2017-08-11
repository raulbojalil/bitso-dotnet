using Newtonsoft.Json;
using System;

namespace BitsoDotNet.Entities
{
    public class AccountStatus
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("daily_limit")]
        public string DailyLimit { get; set; }

        [JsonProperty("monthly_limit")]
        public string MonthlyLimit { get; set; }

        [JsonProperty("daily_remaining")]
        public string DailyRemaining { get; set; }

        [JsonProperty("monthly_remaining")]
        public string MonthlyRemaining { get; set; }

        [JsonProperty("cellphone_number")]
        public string CellphoneNumber { get; set; }
            
        [JsonProperty("cellphone_number_stored")]
        public string CellphoneNumberStored { get; set; }
            
        [JsonProperty("email_stored")]
        public string EmailStored { get; set; }
            
        [JsonProperty("official_id")]
        public string OfficialId { get; set; }
            
        [JsonProperty("proof_of_residency")]
        public string ProofOfResidency { get; set; }

        [JsonProperty("signed_contract")]
        public string SignedContract { get; set; }

        [JsonProperty("origin_of_funds")]
        public string OriginOfFunds { get; set; }


        public decimal DailyLimitAsDecimal { get { return Convert.ToDecimal(DailyLimit); } }
        public decimal MonthlyLimitAsDecimal { get { return Convert.ToDecimal(MonthlyLimit); } }
        public decimal DailyRemainingAsDecimal { get { return Convert.ToDecimal(DailyRemaining); } }
        public decimal MonthlyRemainingAsDecimal { get { return Convert.ToDecimal(MonthlyRemaining); } }

    }
}
