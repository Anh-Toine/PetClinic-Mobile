using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetClinic.Models;

namespace PetClinic.Services.NetworkService
{
    public sealed class NetworkService : INetworkService<HttpResponseMessage>
    {
        private HttpClient httpClient;
        private static readonly Lazy<NetworkService> lazy = new Lazy<NetworkService>(() => new NetworkService());


        private NetworkService()
        {
            httpClient = new HttpClient();
        }

        public static NetworkService Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            string serialized = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;

            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",);

            //return response;
        }

        public async Task<HttpResponseMessage> LoginAsync(string uri, string email, string password)
        {
            Dictionary<string, string> user = new Dictionary<string, string>()
            {
                {"email",email},
                {"password",password}
            };
            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                HttpHeaders headers = response.Headers;
                IEnumerable<string> values;
                if (headers.TryGetValues("Authorization", out values))
                {
                    var jwt = values.First();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

                }

            }
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync<TResult>(string uri, Owner owner)
        {
           
            var json = JsonConvert.SerializeObject(owner);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);
            //if (response.IsSuccessStatusCode)
            //{
            //   await 
            //}
            return response;
        }

        
    }
}
