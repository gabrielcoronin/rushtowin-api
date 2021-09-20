using Microsoft.AspNetCore.Mvc;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var result = await _userService.Get(id);
            return Ok(result);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string fullName, string cpf, string email, string password)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                CPF = cpf,
                Email = email,
                Password = password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await _userService.Update(user);

            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Post(string fullName, string cpf, string email, string password)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                CPF = cpf,
                Email = email,
                Password = password,
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime()
            };

            var result = await _userService.Insert(user);

            return Ok();
        }      

    }
}
