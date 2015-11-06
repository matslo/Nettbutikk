using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikken.Model
{
    public class Kunde
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Brukernavn")]
        public string Brukernavn { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email er ikke gyldig")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Passordet må være minst seks tegn", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passord")]
        public string Passord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekreft Passord")]
        [Compare("Passord", ErrorMessage = "Passordene er ikke like.")]
        public string BekreftPassord { get; set; }
    }
}
