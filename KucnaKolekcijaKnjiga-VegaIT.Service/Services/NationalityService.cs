using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Service.Services
{
    public class NationalityService : INationalityService
    {
        private INationalityRepository _nationalityRepository;

        public NationalityService(INationalityRepository repository)
        {
            _nationalityRepository = repository;
        }

        public void CreateNationality(Nationality entity)
        {
            _nationalityRepository.Create(entity);
        }

        public void DeleteNationality(int id)
        {
            _nationalityRepository.Delete(id);
        }

        public List<Nationality> GetAllNationalities()
        {
            return _nationalityRepository.GetAll();
        }

        public Nationality GetNationalityById(int id)
        {
            return _nationalityRepository.GetById(id);
        }

        public void UpdateNationality(Nationality entity)
        {
            _nationalityRepository.Update(entity);
        }
    }
}
