using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klinika2.Models
{
    public enum LjekarTitulaEnum
    {
        Specijalista, 
        Specijalizant,

        [Display(Name = "Medicinska Sestra")]
        MedicinskaSestra

    }
}
