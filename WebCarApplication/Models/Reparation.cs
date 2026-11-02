namespace WebCarApplication.Models
{
    public class Reparation
    {
        public int Id { get; set; }
        public string DescriptionReparation { get; set; }

        public ICollection<Voiture> Voitures { get; set; }
    }
}
