using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klinika2.Models
{
    public class Ljekar
    {
        public int Id { get; set; }
        
        [StringLength(100, MinimumLength = 2), Required]
        public string Ime { get; set; }

        [StringLength(100, MinimumLength = 2), Required]
        public string Prezime { get; set; }

        [Required]
        public LjekarTitulaEnum Titula { get; set; }

        [Required]
        public string Sifra { get; set; }

        public ICollection<Prijem> Prijemi { get; set; }

    }
}
