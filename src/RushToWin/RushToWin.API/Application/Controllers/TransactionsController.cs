using Microsoft.AspNetCore.Mvc;
using RushToWin.API.Application.Models;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("recharge")]
        public async Task<ActionResult<Transaction>> Recharge([FromBody] RechargeModel model)
        {
            await _transactionService.Recharge(model.Value, model.WalletId);
            return Ok();
        }

        [HttpPost]
        [Route("bus/{walletId}")]
        public async Task<ActionResult<Transaction>> Bus(string walletId)
        {
            var result = await _transactionService.Bus(Guid.Parse(walletId));

            if (!result.Success) return BadRequest(result.Messages);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("subway/{walletId}")]
        public async Task<ActionResult<Transaction>> Subway(string walletId)
        {
            var result = await _transactionService.Subway(Guid.Parse(walletId));

            if (!result.Success) return BadRequest(result.Messages);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("train/{walletId}")]
        public async Task<ActionResult<Transaction>> Train(string walletId)
        {
            var result = await _transactionService.Train(Guid.Parse(walletId));

            if (!result.Success) return BadRequest(result.Messages);

            return Ok(result.Data);
        }


        [HttpGet("{walletId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> List(string walletId)
        {
            var result = await _transactionService.List(Guid.Parse(walletId));
            return Ok(result);
        }

        [HttpGet("getWallet/{walletId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetWallet(string walletId)
        {
            var result = await _transactionService.Get(Guid.Parse(walletId));
            return Ok(result);
        }

        [HttpGet("lastTransaction/{walletId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> LastTransaction(string walletId)
        {
            var result = await _transactionService.GetLastTransaction(Guid.Parse(walletId));
            return Ok(result);
        }
    }
}
