using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AAAS.Models
{
    public class AutiQuote
    {
        [Key]
        public string Author { get; set; }
        public string Quote { get; set; }

      

    }
}
