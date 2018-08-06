using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Mappings
{
    public static class AuthorMapper
    {
        public static AuthorViewModel ConvertToViewModel(this Author model)
        {
            AuthorViewModel viewModel = new AuthorViewModel();
            viewModel.AuthorId = model.Id;
            viewModel.Name = model.Name;
            if (model.Nationality != null)
            {
                viewModel.NationalityId = model.Nationality.Id;
                viewModel.NationalityName = model.Nationality.Name;
            }

            return viewModel;
        }

        public static List<AuthorViewModel> ConvertToViewModelList(this List<Author> models)
        {
            List<AuthorViewModel> viewModels = new List<AuthorViewModel>();
            foreach (Author m in models)
            {
                viewModels.Add(m.ConvertToViewModel());
            }

            return viewModels;
        }

        public static Author ConvertToModel(this AuthorViewModel viewModel)
        {
            Author model = new Author();
            if (viewModel.AuthorId != null)
                model.Id = Convert.ToInt32(viewModel.AuthorId);
            model.Name = viewModel.Name;
            if (viewModel.NationalityId != null)
                model.Nationality = new Nationality() { Id = Convert.ToInt32(viewModel.NationalityId)};

            return model;
        }
    }
}