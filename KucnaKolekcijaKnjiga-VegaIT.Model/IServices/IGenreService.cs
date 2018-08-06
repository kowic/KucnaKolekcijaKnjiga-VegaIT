using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IServices
{
    public interface IGenreService
    {
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        void CreateGenre(Genre entity);
        void UpdateGenre(Genre entity);
        void DeleteGenre(int id);
    }
}
