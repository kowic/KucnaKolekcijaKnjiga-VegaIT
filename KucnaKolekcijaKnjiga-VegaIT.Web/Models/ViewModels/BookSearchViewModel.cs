
using System.ComponentModel.DataAnnotations;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels
{
    public class BookSearchViewModel
    {
        [Display(Name = "Naslov")]
        public string TitleSearch { get; set; }
        [Display(Name = "ISBN")]
        public string ISBNSearch { get; set; }
        [Display(Name = "Autori")]
        public int? AuthorSearch { get; set; }
        [Display(Name = "Žanrovi")]
        public int? GenreSearch { get; set; }
        [Display(Name = "Jezici")]
        public int? LanguageSearch { get; set; }
    }
}