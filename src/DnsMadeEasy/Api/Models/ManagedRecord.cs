using Newtonsoft.Json;

namespace DnsMadeEasy.Api.Models
{
    public class ManagedRecord
    {
        /// <summary>
        /// The record name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// TTPRED: &lt;redirection URL&gt;
        /// MX: &lt;priority&gt; &lt;target name&gt;
        /// NS: &lt;name server&gt;
        /// PTR: &lt;target name&gt;
        /// SRV: &lt;priority&gt; &lt;weight&gt; &lt;port&gt; &lt;target
        /// name&gt;
        /// TXT: &lt;text value&gt;
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// The unique record identifier
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The record type. Values: A, AAAA,
        /// ANAME, CNAME, HTTPRED, MX, NS,
        /// PTR, SRV, TXT, SPF, or SOA.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } // TODO Use Enum

        /// <summary>
        /// 1 if the record is the record is domain
        /// specific, 0 if the record is part of a
        /// template.
        /// </summary>
        [JsonProperty("source")]
        public int? Source { get; set; }

        /// <summary>
        /// The source domain ID of the record
        /// </summary>
        [JsonProperty("sourceID")]
        public long? SourceId { get; set; }

        /// <summary>
        /// Indicates if the record has dynamic DNS
        /// enabled or not
        /// </summary>
        [JsonProperty("dynamicDns")]
        public bool? DynamicDns { get; set; }

        /// <summary>
        /// The per record password for a dynamic
        /// DNS update.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// The time to live or TTL of the record
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; set; }

        /// <summary>
        /// Indicates if System Monitoring is
        /// enabled for an A record
        /// </summary>
        [JsonProperty("monitor")]
        public bool? Monitor { get; set; }

        /// <summary>
        /// Indicates if DNS Failover is enabled for
        /// an A record.
        /// </summary>
        [JsonProperty("failover")]
        public bool? Failover { get; set; }

        /// <summary>
        /// Indicates if an A record is in failed
        /// status
        /// </summary>
        [JsonProperty("failed")]
        public bool? Failed { get; set; }

        /// <summary>
        /// Global Traffic Director location. Values:
        /// DEFAULT, US_EAST, US_WEST, EUROPE
        /// </summary>
        [JsonProperty("gtdLocation")]
        public string GtdLocation { get; set; }

        /// <summary>
        /// For HTTPRED records. A description of20
        /// the HTTPRED record.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// For HTTPRED records. Keywords
        /// associated with the HTTPRED record.
        /// </summary>
        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        /// <summary>
        /// For HTTPRED records. The title of the
        /// HTTPRED record.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// For HTTPRED records. Type of
        /// redirection performed. Values:
        /// Hidden Frame Masked, Standard – 302,
        /// Standard – 301
        /// </summary>
        [JsonProperty("redirectType")]
        public string RedirectType { get; set; }

        /// <summary>
        /// For HTTPRED records
        /// </summary>
        [JsonProperty("hardlink")]
        public bool? Hardlink { get; set; }

        /// <summary>
        /// The priority for an MX record
        /// </summary>
        [JsonProperty("mxLevel")]
        public int? MxLevel { get; set; }

        /// <summary>
        /// The weight for an SRV record
        /// </summary>
        [JsonProperty("weight")]
        public int? Weight { get; set; }

        /// <summary>
        /// The priority for an SRV record
        /// </summary>
        [JsonProperty("priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// The port for an SRV record
        /// </summary>
        [JsonProperty("port")]
        public int? Port { get; set; }
    }
}