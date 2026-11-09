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

        public Modele? RecupererModeleSelonId(int modeleId)
        {
            return _modeleRepository.RecupererModeleSelonId(modeleId);
        }

        public IEnumerable<Modele> RecupererTousLesModeles()
        {
           return _modeleRepository.RecupererTousLesModeles();
        }
    }
}
