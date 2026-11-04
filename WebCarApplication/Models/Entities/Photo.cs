namespace WebCarApplication.Models.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public string? TexteAlternatif { get; set; }

        public int VoitureId { get; set; }
        public Voiture? Voiture { get; set; }

    }
}
