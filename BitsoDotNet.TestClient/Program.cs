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
                var bitsoClient = new Bitso("[API_KEY]", "[SECRET_KEY]", true);

                Console.WriteLine("Get Available Books:");
                Console.WriteLine("-------------------\r\n");

                foreach (var book in bitsoClient.PublicAPI.GetAvailableBooks())
                {
                    Console.WriteLine($"[BOOK] {book.Book}, Max. Amount = {book.MaximumAmount}, Min. Amount = {book.MinimumAmount}");
                }

                Console.WriteLine("\r\nGet Order Book:");
                Console.WriteLine("-------------------\r\n");

                var orderBook = bitsoClient.PublicAPI.GetOrderBook();

                Console.WriteLine($"Asks = {orderBook.Asks.Length}, Bids = {orderBook.Bids.Length}, Sequence = {orderBook.Sequence}, UpdatedAt = {orderBook.UpdatedAt}");

                Console.WriteLine("\r\nGet Ticker:");
                Console.WriteLine("-------------------\r\n");

                var ticker = bitsoClient.PublicAPI.GetTicker();

                Console.WriteLine($"Book = {ticker.Book}, High = {ticker.High}, Low = {ticker.Low}");

                Console.WriteLine("\r\nGet Trades:");
                Console.WriteLine("-------------------\r\n");

                foreach(var trade in bitsoClient.PublicAPI.GetTrades())
                {
                    Console.WriteLine($"[TRADE] Tid = {trade.Tid}, Book = {trade.Book}, Price = {trade.Price}, Amount = {trade.Amount}");
                }

                

                Console.WriteLine("\r\nGetOpenOrders:");
                Console.WriteLine("-------------\r\n");

                //Get a list of open orders
                foreach (var order in bitsoClient.PrivateAPI.GetOpenOrders())
                {
                    Console.WriteLine($"[ORDER] Book = {order.Book}, Status = {order.Status}");
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
