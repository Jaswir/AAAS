using AAAS.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AAAS.Data
{
    public class Seeder
    {
        public async void Seed(AAAS_DbContext aaasDbContext)
        {
            //Reads in AutiQuote Data from json file 
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "inspiring_auti_quotes.json");
            string autiQuotes_JSON = System.IO.File.ReadAllText(path);
            List<AutiQuote> autiQuotesList = JsonConvert.DeserializeObject<List<AutiQuote>>(autiQuotes_JSON);

            //Seeds AutiQuote Data incase table is empty
            var autiQuotesEmpty = !aaasDbContext.Auti_Quotes.Any();
            if (!autiQuotesEmpty) return;

            await aaasDbContext.AddRangeAsync(
                autiQuotesList);

            await aaasDbContext.SaveChangesAsync();

    
        }

    }
}
