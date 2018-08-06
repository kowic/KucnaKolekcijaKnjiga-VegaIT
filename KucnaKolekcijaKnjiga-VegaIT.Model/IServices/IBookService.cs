using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IServices
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book entity);
        void UpdateBook(Book entity);
        void DeleteBook(int id);
        List<Book> FindBooks(BookSearch entity);
        bool IsUniqueISBN(string isbn, int id = 0);
    }
}
