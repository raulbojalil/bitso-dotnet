using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BitsoDotNet.Entities
{
    public class Fee
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("fee_decimal")]
        public string FeeDecimal { get; set; }

        [JsonProperty("fee_percent")]
        public string FeePercent { get; set; }

        public decimal FeeDecimalAsDecimal { get { return Convert.ToDecimal(FeeDecimal); } }
        public decimal FeePercentDecimal { get { return Convert.ToDecimal(FeePercent); } }

    }

    public class FeeInfo
    {
        [JsonProperty("fees")]
        public Fee[] Fees { get; set; }

        [JsonProperty("withdrawal_fees")]
        public Dictionary<string, string> WithdrawalFees { get; set; }

        public Dictionary<string, decimal> WithdrawalFeesAsDecimal {
            get
            {
                if(_withdrawalFeesAsDecimal == null)
                {
                    _withdrawalFeesAsDecimal = new Dictionary<string, decimal>();
                    foreach (var fee in WithdrawalFees)
                        _withdrawalFeesAsDecimal.Add(fee.Key, Convert.ToDecimal(fee.Value));
                }
                return _withdrawalFeesAsDecimal;
            }
        }
        private Dictionary<string, decimal> _withdrawalFeesAsDecimal = null;

    }
}
