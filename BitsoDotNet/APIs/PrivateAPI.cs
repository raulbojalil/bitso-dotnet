using BitsoDotNet.Entities;
using Newtonsoft.Json;
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

        //https://bitso.com/api_info#open-orders
        public OpenOrder[] GetOpenOrders(OrdersRequest request = null)
        {
            var rawResponse = BitsoClient.SendRequest("open_orders" + (request != null ? 
               BitsoUtils.BuildQueryString(request) : "?book=btc_mxn"), "GET");
            return JsonConvert.DeserializeObject<OpenOrder[]>(rawResponse);
        }

        //https://bitso.com/api_info#place-an-order
        public OpenOrder PlaceOrder(PlaceOrderRequest request)
        {
            var rawResponse = BitsoClient.SendRequest("orders", "POST", true, JsonConvert.SerializeObject(request));
            return JsonConvert.DeserializeObject<OpenOrder>(rawResponse);
        }

        //https://bitso.com/api_info#cancel_order
        public string[] CancelAllOpenOrders()
        {
            var rawResponse = BitsoClient.SendRequest("orders/all", "DELETE");
            return JsonConvert.DeserializeObject<string[]>(rawResponse);
        }

        //https://bitso.com/api_info#cancel_order
        public string[] CancelOpenOrder(string oid)
        {
            var rawResponse = BitsoClient.SendRequest($"orders/{oid}", "DELETE");
            return JsonConvert.DeserializeObject<string[]>(rawResponse);
        }

        //https://bitso.com/api_info#cancel_order
        public string[] CancelOpenOrders(params string[] oids)
        {
            var oidsBuilder = new StringBuilder();
            var index = 0;
            foreach(var oid in oids)
            {
                if(index > 0) oidsBuilder.Append("-");
                oidsBuilder.Append(oid);
                index++;
            }
            var rawResponse = BitsoClient.SendRequest($"orders/{oidsBuilder.ToString()}", "DELETE");
            return JsonConvert.DeserializeObject<string[]>(rawResponse);
        }
    }
}
