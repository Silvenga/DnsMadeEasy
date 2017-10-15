using System.Collections.Generic;

using Newtonsoft.Json;

namespace DnsMadeEasy.Api.Models
{
    public class PagedResult<T>
    {
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty("data")]
        public ICollection<T> Data { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }
    }
}