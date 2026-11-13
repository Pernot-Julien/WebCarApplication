using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarApplication.Models.Entities
{
    public class ModeleFinition
    {
        [Key]
        public int Id { get; set; }

     
        public int ModeleId { get; set; }
        public Modele Modele { get; set; } = null!;

 
        public int FinitionId { get; set; }
        public Finition Finition { get; set; } = null!;

        public ICollection<Voiture> Voitures { get; set; } = new List<Voiture>();
    }
}

