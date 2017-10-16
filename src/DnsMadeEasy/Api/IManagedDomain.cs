using System;
using System.Threading.Tasks;

using DnsMadeEasy.Api.Models;

using RestEase;

namespace DnsMadeEasy.Api
{
    public interface IManagedDomain : IDisposable
    {
        [Get("/dns/managed/")]
        Task<PagedResult<ManagedDomain>> GetDomains();

        [Get("/dns/managed/name")]
        Task<ManagedDomain> GetDomainByName([Query("domainname")] string domainName);

        [Get("/dns/managed/{domainId}")]
        Task<ManagedDomain> GetDomain([Path] long? domainId);

        [Put("/dns/managed/{domainId}")]
        Task UpdateDomain([Path] long? domainId, [Body] ManagedDomain managedDomain);

        [Post("/dns/managed/")]
        Task<ManagedDomain> CreateDomain([Body] ManagedDomain managedDomain);

        [Delete("/dns/managed/{domainId}")]
        Task<ManagedDomain> DeleteDomain([Path] string domainId);
    }
}