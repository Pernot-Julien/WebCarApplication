namespace WebCarApplication.Models
{
    public class Finition
    {
        public int Id { get; set; }
        public string NomFinition { get; set; }

        public int ModeleId { get; set; }
        public Modele Modele { get; set; }

        public ICollection<Voiture> Voiture { get; set; }
    }
}
