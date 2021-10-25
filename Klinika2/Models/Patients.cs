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

        [Display(Name = "Ime i Prezime")]
        [StringLength(100, MinimumLength = 3), Required]
        public string ImePrezime { get; set; }

        [Display(Name = "Datum Rođenja")]
        [DataType(DataType.Date), Required]
        public DateTime DatumRodjenja { get; set; }
        
        [Required]
        public PatientGenderEnum Spol { get; set; }

        public string Adresa { get; set; }

        [Display(Name = "Broj Telefona")]
        [Phone(ErrorMessage = "Molimo unesite validan broj telefona")]
        public string BrojTelefona { get; set; }

        public ICollection<Prijem> Prijemi { get; set; }


    }
}
