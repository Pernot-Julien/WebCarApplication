using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services
{
    public class VoitureService : IVoitureService   
    {
        public decimal CalculerPrixVente(Voiture voiture, IEnumerable<Reparation> reparations)
        {
            decimal coutTotalReparations = 0;
            foreach (Reparation reparation in reparations)
            {
                coutTotalReparations += reparation.CoutReparation;
            }
            const decimal margeBenefice = 500;
            decimal prixVente = voiture.PrixAchat + coutTotalReparations + margeBenefice;
            return prixVente;
        }
      
    }
}
