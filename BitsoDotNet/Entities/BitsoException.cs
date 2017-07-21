using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet.Entities
{
    public class BitsoException : Exception
    {
        public BitsoException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
        public string ErrorCode { get; set; }

    }
}
