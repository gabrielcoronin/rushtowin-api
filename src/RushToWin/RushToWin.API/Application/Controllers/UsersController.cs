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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var result = await _userService.Get(id);
            return Ok(result);
        }

        [HttpGet()]
        [Route("login/{email}/{password}")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {    
            var result = await _userService.Login(email, password);

            if (result == null) return BadRequest();

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

            if (!result.Success) return BadRequest(result.Messages);

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

        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePassword model)
        {
            var result = await _userService.UpdatePassword(Guid.Parse(model.Id), model.Password);

            return Ok(result);
        }


    }
}
