using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DnsMadeEasy.Helpers
{
    public class HeadersHelper
    {
        public static IEnumerable<KeyValuePair<string, string>> CreateAuthorizationHeaders(string apiKey, string apiSecret, DateTimeOffset requestDateTimeOffset)
        {
            yield return new KeyValuePair<string, string>("x-dnsme-apiKey", apiKey);
            
            var requestDateStr = requestDateTimeOffset.ToString("r");
            yield return new KeyValuePair<string, string>("x-dnsme-requestDate", requestDateStr);

            var hash = Encode(requestDateStr, apiSecret);
            yield return new KeyValuePair<string, string>("x-dnsme-hmac", hash);
        }

        private static string Encode(string input, string key)
        {
            // https://stackoverflow.com/a/6533030/2001966

            var encoding = Encoding.ASCII;

            var keyBytes = encoding.GetBytes(key);
            using (var hmacsha1 = new HMACSHA1(keyBytes))
            {
                var inputBytes = encoding.GetBytes(input);
                return hmacsha1.ComputeHash(inputBytes)
                               .Aggregate("", (s, e) => s + string.Format("{0:x2}", e), s => s);
            }
        }
    }
}