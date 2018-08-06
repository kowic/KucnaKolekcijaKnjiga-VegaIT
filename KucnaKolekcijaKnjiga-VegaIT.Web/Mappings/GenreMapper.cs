using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Mappings
{
    public static class GenreMapper
    {
        public static GenreViewModel ConvertToViewModel(this Genre model)
        {
            GenreViewModel viewModel = new GenreViewModel();
            viewModel.GenreId = model.Id;
            viewModel.Genre = model.Name;

            return viewModel;
        }

        public static List<GenreViewModel> ConvertToViewModelList(this List<Genre> models)
        {
            List<GenreViewModel> viewModels = new List<GenreViewModel>();
            foreach (Genre m in models)
            {
                viewModels.Add(m.ConvertToViewModel());
            }

            return viewModels;
        }

        public static Genre ConvertToModel(this GenreViewModel viewModel)
        {
            Genre model = new Genre();
            if (viewModel.GenreId != null)
                model.Id = Convert.ToInt32(viewModel.GenreId);
            model.Name = viewModel.Genre;

            return model;
        }
    }
}