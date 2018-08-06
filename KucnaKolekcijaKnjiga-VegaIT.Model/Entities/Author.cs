namespace KucnaKolekcijaKnjiga_VegaIT.Model.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Nationality Nationality { get; set; }
    }
}
