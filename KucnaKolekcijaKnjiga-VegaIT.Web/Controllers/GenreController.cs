using System.Web.Mvc;
using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels;
using KucnaKolekcijaKnjiga_VegaIT.Web.Mappings;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Controllers
{
    public class GenreController : Controller
    {
        private static IGenreService _genreService;

        public GenreController(IGenreService service)
        {
            _genreService = service;
        }

        public ActionResult Index()
        {
            GenreListPageViewModel model = new GenreListPageViewModel();
            model.GenreViewModels = _genreService.GetAllGenres().ConvertToViewModelList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreSinglePageViewModel model)
        {
            if(ModelState.IsValid)
            {
                _genreService.CreateGenre(model.GenreViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            GenreSinglePageViewModel model = new GenreSinglePageViewModel();
            model.GenreViewModel = _genreService.GetGenreById(id).ConvertToViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenreSinglePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _genreService.UpdateGenre(model.GenreViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _genreService.DeleteGenre(id);
            return RedirectToAction("Index");
        }
    }
}