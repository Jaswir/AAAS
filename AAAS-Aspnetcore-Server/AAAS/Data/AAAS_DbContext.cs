using AAAS.Models;
using Microsoft.EntityFrameworkCore;

namespace AAAS.Data
{
    public class AAAS_DbContext: DbContext
    {

        public AAAS_DbContext(DbContextOptions<AAAS_DbContext> options)
            : base(options)
        {
        }

        public DbSet<AutiQuote> Auti_Quotes { get; set; }

    }
}
