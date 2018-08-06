using System.Web.Mvc;
using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels;
using KucnaKolekcijaKnjiga_VegaIT.Web.Mappings;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Controllers
{
    public class LanguageController : Controller
    {
        private static ILanguageService _languageService;

        public LanguageController(ILanguageService service)
        {
            _languageService = service;
        }

        public ActionResult Index()
        {
            LanguageListPageViewModel model = new LanguageListPageViewModel();
            model.LanguageViewModels = _languageService.GetAllLanguages().ConvertToViewModelList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LanguageSinglePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _languageService.CreateLanguage(model.LanguageViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            LanguageSinglePageViewModel model = new LanguageSinglePageViewModel();
            model.LanguageViewModel = _languageService.GetLanguageById(id).ConvertToViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LanguageSinglePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _languageService.UpdateLanguage(model.LanguageViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _languageService.DeleteLanguage(id);
            return RedirectToAction("Index");
        }
    }
}