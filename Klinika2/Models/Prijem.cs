using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klinika2.Models
{
    public class Prijem
    {
        public int Id { get; set; }

        [Display(Name = "Datum i vrijeme")]
        public DateTime DatumVrijeme { get; set; }


        public Patients Pacijent { get; set; }

        public Ljekar Ljekar { get; set; }

        public bool Hitno { get; set; }

        public Nalaz Nalaz { get; set; }

        public int LjekarId { get; set; }

        public int PacijentId { get; set; }
    }
}
