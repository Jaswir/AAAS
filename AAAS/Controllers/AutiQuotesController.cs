using AAAS.Data;
using AAAS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static AAAS.Models.AutiQuote;

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

        // api/v1/AutiQuotes
        // Returns list of all quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutiQuote>>> Get()
        {
            var quotes = await dbContext.Auti_Quotes.ToListAsync();
            return quotes;
        }


        //api/v1/AutiQuotes/random
        //Return a random images
        [HttpGet("random")]
        public async Task<ActionResult<AutiQuote>> GetRandom()
        {
            Random rand = new Random();
            int skipper = rand.Next(0, dbContext.Auti_Quotes.Count());

            var randomQuote = await dbContext
                .Auti_Quotes
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(1).ToListAsync();

            return randomQuote[0];
        }

        //api/v1/AutiQuotes/random/relatable_feeling
        //Return a random images
        [HttpGet("random/relatable_feeling/{relatable_feeling}")]
        public async Task<ActionResult<AutiQuote>> GetRandomRelatableFeeling(Feeling relatable_feeling)
        {
            Random rand = new Random();
            int skipper = rand.Next(0, 
                dbContext.Auti_Quotes
                .Where(x => x.Relatable_Feeling == relatable_feeling)
                .Count());

            var randomQuote = await dbContext
                .Auti_Quotes           
                .Where(x => x.Relatable_Feeling == relatable_feeling)
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(1).ToListAsync();

            return randomQuote[0];
        }

    }
}
