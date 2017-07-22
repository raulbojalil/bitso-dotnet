﻿using BitsoDotNet.APIs;
using BitsoDotNet.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BitsoDotNet
{
    public class Bitso
    {

        private readonly string BITSO_KEY;
        private readonly string BITSO_SECRET;
        private readonly string BITSO_API_URL;
        private readonly string BITSO_VERSION_PREFIX;

        public readonly PrivateAPI PrivateAPI;
        public readonly PublicAPI PublicAPI;

        public Bitso(string key, string secret, bool production = false)
        {
            BITSO_KEY = key;
            BITSO_SECRET = secret;
            BITSO_API_URL = production ? "https://api.bitso.com" : "https://api-dev.bitso.com";
            BITSO_VERSION_PREFIX = "/api/v3/";
            PrivateAPI = new PrivateAPI(this);
            PublicAPI = new PublicAPI(this);
        }

        public string SendRequest(string url, string method, bool signRequest = true, string body = "")
        {
            var requestPath = BITSO_VERSION_PREFIX + url;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BITSO_API_URL + requestPath);

            if (signRequest)
            {
                //Authorization: Bitso <key>:<nonce>:<signature>
                //key = The API Key you generated
                //nonce = An Integer that must be unique and increasing for each API call
                //signature = The signature is generated by creating a SHA256 HMAC using the Bitso API Secret on the concatenation of nonce + HTTP method + requestPath + JSON payload (no ’+’ signs in the concatenated string) and hex encode the output. 

                var nonce = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                var signature = BitsoUtils.ToHexString(BitsoUtils.HMACSHA256(nonce + method + requestPath + body, BITSO_SECRET));

                httpWebRequest.Headers["Authorization"] = $"Bitso {BITSO_KEY}:{nonce}:{signature}";
            }

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;

            var response = string.Empty;

            if (!string.IsNullOrEmpty(body))
            {
                using (var req = httpWebRequest.GetRequestStream())
                {
                    var bodyBytes = Encoding.UTF8.GetBytes(body);
                    req.Write(bodyBytes, 0, bodyBytes.Length);
                }
            }

            try
            {
                using (var res = httpWebRequest.GetResponse())
                {
                    using (var str = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(str))
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (var res = ex.Response)
                {
                    if (res == null)
                        throw new BitsoException("Invalid Bitso Response", "0");

                    using (var str = res.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(str))
                        {
                            response = reader.ReadToEnd();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BitsoException(ex.Message, "0");
            }

            var responseObj = JsonConvert.DeserializeObject<JObject>(response);

            if (responseObj == null) throw new BitsoException("Invalid Bitso Response", "0");

            if (responseObj["success"].Value<bool>())
                return responseObj["payload"].ToString();

            throw new BitsoException(responseObj["error"]["message"].ToString(), responseObj["error"]["code"].ToString());
        }

    }
}