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
        public BitsoBook[] GetAvailableBooks()
        {
            var rawResponse = BitsoClient.SendRequest("available_books", "GET", false);
            return JsonConvert.DeserializeObject<BitsoBook[]>(rawResponse);
        }
    }
}
