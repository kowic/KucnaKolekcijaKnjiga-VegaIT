using System.ComponentModel.DataAnnotations;

namespace KucnaKolekcijaKnjiga_VegaIT.Web.Models.ViewModels
{
    public class AuthorViewModel
    {
        [Display(Name = "ID")]
        public int? AuthorId { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime mora biti uneto")]
        [StringLength(50, ErrorMessage = "Ime mora biti kraće od 50 karaktera")]
        public string Name { get; set; }

        [Display(Name = "Nacionalnost")]
        public int? NationalityId { get; set; }
        public string NationalityName { get; set; }
    }
}