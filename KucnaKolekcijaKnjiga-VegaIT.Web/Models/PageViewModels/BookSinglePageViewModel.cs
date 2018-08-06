using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels
{
    public class BookSinglePageViewModel
    {
        public BookViewModel BookViewModel { get; set; }

        public List<GenreViewModel> GenreList { get; set; }
        public List<LanguageViewModel> LanguageList { get; set; }
        public List<AuthorViewModel> AuthorList { get; set; }
    }
}