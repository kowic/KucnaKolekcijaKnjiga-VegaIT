using System.ComponentModel.DataAnnotations;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels
{
    public class LanguageViewModel
    {
        [Display(Name = "ID")]
        public int? LanguageId { get; set; }

        [Display(Name = "Jezik")]
        [Required(ErrorMessage = "Jezik mora biti unet")]
        [StringLength(50, ErrorMessage = "Tekst mora biti kraći od 50 karaktera")]
        public string Language { get; set; }
    }
}