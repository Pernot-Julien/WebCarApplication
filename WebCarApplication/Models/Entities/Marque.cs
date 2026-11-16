namespace WebCarApplication.Models.Entities
{
    public class Marque
    {
        public int Id { get; set; }
        public required string NomMarque { get; set; }

        public ICollection<Modele> Modeles { get; set; } = new List<Modele>();
    }
}
