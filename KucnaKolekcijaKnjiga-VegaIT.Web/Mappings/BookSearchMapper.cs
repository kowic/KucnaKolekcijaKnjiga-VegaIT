using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Mappings
{
    public static class BookSearchMapper
    {
        public static BookSearch ConvertToModel(this BookSearchViewModel viewModel)
        {
            BookSearch model = new BookSearch();

            model.TitleSearch = viewModel.TitleSearch;
            model.ISBNSearch = viewModel.ISBNSearch;
            model.AuthorSearch = viewModel.AuthorSearch;
            model.LanguageSearch = viewModel.LanguageSearch;
            model.GenreSearch = viewModel.GenreSearch;

            return model;
        }
    }
}