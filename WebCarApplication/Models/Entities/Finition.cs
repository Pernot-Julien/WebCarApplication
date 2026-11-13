namespace WebCarApplication.Models.Entities
{
    public class Finition
    {
        public int Id { get; set; }
        public required string NomFinition { get; set; }

        public int ModeleId { get; set; }
        public Modele? Modele { get; set; }

        public ICollection<ModeleFinition> ModeleFinitions { get; set; } = new List<ModeleFinition>();
    }
}
