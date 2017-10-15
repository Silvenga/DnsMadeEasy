using Newtonsoft.Json;

namespace DnsMadeEasy.Api.Models
{
    public class Nameserver
    {
        [JsonProperty("fqdn")]
        public string Fqdn { get; set; }

        [JsonProperty("ipv4")]
        public string Ipv4 { get; set; }

        [JsonProperty("ipv6")]
        public string Ipv6 { get; set; }

        public override string ToString()
        {
            return $"{Fqdn}";
        }
    }
}