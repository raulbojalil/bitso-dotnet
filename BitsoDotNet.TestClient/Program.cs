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
                var bitsoClient = new Bitso("[API_KEY]", "[SECRET_KEY]", false);

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

                Console.WriteLine("\r\nGetAccountStatus:");
                Console.WriteLine("-------------");

                var accountStatus = bitsoClient.PrivateAPI.GetAccountStatus();
                
                Console.WriteLine($"[ACCOUNT STATUS] {accountStatus.Status}, Daily Limit = {accountStatus.DailyLimit}, Daily Remaining = {accountStatus.DailyRemaining}, Monthly Limit = {accountStatus.MonthlyLimit}, Monthly Remaining = {accountStatus.MonthlyRemaining}");

                Console.WriteLine("\r\nGetFees:");
                Console.WriteLine("-------------");

                var feeInfo = bitsoClient.PrivateAPI.GetFees();

                foreach (var fee in feeInfo.Fees)
                {
                    Console.WriteLine($"[FEE] {fee.Book}, Fee Decimal = {fee.FeeDecimal}, Fee Percent = {fee.FeePercent}");
                }

                Console.WriteLine("\r\nGetAccountBalance:");
                Console.WriteLine("-------------");

                //Get the user's balance
                foreach (var balance in bitsoClient.PrivateAPI.GetAccountBalance())
                {
                    Console.WriteLine($"[BALANCE] {balance.Currency}, Total = {balance.Total}, Locked = {balance.Locked}, Available = {balance.Available}");
                }

                Console.WriteLine("\r\nGetOpenOrders:");
                Console.WriteLine("-------------");

                //Get a list of open orders
                foreach (var order in bitsoClient.PrivateAPI.GetOpenOrders())
                {
                    Console.WriteLine($"[ORDER] Oid = {order.Oid}, Book = {order.Book}, Status = {order.Status}, Price = {order.Price}");
                }

                //Place an order to buy 0.5 bitcoin at a price of 1,000.00 mxn per bitcoin (to spend: 500.00 mxn)
                var newOrder = bitsoClient.PrivateAPI.PlaceOrder(
                    new PlaceOrderRequest() { Book = "btc_mxn", Type = "limit", Side = "buy", Price = "1000.00", MajorAmount = "0.5" });

                //Place an order to sell 0.01 bitcoin at a price of 80,000.00 mxn per bitcoin (to earn: 800.00 mxn)
                var newOrder2 = bitsoClient.PrivateAPI.PlaceOrder(
                    new PlaceOrderRequest() { Book = "btc_mxn", Type = "limit", Side = "sell", Price = "80000.00", MajorAmount = "0.01" });

                //You can also use CancelAllOpenOrders and CancelOrder
                foreach (var order in bitsoClient.PrivateAPI.CancelOpenOrders(newOrder.Oid, newOrder2.Oid)) 
                {
                    Console.WriteLine($"[CANCELED ORDER] {order}");
                }

            }
            catch(BitsoException bex)
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
