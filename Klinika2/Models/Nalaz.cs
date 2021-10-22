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

        public string Opis { get; set; }

        public DateTime DatumVrijeme { get; set; }
    }
}
