using System;
using System.Threading.Tasks;

using DnsMadeEasy.Api.Models;

using RestEase;

namespace DnsMadeEasy.Api
{
    public interface IManagedRecord : IDisposable
    {
        [Get("/dns/managed/{domainId}/records")]
        Task<Response<PagedResult<ManagedRecord>>> GetRecords(string domainId);

        [Get("/dns/managed/{domainId}/records/{recordId}")]
        Task<Response<ManagedRecord>> GetRecord([Path] string domainId, [Path] string recordId);

        [Put("/dns/managed/{domainId}/records/{recordId}")]
        Task UpdateRecord([Path] string domainId, [Path] string recordId, [Body] ManagedRecord managedDomain);

        [Post("/dns/managed/{domainId}/records")]
        Task<Response<ManagedRecord>> CreateRecord([Path] string domainId, [Body] ManagedRecord managedDomain);

        [Delete("/dns/managed/{domainId}/records/{recordId}")]
        Task<Response<ManagedRecord>> DeleteRecord([Path] string domainId, [Path] string recordId);
    }
}