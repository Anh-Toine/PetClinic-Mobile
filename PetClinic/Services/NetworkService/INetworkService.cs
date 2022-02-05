using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PetClinic.Models;

namespace PetClinic.Services.NetworkService
{
    public interface INetworkService<T> where T : HttpResponseMessage, new()
    {
        Task<TResult> GetAsync<TResult>(string uri);
        Task<HttpResponseMessage> PostAsync<TResult>(string uri,Owner owner);
        Task<HttpResponseMessage> LoginAsync(string uri,string email,string password);
    }
}
