using Microsoft.AspNetCore.Mvc;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletsController(IWalletService walletService)
        {
            _walletService = walletService;            
        }

        // POST: api/Wallets
        [HttpPost]
        public async Task<ActionResult<Wallet>> Post(Wallet wallet)
        {
            var result = await _walletService.Insert(wallet);
            return Ok(result);
        }

        // GET: api/Wallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> Get(Guid id)
        {
            var result = await _walletService.Get(id);
            return Ok(result);
        }
        

        // PUT: api/Wallets/5
        [HttpPut]
        [Route("updateBalance")]
        public async Task<IActionResult> UpdateBalance(Wallet wallet)
        {
            var result = await _walletService.Update(wallet);
            return Ok(result);
        }
     
    }
}
