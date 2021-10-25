using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klinika2.Models

{
    public class Patients
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3), Required]
        public string ImePrezime { get; set; }

        [Display(Name = "Datum Rođenja")]
        [DataType(DataType.Date), Required]
        public DateTime DatumRodjenja { get; set; }
        
        [Required]
        public PatientGenderEnum Spol { get; set; }

        public string Adresa { get; set; }

        [RegularExpression("^[0-9]{4,10}$",
        ErrorMessage = "Molimo unesite samo brojeve")]
        public string BrojTelefona { get; set; }

        public ICollection<Prijem> Prijemi { get; set; }


    }
}
