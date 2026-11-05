using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class ModeleService : IModeleService
    {
        private readonly IModeleRepository _modeleRepository;

        public ModeleService(IModeleRepository modeleRepository)
        {
            _modeleRepository = modeleRepository;
        }

        public IEnumerable<Modele> RecupererModeleSelonMarque(int marqueId)
        {
            return _modeleRepository.RecupererModeleSelonMarque(marqueId);
        }

        public IEnumerable<Modele> RecupererTousLesModeles()
        {
           return _modeleRepository.RecupererTousLesModeles();
        }
    }
}
