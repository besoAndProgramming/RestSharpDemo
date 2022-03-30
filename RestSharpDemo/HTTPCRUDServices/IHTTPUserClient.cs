using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestSharpDemo.HTTPCRUDServices
{
    public interface IHTTPUserClient
    {
        // GetAll, GetById, Create, Update, Delete
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Delete(int id);
    }
}
