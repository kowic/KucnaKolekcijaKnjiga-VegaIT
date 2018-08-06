using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels
{
    public class AuthorSinglePageViewModel
    {
        public AuthorViewModel AuthorViewModel { get; set; }
        public List<NationalityViewModel> NationalityList { get; set; }
    }
}