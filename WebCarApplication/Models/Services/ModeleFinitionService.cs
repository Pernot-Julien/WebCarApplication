using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class ModeleFinitionService : IModeleFinitionService
    {
        private readonly IModeleFinitionRepository _modeleFinitionRepository;
        public ModeleFinitionService(IModeleFinitionRepository modeleFinitionRepository)
        {
            _modeleFinitionRepository = modeleFinitionRepository;
        }
        public ModeleFinition RecupererModeleFinitionSelonId(int id)
        {
            return _modeleFinitionRepository.RecupererModeleFinitionSelonId(id);
        }
    }
}

