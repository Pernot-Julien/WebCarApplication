using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class MarqueService : IMarqueService
    {
        private readonly IMarqueRepository _marqueRepository;

        public MarqueService(IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;
        }
        public IEnumerable<Marque> RecupererToutesLesMarques()
        {
            return _marqueRepository.RecupererToutesLesMarques();
        }
    }
}
