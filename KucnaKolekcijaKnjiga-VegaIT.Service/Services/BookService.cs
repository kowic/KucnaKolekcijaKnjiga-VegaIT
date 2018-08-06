using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace KucnaKolekcijaKnjiga_VegaIT.Service.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        public void CreateBook(Book entity)
        {
            _bookRepository.Create(entity);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public List<Book> FindBooks(BookSearch entity)
        {
            List<Book> books = _bookRepository.GetAll();

            if (!String.IsNullOrEmpty(entity.TitleSearch))
                books = books.Where(x => x.Title.Contains(entity.TitleSearch)).ToList();

            if (!String.IsNullOrEmpty(entity.ISBNSearch))
                books = books.Where(x => x.ISBN.Contains(entity.ISBNSearch)).ToList();

            if (entity.AuthorSearch != null)
                books = books.Where(x => x.Authors.Any(y => y.Id == entity.AuthorSearch)).ToList();

            if (entity.LanguageSearch != null)
                books = books.Where(x => x.Language.Id == entity.LanguageSearch).ToList();

            if (entity.GenreSearch != null)
                books = books.Where(x => x.Genre != null).Where(x => x.Genre.Id == entity.GenreSearch).ToList();

            return books;
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public bool IsUniqueISBN(string isbn, int id = 0)
        {
            if (string.IsNullOrEmpty(isbn))
                return true;
            if (id != 0)
                if (_bookRepository.GetById(id).ISBN.Equals(isbn))
                    return true;
            return !_bookRepository.GetAllISBNs().Contains(isbn);
        }

        public void UpdateBook(Book entity)
        {
            _bookRepository.Update(entity);
        }
    }
}
