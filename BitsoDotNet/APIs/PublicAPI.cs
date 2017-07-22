using BitsoDotNet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.APIs
{
    public class PublicAPI : BitsoAPI
    {
        internal PublicAPI(Bitso bitsoClient) : base(bitsoClient)
        {
        }

        //https://bitso.com/api_info#available-books
        public BookInfo[] GetAvailableBooks()
        {
            var rawResponse = BitsoClient.SendRequest("available_books", "GET", false);
            return JsonConvert.DeserializeObject<BookInfo[]>(rawResponse);
        }

        //https://bitso.com/api_info#ticker
        public Ticker GetTicker(string book = "btc_mxn")
        {
            var rawResponse = BitsoClient.SendRequest($"ticker?book={book}", "GET", false);
            return JsonConvert.DeserializeObject<Ticker>(rawResponse);
        }

        //https://bitso.com/api_info#order_book
        public OrderBook GetOrderBook(string book = "btc_mxn", bool aggregate = true)
        {
            var rawResponse = BitsoClient.SendRequest($"order_book?book={book}&aggregate={(aggregate ? "true" : "false")}", "GET", false);
            return JsonConvert.DeserializeObject<OrderBook>(rawResponse);
        }

        //https://bitso.com/api_info#trades
        public Trade[] GetTrades(OrdersRequest request = null)
        {
            var rawResponse = BitsoClient.SendRequest($"trades" + (request != null ? BitsoUtils.BuildQueryString(request) : "?book=btc_mxn"), "GET", false);
            return JsonConvert.DeserializeObject<Trade[]>(rawResponse);
        }
    }
}
