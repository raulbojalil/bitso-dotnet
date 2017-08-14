using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BitsoDotNet.Entities
{

    public class Operation
    {
        [JsonProperty("eid")]
        public string Eid { get; set; }

        [JsonProperty("operation")]
        private string _operation { get; set; }

        public OperationType OperationType
        {
            get
            {
                switch (_operation)
                {
                    case "trade": return OperationType.Trade;
                    case "funding": return OperationType.Funding;
                    case "fee": return OperationType.Fee;
                    case "withdrawal": return OperationType.Withdrawal;
                }

                return OperationType.Unknown;
            }
        }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("balance_updates")]
        public BalanceUpdate[] BalanceUpdates { get; set; }
    }

    public enum OperationType
    {
        Unknown,
        Trade,
        Funding,
        Withdrawal,
        Fee
    }

    public class BalanceUpdate
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        public decimal BalanceAsDecimal { get { return Convert.ToDecimal(Balance); } }
    }

    public class TradeOperation : Operation
    {
        [JsonProperty("details")]
        public TradeOperationDetails Details { get; set; }
    }

    public class TradeOperationDetails
    {
        [JsonProperty("tid")]
        public string Tid { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }
    }

    public class FundingOperation : Operation
    {
        [JsonProperty("details")]
        public FundingOperationDetails Details { get; set; }
    }

    public class FundingOperationDetails
    {
        [JsonProperty("fid")]
        public string Fid { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }
    }

    public class WithdrawalOperation : Operation
    {
        [JsonProperty("details")]
        public WithdrawalOperationDetails Details { get; set; }
    }

    public class WithdrawalOperationDetails
    {
        [JsonProperty("wid")]
        public string Wid { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

    }

    public class FeeOperation : Operation
    {
        [JsonProperty("details")]
        public FeeOperationDetails Details { get; set; }
    }

    public class FeeOperationDetails
    {
        [JsonProperty("tid")]
        public string Tid { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }
    }
}
