using System.ComponentModel.DataAnnotations;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels
{
    public class NationalityViewModel
    {
        [Display(Name = "ID")]
        public int? NationalityId { get; set; }

        [Display(Name = "Nacionalnost")]
        [Required(ErrorMessage = "Nacionalnost mora biti uneta")]
        [StringLength(50, ErrorMessage = "Tekst mora biti kraći od 50 karaktera")]
        public string Nationality { get; set; }
    }
}