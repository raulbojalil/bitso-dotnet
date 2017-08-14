using BitsoDotNet.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.APIs
{
    public class PrivateAPI : BitsoAPI
    {
        internal PrivateAPI(Bitso bitsoClient) : base(bitsoClient)
        {
        }

        //https://bitso.com/api_info#account-status
        public AccountStatus GetAccountStatus()
        {
            var rawResponse = BitsoClient.SendRequest("account_status", "GET");
            return JsonConvert.DeserializeObject<AccountStatus>(rawResponse);
        }

        //https://bitso.com/api_info#mobile-phone-number-registration
        public MobilePhoneNumber RegisterMobilePhoneNumber(string mobilePhoneNumber)
        {
            var rawResponse = BitsoClient.SendRequest("phone_number", "POST", true, $"{{ \"phone_number\": \"{mobilePhoneNumber}\" }}");
            return JsonConvert.DeserializeObject<MobilePhoneNumber>(rawResponse); ;
        }

        //https://bitso.com/api_info#mobile-phone-number-verification
        public MobilePhoneNumber VerifyMobilePhoneNumber(string verificationCode)
        {
            var rawResponse = BitsoClient.SendRequest("phone_verification", "POST", true, $"{{ \"verification_code\": \"{verificationCode}\" }}");
            return JsonConvert.DeserializeObject<MobilePhoneNumber>(rawResponse);
        }

        //https://bitso.com/api_info#account-balance
        public Balance[] GetAccountBalance()
        {
            var rawResponse = BitsoClient.SendRequest("balance", "GET");
            return JsonConvert.DeserializeObject<Balance[]>(rawResponse);
        }

        //https://bitso.com/api_info?#fees
        public FeeInfo GetFees()
        {
            var rawResponse = BitsoClient.SendRequest("fees", "GET");
            return JsonConvert.DeserializeObject<FeeInfo>(rawResponse);
        }

        //https://bitso.com/api_info#ledger
        public Operation[] GetLedger(OperationType operationType, string marker = "", string sort = "desc", int limit = 25)
        {
            var operationTypeUrl = string.Empty;
            switch (operationType)
            {
                case OperationType.Fee: operationTypeUrl = "/fees"; break;
                case OperationType.Funding: operationTypeUrl = "/fundings"; break;
                case OperationType.Withdrawal: operationTypeUrl = "/withdrawals"; break;
                case OperationType.Trade: operationTypeUrl = "/trades"; break;
            }

            var rawResponse = BitsoClient.SendRequest("ledger" + operationTypeUrl + BitsoUtils.BuildQueryString("marker", marker, "sort", sort, "limit", limit.ToString()), "GET");

            var responseArray = JsonConvert.DeserializeObject<JArray>(rawResponse);
            var operations = new Operation[responseArray.Count];
            var index = 0;

            foreach (var operation in responseArray)
            {
                switch (operation["operation"].ToString())
                {
                    case "trade": operations[index] = JsonConvert.DeserializeObject<TradeOperation>(operation.ToString()); break;
                    case "funding": operations[index] = JsonConvert.DeserializeObject<FundingOperation>(operation.ToString()); break;
                    case "fee": operations[index] = JsonConvert.DeserializeObject<FeeOperation>(operation.ToString()); break;
                    case "withdrawal": operations[index] = JsonConvert.DeserializeObject<WithdrawalOperation>(operation.ToString()); break;
                    default: operations[index] = JsonConvert.DeserializeObject<Operation>(operation.ToString()); break;
                }
                index++;
            }
            return operations;
        }

        public Operation[] GetLedger(string marker = "", string sort = "desc", int limit = 25)
        {
            return GetLedger(OperationType.Unknown, marker, sort, limit);
        }

        //https://bitso.com/api_info#withdrawals
        public Withdrawal[] GetWithdrawals(int limit = 25)
        {
            var rawResponse = BitsoClient.SendRequest($"withdrawals?limit={limit}", "GET");
            return JsonConvert.DeserializeObject<Withdrawal[]>(rawResponse);
        }

        public Withdrawal GetWithdrawal(string wid)
        {
            var rawResponse = BitsoClient.SendRequest($"withdrawals/{wid}", "GET");
            var withdrawal = JsonConvert.DeserializeObject<Withdrawal[]>(rawResponse);
            if (withdrawal != null && withdrawal.Length > 0) return withdrawal[0];
            return null;
        }

        public Withdrawal[] GetWithdrawals(params string[] wids)
        {
            var widsBuilder = new StringBuilder();
            var index = 0;
            foreach (var wid in wids)
            {
                if (index > 0) widsBuilder.Append("-");
                widsBuilder.Append(wid);
                index++;
            }
            var rawResponse = BitsoClient.SendRequest($"withdrawals/{widsBuilder.ToString()}", "GET");
            return JsonConvert.DeserializeObject<Withdrawal[]>(rawResponse);
        }

        //https://bitso.com/api_info#fundings
        public Funding[] GetFundings(int limit = 25)
        {
            var rawResponse = BitsoClient.SendRequest($"fundings?limit={limit}", "GET");
            return JsonConvert.DeserializeObject<Funding[]>(rawResponse);
        }

        public Funding GetFunding(string fid)
        {
            var rawResponse = BitsoClient.SendRequest($"fundings/{fid}", "GET");
            var funding = JsonConvert.DeserializeObject<Funding[]>(rawResponse);
            if (funding != null && funding.Length > 0) return funding[0];
            return null;
        }

        public Funding[] GetFundings(params string[] fids)
        {
            var fidsBuilder = new StringBuilder();
            var index = 0;
            foreach (var fid in fids)
            {
                if (index > 0) fidsBuilder.Append("-");
                fidsBuilder.Append(fid);
                index++;
            }
            var rawResponse = BitsoClient.SendRequest($"fundings/{fidsBuilder.ToString()}", "GET");
            return JsonConvert.DeserializeObject<Funding[]>(rawResponse);
        }

        //https://bitso.com/developers#user-trades
        public UserTrade[] GetUserTrades(string book = "btc_mxn", string marker = "", string sort = "desc", int limit = 25)
        {
            var rawResponse = BitsoClient.SendRequest("user_trades" + BitsoUtils.BuildQueryString("book", book, "marker", marker, "sort", sort, "limit", limit.ToString()), "GET");
            return JsonConvert.DeserializeObject<UserTrade[]>(rawResponse);
        }

        public UserTrade GetUserTrade(string tid)
        {
            var rawResponse = BitsoClient.SendRequest($"user_trades/{tid}", "GET");
            var userTrades = JsonConvert.DeserializeObject<UserTrade[]>(rawResponse);
            if (userTrades != null && userTrades.Length > 0) return userTrades[0];
            return null;
        }

        public UserTrade[] GetUserTrades(params string[] tids)
        {
            var tidsBuilder = new StringBuilder();
            var index = 0;
            foreach (var tid in tids)
            {
                if (index > 0) tidsBuilder.Append("-");
                tidsBuilder.Append(tid);
                index++;
            }
            var rawResponse = BitsoClient.SendRequest($"user_trades/{tidsBuilder.ToString()}", "GET");
            return JsonConvert.DeserializeObject<UserTrade[]>(rawResponse);
        }

        //https://bitso.com/developers#order-trades
        public UserTrade[] GetOrderTrades(string oid)
        {
            var rawResponse = BitsoClient.SendRequest($"order_trades/{oid}", "GET");
            return JsonConvert.DeserializeObject<UserTrade[]>(rawResponse);
        }

        //https://bitso.com/api_info#open-orders
        public OpenOrder[] GetOpenOrders(string book = "btc_mxn", string marker = "", string sort = "desc", int limit = 25)
        {
            var rawResponse = BitsoClient.SendRequest("open_orders" + BitsoUtils.BuildQueryString("book", book, "marker", marker, "sort", sort, "limit", limit.ToString()), "GET");
            return JsonConvert.DeserializeObject<OpenOrder[]>(rawResponse);
        }

        //https://bitso.com/developers#lookup-orders
        public OpenOrder LookupOrder(string oid)
        {
            var rawResponse = BitsoClient.SendRequest($"orders/{oid}", "GET");
            var orders = JsonConvert.DeserializeObject<OpenOrder[]>(rawResponse);
            if (orders != null && orders.Length > 0) return orders[0];
            return null;
        }

        public OpenOrder[] LookupOrders(params string[] oids)
        {
            var oidsBuilder = new StringBuilder();
            var index = 0;
            foreach (var oid in oids)
            {
                if (index > 0) oidsBuilder.Append("-");
                oidsBuilder.Append(oid);
                index++;
            }
            var rawResponse = BitsoClient.SendRequest($"orders/{oidsBuilder.ToString()}", "GET");
            return JsonConvert.DeserializeObject<OpenOrder[]>(rawResponse);
        }

        //https://bitso.com/api_info#cancel_order
        public string[] CancelAllOpenOrders()
        {
            var rawResponse = BitsoClient.SendRequest("orders/all", "DELETE");
            return JsonConvert.DeserializeObject<string[]>(rawResponse);
        }

        public string[] CancelOpenOrder(string oid)
        {
            var rawResponse = BitsoClient.SendRequest($"orders/{oid}", "DELETE");
            return JsonConvert.DeserializeObject<string[]>(rawResponse);
        }

        public string[] CancelOpenOrders(params string[] oids)
        {
            var oidsBuilder = new StringBuilder();
            var index = 0;
            foreach (var oid in oids)
            {
                if (index > 0) oidsBuilder.Append("-");
                oidsBuilder.Append(oid);
                index++;
            }
            var rawResponse = BitsoClient.SendRequest($"orders/{oidsBuilder.ToString()}", "DELETE");
            return JsonConvert.DeserializeObject<string[]>(rawResponse);
        }

        //https://bitso.com/api_info#place-an-order
        public OpenOrder PlaceOrder(string book, string side, string type, decimal price, decimal? minorAmount = null, decimal? majorAmount = null)
        {
            var rawResponse = BitsoClient.SendRequest("orders", "POST", true,
                $"{{\"book\":\"{book}\"," +
                $"\"side\":\"{side}\"," +
                $"\"type\":\"{type}\"," +
                (minorAmount.HasValue ? $"\"minor\":\"{minorAmount.Value}\"," : "") +
                (majorAmount.HasValue ? $"\"major\":\"{majorAmount.Value}\"," : "") +
                $"\"price\":\"{price}\"}}");

            return JsonConvert.DeserializeObject<OpenOrder>(rawResponse);
        }

        //https://bitso.com/api_info#funding-destination
        public FundingDestination GetFundingDestination(string fundCurrency)
        {
            var rawResponse = BitsoClient.SendRequest($"funding_destination?fund_currency={fundCurrency}", "GET");
            return JsonConvert.DeserializeObject<FundingDestination>(rawResponse);
        }

        //https://bitso.com/developers#bitcoin-withdrawal
        public Withdrawal WithdrawToBitcoinAddress(decimal amount, string address)
        {
            var rawResponse = BitsoClient.SendRequest($"bitcoin_withdrawal", "POST", true, $"{{ \"amount\": \"{amount}\", \"address\": \"{address}\" }}");
            return JsonConvert.DeserializeObject<Withdrawal>(rawResponse);
        }

        //https://bitso.com/developers#ether_withdrawal
        public Withdrawal WithdrawToEtherAddress(decimal amount, string address)
        {
            var rawResponse = BitsoClient.SendRequest($"ether_withdrawal", "POST", true, $"{{ \"amount\": \"{amount}\", \"address\": \"{address}\" }}");
            return JsonConvert.DeserializeObject<Withdrawal>(rawResponse);
        }

        //https://bitso.com/developers#spei-withdrawal
        public Withdrawal WithdrawToSPEI(decimal amount, string recipientGivenNames, string recipientFamilyNames, string clabe, string notesRef, string numericRef)
        {
            var rawResponse = BitsoClient.SendRequest($"spei_withdrawal", "POST", true,
                $"{{\"amount\":\"{amount}\"," +
                $"\"recipient_given_names\":\"{recipientGivenNames}\"," +
                $"\"recipient_family_names\":\"{recipientFamilyNames}\"," +
                $"\"clabe\":\"{clabe}\"," +
                $"\"notes_ref\":\"{notesRef}\"," +
                $"\"numeric_ref\":\"{numericRef}\"}}");
                
            return JsonConvert.DeserializeObject<Withdrawal>(rawResponse);
        }

        //https://bitso.com/developers#debit-card-withdrawal
        public Withdrawal WithdrawToDebitCard(double amount, string recipientGivenNames, string recipientFamilyNames, string cardNumber, string bankCode)
        {
            var rawResponse = BitsoClient.SendRequest($"debit_card_withdrawal", "POST", true,
                $"{{ \"amount\": \"{amount}\"," +
                $"\"recipient_given_names\": \"{recipientGivenNames}\"," +
                $"\"recipient_family_names\": \"{recipientFamilyNames}\"," +
                $"\"card_number\": \"{cardNumber}\"," +
                $"\"bank_code\": \"{bankCode}\"}}");

            return JsonConvert.DeserializeObject<Withdrawal>(rawResponse);
        }

        //https://bitso.com/developers#phone-number-withdrawal
        public Withdrawal WithdrawToPhoneNumber(double amount, string recipientGivenNames, string recipientFamilyNames, string phoneNumber, string bankCode)
        {
            var rawResponse = BitsoClient.SendRequest($"phone_withdrawal", "POST", true,
                $"{{ \"amount\": \"{amount}\"," +
                $"\"recipient_given_names\": \"{recipientGivenNames}\"," +
                $"\"recipient_family_names\": \"{recipientFamilyNames}\"," +
                $"\"phone_number\": \"{phoneNumber}\"," +
                $"\"bank_code\": \"{bankCode}\"}}");

            return JsonConvert.DeserializeObject<Withdrawal>(rawResponse);
        }

        //https://bitso.com/developers#bank-codes
        public BankCode[] GetMexicanBankCodes()
        {
            var rawResponse = BitsoClient.SendRequest("mx_bank_codes", "GET");
            return JsonConvert.DeserializeObject<BankCode[]>(rawResponse);
        }

    }
}
