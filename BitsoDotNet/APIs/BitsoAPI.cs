using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.APIs
{
    public abstract class BitsoAPI
    {
        protected Bitso BitsoClient { get; private set; }

        protected BitsoAPI(Bitso bistoClient)
        {
            BitsoClient = bistoClient;
        }
    }
}
