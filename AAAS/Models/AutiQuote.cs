using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AAAS.Models
{
    public class AutiQuote
    {
        public string id { get;set; }
        public string Author { get; set; }
        public string Quote { get; set; }

        public Feeling Relatable_Feeling { get; set; }

        public enum Feeling
        {
           Like_I_am_not_good_how_I_am,
           Like_I_have_bad_social_skills,
           Misunderstood
        }
      

    }
}
