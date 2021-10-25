using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klinika2.Models
{
    public class Nalaz
    {
       // public int Id { get; set; }

        [Key]
        public int PrijemID { get; set; }

        [Required]
        public string Opis { get; set; }

        [Display(Name ="Vrijeme kreiranja")]
        public DateTime DatumVrijeme { get; set; }

        public Prijem Prijem { get; set; }
    }
}
