using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories
{
    public interface INationalityRepository
    {
        List<Nationality> GetAll();
        Nationality GetById(int id);
        void Create(Nationality entity);
        void Update(Nationality entity);
        void Delete(int id);
    }
}
