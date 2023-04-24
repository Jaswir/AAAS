using AAAS.Data;
using AAAS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AAAS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutiQuotesController : ControllerBase
    {
        public AAAS_DbContext dbContext { get; }

        public AutiQuotesController(AAAS_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //api/v1/images/random
        //Return a random images
        [HttpGet("random")]
        public async Task<ActionResult<AutiQuote>> GetRandom()
        {
            Random rand = new Random();
            int skipper = rand.Next(0, dbContext.Auti_Quotes.Count());

            var randomCatImages = await dbContext
                .Auti_Quotes
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(1).ToListAsync();

            return randomCatImages[0];
        }

        //api/v1/images/random10
        //Return 10 random images
        [HttpGet("random10")]
        
        public async Task<ActionResult<IEnumerable<AutiQuote>>> GetRandom10()
        {
            Random rand = new Random();
            int skipper = rand.Next(0, dbContext.Auti_Quotes.Count());

            return await dbContext
                .Auti_Quotes
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(10)
                .ToListAsync();
        }

    }
}
