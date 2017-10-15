using System.Threading.Tasks;

using DnsMadeEasy.Api.Models;

using RestEase;

namespace DnsMadeEasy.Api
{
    public interface IManagedDns
    {
        [Get("/dns/managed/")]
        Task<Response<PagedResult<ManagedDomain>>> GetDomains();

        [Get("/dns/managed/name")]
        Task<Response<ManagedDomain>> GetDomainByName([Query("domainname")] string domainName);

        [Get("/dns/managed/{domainId}")]
        Task<Response<ManagedDomain>> GetDomain([Path] string domainId);

        [Put("/dns/managed/{domainId}")]
        Task UpdateDomain([Path] string domainId, [Body] ManagedDomain managedDomain);

        [Post("/dns/managed/")]
        Task<Response<ManagedDomain>> CreateDomain([Body] ManagedDomain managedDomain);

        [Delete("/dns/managed/{domainId}")]
        Task<Response<ManagedDomain>> DeleteDomain([Path] string domainId);
    }
}