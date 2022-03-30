using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpDemo.HTTPCRUDServices
{
    public class HTTPUserClient : IHTTPUserClient
    {
        private readonly RestClient _client;
        private readonly string _url;
        public HTTPUserClient()
        {
            _url = "https://jsonplaceholder.typicode.com/users";
            var options = new RestClientOptions(_url);
            _client = new RestClient(options);

            //_client.Authenticator = new HttpBasicAuthenticator("admin", "1234");
        }

        public async Task<List<User>> GetAllUsers()
        {
            var request = new RestRequest();

            var response = await _client.GetAsync<List<User>>(request);

            return response;
        }

        public async Task<User> GetUserById(int id)
        {
            var request = new RestRequest($"/{id}");

            var response = await _client.GetAsync<User>(request);

            return response;
        }

        public async Task<User> Create(User user)
        {
            var request = new RestRequest()
                              .AddJsonBody<User>(user);

            var response =await  _client.PostAsync<User>(request);

            return response;
        }

        public async Task<User> Update(User user)
        {
            var request = new RestRequest()
                             .AddJsonBody<User>(user);

            var response = await _client.PutAsync<User>(request);

            return response;
        }

        public async Task Delete(int id)
        {
            var request = new RestRequest()
                            .AddQueryParameter<int>("Id", id);
            // https://jsonplaceholder.typicode.com/users?id=12

           await _client.DeleteAsync(request);
        }

    }
}
