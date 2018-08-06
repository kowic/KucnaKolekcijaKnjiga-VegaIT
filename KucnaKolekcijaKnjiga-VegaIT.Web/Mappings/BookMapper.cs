using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Mappings
{
    public static class BookMapper
    {
        public static BookViewModel ConvertToViewModel(this Book model)
        {
            BookViewModel viewModel = new BookViewModel();
            viewModel.BookId = model.Id;
            viewModel.Title = model.Title;
            viewModel.ISBN = model.ISBN;
            viewModel.Description = model.Description;
            viewModel.LanguageId = model.Language.Id;
            viewModel.LanguageName = model.Language.Name;
            if (model.Genre != null)
            {
                viewModel.GenreId = model.Genre.Id;
                viewModel.GenreName = model.Genre.Name;
            }
            viewModel.Authors = model.Authors.ConvertToViewModelList();

            return viewModel;
        }

        public static List<BookViewModel> ConvertToViewModelList(this List<Book> models)
        {
            List<BookViewModel> viewModels = new List<BookViewModel>();
            foreach (Book m in models)
            {
                viewModels.Add(m.ConvertToViewModel());
            }

            return viewModels;
        }

        public static Book ConvertToModel(this BookViewModel viewModel)
        {
            Book model = new Book();
            if (viewModel.BookId != null)
                model.Id = Convert.ToInt32(viewModel.BookId);
            model.Title = viewModel.Title;
            model.ISBN = viewModel.ISBN;
            model.Description = viewModel.Description;
            model.Language = new Language() { Id = Convert.ToInt32(viewModel.LanguageId) };
            if (viewModel.GenreId != null)
                model.Genre = new Genre() { Id = Convert.ToInt32(viewModel.GenreId) };
            model.Authors = new List<Author>();
            foreach (int id in viewModel.AuthorIds)
                model.Authors.Add(new Author() { Id = id});

            return model;
        }
    }
}