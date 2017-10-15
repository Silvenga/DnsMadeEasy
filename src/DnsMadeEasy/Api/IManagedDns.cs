using System;
using System.Threading.Tasks;

using DnsMadeEasy.Converters;

using Newtonsoft.Json;

using RestEase;

namespace DnsMadeEasy.Api
{
    public class Domain
    {
        /// <summary>
        /// The domain name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The domain ID
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Name servers assigned to the domain by
        /// DNS Made Easy (System defined, unless
        /// vanity is applied)
        /// </summary>
        [JsonProperty("nameServers")]
        public string[] NameServers { get; set; }

        /// <summary>
        /// Indicator of whether or not this domain
        /// uses the Global Traffic Director service
        /// </summary>
        [JsonProperty("gtdEnabled")]
        public bool? GtdEnabled { get; set; }

        /// <summary>
        /// The ID of a custom SOA record
        /// </summary>
        [JsonProperty("soaID")]
        public long? SoaId { get; set; }

        /// <summary>
        /// The ID of a template applied to the domain
        /// </summary>
        [JsonProperty("templateId")]
        public long? TemplateId { get; set; }

        /// <summary>
        /// The ID of a vanity DNS configuration
        /// </summary>
        [JsonProperty("vanityId")]
        public long? VanityId { get; set; }

        /// <summary>
        /// The ID of an applied transfer ACL
        /// </summary>
        [JsonProperty("transferAclId")]
        public long? TransferAclId { get; set; }

        /// <summary>
        /// The ID of a domain folder
        /// </summary>
        [JsonProperty("folderId")]
        public long? FolderId { get; set; }

        /// <summary>
        /// The number of seconds since the domain
        /// was last updated in Epoch time
        /// </summary>
        [JsonProperty("updated")]
        [JsonConverter(typeof(EpochConverter))]
        public DateTimeOffset? Updated { get; set; }

        /// <summary>
        /// The number of seconds since the domain
        /// was last created in Epoch time
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(EpochConverter))]
        public DateTimeOffset? Created { get; set; }

        /// <summary>
        /// The list of servers defined in an applied
        /// AXFR ACL.
        /// </summary>
        [JsonProperty("axfrServer")]
        public string[] AxfrServer { get; set; }

        /// <summary>
        /// The name servers assigned to the domain
        /// at the registrar
        /// </summary>
        [JsonProperty("delegateNameServers")]
        public string[] DelegateNameServers { get; set; }

    }

    public interface IManagedDns
    {
        [Get("users/{userId}")]
        Task<Domain> GetUserAsync([Path] string userId);
    }
}