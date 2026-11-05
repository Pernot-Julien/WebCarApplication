using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class VoitureService : IVoitureService   
    {
        private readonly IVoitureRepository _voitureRepository;

        public VoitureService(IVoitureRepository voitureRepository)
        {
            _voitureRepository = voitureRepository;
        }
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

        public Voiture AjouterVoiture(Voiture voiture)
        {
            _voitureRepository.AjouterVoiture(voiture);
            return voiture;
        }
        public IEnumerable<Photo> RecupererPhotosSelonVoiture(int voitureId)
        {
            return _voitureRepository.RecupererPhotosSelonVoiture(voitureId);
        }

    }
}
