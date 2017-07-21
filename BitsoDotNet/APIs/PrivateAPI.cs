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
        public BitsoOrder[] GetOpenOrders(BitsoOpenOrdersRequest request = null)
        {
            var rawResponse = BitsoClient.SendRequest("open_orders" + (request != null ? 
               BitsoUtils.BuildQueryString(request) : "?book=btc_mxn"), "GET");
            return JsonConvert.DeserializeObject<BitsoOrder[]>(rawResponse);
        }
    }
}
