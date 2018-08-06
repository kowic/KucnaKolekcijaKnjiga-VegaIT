using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels
{
    public class BookViewModel
    {
        [Display(Name = "ID")]
        public int? BookId { get; set; }

        [Display(Name = "Naslov")]
        [Required(ErrorMessage = "Naslov mora biti unet")]
        [StringLength(50, ErrorMessage = "Naslov mora biti kraći od 50 karaktera")]
        public string Title { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Žanr")]
        public int? GenreId { get; set; }
        public string GenreName { get; set; }

        [Display(Name = "Jezik")]
        [Required(ErrorMessage = "Jezik mora biti odabran")]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        [Display(Name = "Autori")]
        [Required(ErrorMessage = "Makar jedan autor mora biti odabran")]
        public List<int> AuthorIds { get; set; }

        public List<AuthorViewModel> Authors { get; set; }
    }
}