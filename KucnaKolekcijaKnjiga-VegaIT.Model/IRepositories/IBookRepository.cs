using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        void Create(Book entity);
        void Update(Book entity);
        void Delete(int id);
        List<string> GetAllISBNs();
    }
}
