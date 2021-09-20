using Microsoft.AspNetCore.Mvc;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Controllers
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
        public async Task<ActionResult<Transaction>> Recharge(double value, Guid walletId)
        {
            var result = await _transactionService.Recharge(value, walletId);
            return Ok(result);
        }

        [HttpPost]
        [Route("bus")]
        public async Task<ActionResult<Transaction>> Bus(Guid walletId)
        {
            var result = await _transactionService.Bus(walletId);
            return Ok(result);
        }

        [HttpPost]
        [Route("subway")]
        public async Task<ActionResult<Transaction>> Subway(Guid walletId)
        {
            var result = await _transactionService.Subway(walletId);
            return Ok(result);
        }

        [HttpPost]
        [Route("train")]
        public async Task<ActionResult<Transaction>> Train(Guid walletId)
        {
            var result = await _transactionService.Train(walletId);
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> List(Guid walletId)
        {
            var result = await _transactionService.List(walletId);
            return Ok(result);
        }


    }
}
