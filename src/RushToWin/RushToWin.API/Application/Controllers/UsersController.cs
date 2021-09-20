using Microsoft.AspNetCore.Mvc;
using RushToWin.API.Application.Models;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Application.Controllers
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

        [HttpGet()]
        public async Task<ActionResult<User>> Get([FromQuery] Guid id)
        {
            var result = await _userService.Get(id);
            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserInsertModel model)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                CPF = model.CPF,
                Email = model.Email,
                Password = model.Password,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var result = await _userService.Insert(user);

            return Ok(result);
        }

        // PUT: api/Users/5
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel model)
        {
            var user = new User()
            {
                Id = Guid.Parse(model.Id),
                FullName = model.FullName,
                CPF = model.CPF,
                Email = model.Email,
                Password = model.Password,
                UpdatedAt = DateTime.UtcNow,
            };

            var result = await _userService.Update(user);

            return Ok(result);
        }

      
    }
}
