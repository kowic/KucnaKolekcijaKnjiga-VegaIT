using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(int id);
        void Create(Author entity);
        void Update(Author entity);
        void Delete(int id);
    }
}
