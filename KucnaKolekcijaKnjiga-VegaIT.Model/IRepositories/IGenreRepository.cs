using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
        Genre GetById(int id);
        void Create(Genre entity);
        void Update(Genre entity);
        void Delete(int id);
    }
}
