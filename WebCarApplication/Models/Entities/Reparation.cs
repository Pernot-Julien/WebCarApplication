namespace WebCarApplication.Models.Entities
{
    public class Reparation
    {
        public int Id { get; set; }
        public string DescriptionReparation { get; set; }
        public decimal CoutReparation { get; set; }
        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }

    }
}
