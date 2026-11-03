using WebCarApplication.Models.Entities;
namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IVoitureService
    {
        public decimal CalculerPrixVente(Voiture voiture, IEnumerable<Reparation> reparations);
        
    }
}
