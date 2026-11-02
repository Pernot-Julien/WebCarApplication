namespace WebCarApplication.Models
{
    public class Marque
    {
        public int Id { get; set; }
        public string NomMarque { get; set; }

        public ICollection<Modele> Modele { get; set; }
    }
}
