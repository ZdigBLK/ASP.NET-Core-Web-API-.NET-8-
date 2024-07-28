using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StocksCtrl : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public StocksCtrl(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Stocks = _context.Stocks.ToList();

            return Ok(Stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Stock = _context.Stocks.Find(id);

            if(Stock == null) 
            {
                return NotFound();
            }

            return Ok(Stock);
        }
    }
}