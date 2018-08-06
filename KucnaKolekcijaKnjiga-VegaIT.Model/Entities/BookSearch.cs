using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KucnaKolekcijaKnjiga_VegaIT.Model.Entities
{
    public class BookSearch
    {
        public string TitleSearch { get; set; }
        public string ISBNSearch { get; set; }
        public int? AuthorSearch { get; set; }
        public int? GenreSearch { get; set; }
        public int? LanguageSearch { get; set; }
    }
}
