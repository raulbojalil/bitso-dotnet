using BitsoDotNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //Get your API and secret keys at https://bitso.com/api_setup
                //These are not required if calling public API methods only
                var bitsoClient = new Bitso("[API_KEY]", "[SECRET_KEY]", production: false);
                
                //PUBLIC API

                Console.WriteLine("Get Available Books:");
                Console.WriteLine("-------------------");

                foreach (var book in bitsoClient.PublicAPI.GetAvailableBooks())
                {
                    Console.WriteLine($"[BOOK] {book.Book}, Max. Amount = {book.MaximumAmount}, Min. Amount = {book.MinimumAmount}");
                }

                Console.WriteLine("\r\nGet Order Book:");
                Console.WriteLine("-------------------");

                var orderBook = bitsoClient.PublicAPI.GetOrderBook();

                Console.WriteLine($"Asks = {orderBook.Asks.Length}, Bids = {orderBook.Bids.Length}, Sequence = {orderBook.Sequence}, UpdatedAt = {orderBook.UpdatedAt}");

                Console.WriteLine("\r\nGet Ticker:");
                Console.WriteLine("-------------------");

                var ticker = bitsoClient.PublicAPI.GetTicker();

                Console.WriteLine($"Book = {ticker.Book}, Last = {ticker.LastTradedPrice}, High = {ticker.PriceHigh}, Low = {ticker.PriceLow}");

                Console.WriteLine("\r\nGet Trades:");
                Console.WriteLine("-------------------");

                foreach (var trade in bitsoClient.PublicAPI.GetTrades())
                {
                    Console.WriteLine($"[TRADE] Tid = {trade.Tid}, Book = {trade.Book}, Price = {trade.Price}, Amount = {trade.Amount}");
                }

                //PRIVATE API

                Console.WriteLine("\r\nGet Account Status:");
                Console.WriteLine("-------------");

                var accountStatus = bitsoClient.PrivateAPI.GetAccountStatus();
                
                Console.WriteLine($"[ACCOUNT STATUS] {accountStatus.Status}, Daily Limit = {accountStatus.DailyLimit}, Daily Remaining = {accountStatus.DailyRemaining}, Monthly Limit = {accountStatus.MonthlyLimit}, Monthly Remaining = {accountStatus.MonthlyRemaining}");

                Console.WriteLine("\r\nGet Fees:");
                Console.WriteLine("-------------");

                var feeInfo = bitsoClient.PrivateAPI.GetFees();

                foreach (var fee in feeInfo.Fees)
                {
                    Console.WriteLine($"[FEE] {fee.Book}, Fee Decimal = {fee.FeeDecimal}, Fee Percent = {fee.FeePercent}");
                }

                Console.WriteLine("\r\nGet Ledger:");
                Console.WriteLine("-------------");

                var operations = bitsoClient.PrivateAPI.GetLedger();

                foreach (var operation in operations)
                {
                    Console.WriteLine($"[OPERATION] {operation.Eid}, Type = {operation.OperationType}");
                }

                Console.WriteLine("\r\nGet Withdrawals:");
                Console.WriteLine("-------------");

                foreach (var withdrawal in bitsoClient.PrivateAPI.GetWithdrawals())
                {
                    Console.WriteLine($"[WITHDRAWAL] {withdrawal.Wid}, Amount = {withdrawal.Amount} {withdrawal.Currency}");
                }

                Console.WriteLine("\r\nGet Fundings:");
                Console.WriteLine("-------------");

                var fundings = bitsoClient.PrivateAPI.GetFundings();

                foreach (var funding in fundings)
                {
                    Console.WriteLine($"[FUNDING] {funding.Fid}, Amount = {funding.Amount} {funding.Currency}");
                }

                Console.WriteLine("\r\nGet Account Balance:");
                Console.WriteLine("-------------");

                foreach (var balance in bitsoClient.PrivateAPI.GetAccountBalance())
                {
                    Console.WriteLine($"[BALANCE] {balance.Currency}, Total = {balance.Total}, Locked = {balance.Locked}, Available = {balance.Available}");
                }

                Console.WriteLine("\r\nGet User Trades:");
                Console.WriteLine("-------------");

                foreach (var userTrade in bitsoClient.PrivateAPI.GetUserTrades())
                {
                    Console.WriteLine($"[USER TRADE] {userTrade.Tid}, Oid = {userTrade.Oid}, Book = {userTrade.Book}, Side = {userTrade.Side}, Price = {userTrade.Price}");
                }

                Console.WriteLine("\r\nGet Open Orders:");
                Console.WriteLine("-------------");

                foreach (var order in bitsoClient.PrivateAPI.GetOpenOrders())
                {
                    Console.WriteLine($"[ORDER] Oid = {order.Oid}, Book = {order.Book}, Status = {order.Status}, Price = {order.Price}");
                }

                //Place an order to buy 0.5 bitcoin at a price of 1,000.00 mxn per bitcoin (to spend: 500.00 mxn)
                var newOrder = bitsoClient.PrivateAPI.PlaceOrder(
                    book: "btc_mxn", type: "limit", side: "buy", price: 1000.00M, majorAmount: 0.5M );

                //Place an order to sell 0.01 bitcoin at a price of 80,000.00 mxn per bitcoin (to earn: 800.00 mxn)
                var newOrder2 = bitsoClient.PrivateAPI.PlaceOrder(
                    book: "btc_mxn", type: "limit", side: "sell", price: 80000.00M, majorAmount: 0.01M );

                //You can also use CancelAllOpenOrders and CancelOrder
                foreach (var order in bitsoClient.PrivateAPI.CancelOpenOrders(newOrder.Oid, newOrder2.Oid)) 
                {
                    Console.WriteLine($"[CANCELED ORDER] {order}");
                }

                Console.WriteLine("\r\nGet Funding Destination:");
                Console.WriteLine("-------------------");

                var fundingDestination = bitsoClient.PrivateAPI.GetFundingDestination("BTC");

                Console.WriteLine($"[BTC FUNDING DESTINATION] {fundingDestination.AccountIdentifier} ({fundingDestination.AccountIdentifierName})");

                Console.WriteLine("\r\nGet Bank Codes:");
                Console.WriteLine("-------------");

                var bankCodes = bitsoClient.PrivateAPI.GetMexicanBankCodes();

                foreach (var bankCode in bankCodes)
                {
                    Console.WriteLine($"[BANK CODE] {bankCode.Code} {bankCode.Name}");
                }
            }
            catch (BitsoException bex)
            {
                Console.WriteLine($"[ERROR] Code {bex.ErrorCode}. {bex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }

            Console.WriteLine("\r\n\r\nPress any key to continue...");
            Console.Read();

        }
    }
}
