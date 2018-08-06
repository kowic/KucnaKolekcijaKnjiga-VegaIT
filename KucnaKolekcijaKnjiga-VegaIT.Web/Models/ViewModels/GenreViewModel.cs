using System.ComponentModel.DataAnnotations;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels
{
    public class GenreViewModel
    {
        [Display(Name = "ID")]
        public int? GenreId { get; set; }

        [Display(Name = "Žanr")]
        [Required(ErrorMessage = "Žanr mora biti unet")]
        [StringLength(50, ErrorMessage = "Tekst mora biti kraći od 50 karaktera")]
        public string Genre { get; set; }
    }
}