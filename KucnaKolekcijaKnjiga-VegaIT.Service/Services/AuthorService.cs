using KucnaKolekcijaKnjiga_VegaIT.Model.IServices;
using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using KucnaKolekcijaKnjiga_VegaIT.Model.IRepositories;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository repository)
        {
            _authorRepository = repository;
        }

        public void CreateAuthor(Author entity)
        {
            _authorRepository.Create(entity);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void UpdateAuthor(Author entity)
        {
            _authorRepository.Update(entity);
        }
    }
}
