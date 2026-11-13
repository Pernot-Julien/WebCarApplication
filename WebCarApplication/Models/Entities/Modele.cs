namespace WebCarApplication.Models.Entities
{
    public class Modele
    {
        public int Id { get; set; }
        public required string NomModele { get; set; }
        public int MarqueId { get; set; }
        public Marque? Marque { get; set; }

        public ICollection<ModeleFinition> ModeleFinitions { get; set; } = new List<ModeleFinition>();
    }
}
