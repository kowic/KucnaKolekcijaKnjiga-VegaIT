using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories
{
    public interface ILanguageRepository
    {
        List<Language> GetAll();
        Language GetById(int id);
        void Create(Language entity);
        void Update(Language entity);
        void Delete(int id);
    }
}
