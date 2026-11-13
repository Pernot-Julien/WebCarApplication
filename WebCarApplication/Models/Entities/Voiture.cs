namespace WebCarApplication.Models.Entities
{
    public class Voiture
    {
        public int Id { get; set; }
        public int? CodeVin { get; set; }
        public required int Annee { get; set; }
        public required DateTime DateAchat { get; set; }
        public required decimal PrixAchat { get; set; }
        public DateTime? DateDisponibilite { get; set; }
        public DateTime? DateVente { get; set; }
        public string? Description { get; set; }

        public int ModeleFinitionId { get; set; }
        public ModeleFinition ModeleFinition { get; set; } = null!;

        public ICollection<Reparation> Reparations { get; set; } = new List<Reparation>();
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();

    }
}
