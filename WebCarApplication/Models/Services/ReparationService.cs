using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class ReparationService : IReparationService
    {
        private readonly IReparationRepository _reparationRepository;

        public ReparationService(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;
        }

        public Reparation EnregistrerReparation(Reparation reparation)
        {
            return _reparationRepository.EnregistrerReparation(reparation);
        }
        public Reparation? RecupererReparationSelonIdVoiture(int voitureId)
        {
            return _reparationRepository.RecupererReparationSelonIdVoiture(voitureId);
        }
    }
}
