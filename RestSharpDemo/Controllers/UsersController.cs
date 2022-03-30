using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharpDemo.HTTPCRUDServices;
using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestSharpDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHTTPUserClient _client;

        public UsersController(IHTTPUserClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.GetAllUsers();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _client.GetUserById(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var user = new User
            {
                Name = "basel alalami",
                Email = "b.alalami@test.com",
                Username = "baselalalami"
            };
            var response = await _client.Create(user);

            return Ok(response);
        }
    }
}
