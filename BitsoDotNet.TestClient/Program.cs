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
                    Console.WriteLine($"[BOOK] {book.Book}");
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
