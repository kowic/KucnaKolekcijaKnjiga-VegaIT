using System.Web.Mvc;
using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.PageViewModels;
using KucnaKolekcijaKnjiga_VegaIT.Web.Mappings;
using KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels;
using System;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Controllers
{
    public class BookController : Controller
    {
        private static IBookService _bookService;
        private static IAuthorService _authorService;
        private static ILanguageService _languageService;
        private static IGenreService _genreService;

        public BookController(IBookService bService, IAuthorService aService, ILanguageService lService, IGenreService gService)
        {
            _bookService = bService;
            _authorService = aService;
            _languageService = lService;
            _genreService = gService;
        }

        public ActionResult Index()
        {
            BookListPageViewModel model = new BookListPageViewModel();
            model.BookViewModels = _bookService.GetAllBooks().ConvertToViewModelList();

            model.AuthorList = _authorService.GetAllAuthors().ConvertToViewModelList();
            model.AuthorList.Insert(0, new AuthorViewModel() { AuthorId = null, Name = "Odaberite autora" });
            model.LanguageList = _languageService.GetAllLanguages().ConvertToViewModelList();
            model.LanguageList.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            model.GenreList = _genreService.GetAllGenres().ConvertToViewModelList();
            model.GenreList.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite žanr" });

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(BookListPageViewModel model)
        {
            BookListPageViewModel newModel = new BookListPageViewModel();
            newModel.BookViewModels = _bookService.FindBooks(model.BookSearchViewModel.ConvertToModel()).ConvertToViewModelList();

            newModel.AuthorList = _authorService.GetAllAuthors().ConvertToViewModelList();
            newModel.AuthorList.Insert(0, new AuthorViewModel() { AuthorId = null, Name = "Odaberite autora" });
            newModel.LanguageList = _languageService.GetAllLanguages().ConvertToViewModelList();
            newModel.LanguageList.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            newModel.GenreList = _genreService.GetAllGenres().ConvertToViewModelList();
            newModel.GenreList.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite žanr" });

            return View(newModel);
        }

        public ActionResult Details(int id)
        {
            BookSinglePageViewModel model = new BookSinglePageViewModel();
            model.BookViewModel = _bookService.GetBookById(id).ConvertToViewModel();
            return View(model);
        }

        public ActionResult Create()
        {
            BookSinglePageViewModel model = new BookSinglePageViewModel();
            model.AuthorList = _authorService.GetAllAuthors().ConvertToViewModelList();

            model.LanguageList = _languageService.GetAllLanguages().ConvertToViewModelList();
            model.LanguageList.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            model.GenreList = _genreService.GetAllGenres().ConvertToViewModelList();
            model.GenreList.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite žanr" });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookSinglePageViewModel model)
        {
            bool isbnValidationResult = _bookService.IsUniqueISBN(model.BookViewModel.ISBN);
            if (ModelState.IsValid && isbnValidationResult)
            {
                _bookService.CreateBook(model.BookViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }
            if (!isbnValidationResult)
                ModelState.AddModelError("", "");

            model.AuthorList = _authorService.GetAllAuthors().ConvertToViewModelList();
            model.LanguageList = _languageService.GetAllLanguages().ConvertToViewModelList();
            model.LanguageList.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            model.GenreList = _genreService.GetAllGenres().ConvertToViewModelList();
            model.GenreList.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite žanr" });

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            BookSinglePageViewModel model = new BookSinglePageViewModel();
            model.BookViewModel = _bookService.GetBookById(id).ConvertToViewModel();

            model.AuthorList = _authorService.GetAllAuthors().ConvertToViewModelList();
            model.LanguageList = _languageService.GetAllLanguages().ConvertToViewModelList();
            model.LanguageList.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            model.GenreList = _genreService.GetAllGenres().ConvertToViewModelList();
            model.GenreList.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite žanr" });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookSinglePageViewModel model)
        {
            int id = Convert.ToInt32(model.BookViewModel.BookId);
            bool isbnValidationResult = _bookService.IsUniqueISBN(model.BookViewModel.ISBN, id);
            if (ModelState.IsValid && isbnValidationResult)
            {
                _bookService.UpdateBook(model.BookViewModel.ConvertToModel());
                return RedirectToAction("Index");
            }
            if (!isbnValidationResult)
                ModelState.AddModelError("", "Već postoji uneti ISBN");

            model.AuthorList = _authorService.GetAllAuthors().ConvertToViewModelList();
            model.LanguageList = _languageService.GetAllLanguages().ConvertToViewModelList();
            model.LanguageList.Insert(0, new LanguageViewModel() { LanguageId = null, Language = "Odaberite jezik" });
            model.GenreList = _genreService.GetAllGenres().ConvertToViewModelList();
            model.GenreList.Insert(0, new GenreViewModel() { GenreId = null, Genre = "Odaberite žanr" });

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}