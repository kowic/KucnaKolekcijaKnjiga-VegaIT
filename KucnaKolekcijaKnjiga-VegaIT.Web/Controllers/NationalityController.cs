using System.Web.Mvc;
using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels;
using KucnaKolekcijaKnjiga_VegaIT.Web.Mappings;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Controllers
{
    public class NationalityController : Controller
    {
        private static INationalityService _nationalityService;

        public NationalityController(INationalityService service)
        {
            _nationalityService = service;
        }

        public ActionResult Index()
        {
            NationalityListPageViewModel model = new NationalityListPageViewModel();
            model.NationalityViewModels = _nationalityService.GetAllNationalities().ConvertToViewModelList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NationalitySinglePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _nationalityService.CreateNationality(model.NationalityViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            NationalitySinglePageViewModel model = new NationalitySinglePageViewModel();
            model.NationalityViewModel = _nationalityService.GetNationalityById(id).ConvertToViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NationalitySinglePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _nationalityService.UpdateNationality(model.NationalityViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _nationalityService.DeleteNationality(id);
            return RedirectToAction("Index");
        }
    }
}