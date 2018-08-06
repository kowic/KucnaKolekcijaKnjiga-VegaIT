using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Mappings
{
    public static class NationalityMapper
    {
        public static NationalityViewModel ConvertToViewModel(this Nationality model)
        {
            Nationality m = model;
            NationalityViewModel viewModel = new NationalityViewModel();
            viewModel.NationalityId = model.Id;
            viewModel.Nationality = model.Name;

            return viewModel;
        }

        public static List<NationalityViewModel> ConvertToViewModelList(this List<Nationality> models)
        {
            List<Nationality> ma = models;
            List<NationalityViewModel> viewModels = new List<NationalityViewModel>();
            foreach (Nationality m in models)
            {
                viewModels.Add(m.ConvertToViewModel());
            }

            return viewModels;
        }

        public static Nationality ConvertToModel(this NationalityViewModel viewModel)
        {
            NationalityViewModel m = viewModel;
            Nationality model = new Nationality();
            if (viewModel.NationalityId != null)
                model.Id = Convert.ToInt32(viewModel.NationalityId);
            model.Name = viewModel.Nationality;

            return model;
        }
    }
}