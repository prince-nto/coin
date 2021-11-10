using CoinJar.Interfaces;
using CoinJar.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoinJar.Controllers
{
    [Route("api/coin")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {
        private readonly CoinJarService _coinJarService;
        
        public CoinJarController()
        {
            _coinJarService = new CoinJarService();
        }

        [HttpGet]
        public IActionResult GetTotalAmount()
        {
            return Ok(_coinJarService.GetTotalAmount());
        }


        [HttpPost]
        public string AddCoin([FromBody] ICoin coin)
        {
            _coinJarService.AddCoin(coin);
            return "Coin added to the jar";
        }

        [HttpPut]
        public IActionResult ResetJar()
        {
            _coinJarService.Reset();
            return Ok();
        }
    }
}
