using KucnaKolekcijaKnjiga_VegaIT.Model.Entities;
using System.Collections.Generic;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.IServices
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void CreateAuthor(Author entity);
        void UpdateAuthor(Author entity);
        void DeleteAuthor(int id);
    }
}
