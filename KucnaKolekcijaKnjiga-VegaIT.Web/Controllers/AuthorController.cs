using System.Web.Mvc;
using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels;
using KucnaKolekcijaKnjiga_VegaIT.Web.Mappings;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Controllers
{
    public class AuthorController : Controller
    {
        private static IAuthorService _authorService;
        private static INationalityService _nationalityService;

        public AuthorController(IAuthorService aService, INationalityService nService)
        {
            _authorService = aService;
            _nationalityService = nService;
        }

        public ActionResult Index()
        {
            AuthorListPageViewModel model = new AuthorListPageViewModel();
            model.AuthorViewModels = _authorService.GetAllAuthors().ConvertToViewModelList();
            return View(model);
        }

        public ActionResult Create()
        {
            AuthorSinglePageViewModel model = new AuthorSinglePageViewModel();
            model.NationalityList = _nationalityService.GetAllNationalities().ConvertToViewModelList();
            model.NationalityList.Insert(0, new NationalityViewModel() { NationalityId = null, Nationality = "Odaberite nacionalnost" });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorSinglePageViewModel model)
        {
            bool st = ModelState.IsValid;
            AuthorSinglePageViewModel m = model;
            if (ModelState.IsValid)
            {
                _authorService.CreateAuthor(model.AuthorViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            model.NationalityList = _nationalityService.GetAllNationalities().ConvertToViewModelList();
            model.NationalityList.Insert(0, new NationalityViewModel() { NationalityId = null, Nationality = "Odaberite nacionalnost" });
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            AuthorSinglePageViewModel model = new AuthorSinglePageViewModel();
            model.AuthorViewModel = _authorService.GetAuthorById(id).ConvertToViewModel();

            model.NationalityList = _nationalityService.GetAllNationalities().ConvertToViewModelList();
            model.NationalityList.Insert(0, new NationalityViewModel() { NationalityId = null, Nationality = "Odaberite nacionalnost" });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorSinglePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(model.AuthorViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            model.NationalityList = _nationalityService.GetAllNationalities().ConvertToViewModelList();
            model.NationalityList.Insert(0, new NationalityViewModel() { NationalityId = null, Nationality = "Odaberite nacionalnost" });
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}