using System.ComponentModel.DataAnnotations;

namespace WebCarApplication.Models.Entities
{
    public class Voiture
    {
        public int Id { get; set; }
        public int CodeVin { get; set; }
        public int Annee { get; set; }
        public DateTime DateAchat { get; set; }
        public int PrixAchat { get; set; }
        public DateTime DateDisponibilite { get; set; }
        public DateTime DateVente { get; set; }
        public string Description { get; set; }

        public int FinitionId { get; set; }
        public Finition Finition { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Reparation> Reparations { get; set; }
    }
}
