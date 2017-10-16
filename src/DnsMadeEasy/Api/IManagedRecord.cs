using System;
using System.Threading.Tasks;

using DnsMadeEasy.Api.Models;

using RestEase;

namespace DnsMadeEasy.Api
{
    public interface IManagedRecord : IDisposable
    {
        [Get("/dns/managed/{domainId}/records")]
        Task<Response<PagedResult<ManagedRecord>>> GetRecords([Path] long? domainId);

        [Get("/dns/managed/{domainId}/records/{recordId}")]
        Task<Response<ManagedRecord>> GetRecord([Path] long? domainId, [Path] long? recordId);

        [Put("/dns/managed/{domainId}/records/{recordId}")]
        Task UpdateRecord([Path] long? domainId, [Path] long? recordId, [Body] ManagedRecord managedDomain);

        [Post("/dns/managed/{domainId}/records")]
        Task<Response<ManagedRecord>> CreateRecord([Path] long? domainId, [Body] ManagedRecord managedDomain);

        [Delete("/dns/managed/{domainId}/records/{recordId}")]
        Task<Response<ManagedRecord>> DeleteRecord([Path] long? domainId, [Path] long? recordId);
    }
}