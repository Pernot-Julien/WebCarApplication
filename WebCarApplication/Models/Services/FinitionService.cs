using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class FinitionService : IFinitionService
    {
            private readonly IFinitionRepository _finitionRepository;

            public FinitionService(IFinitionRepository finitionRepository)
            {
                _finitionRepository = finitionRepository;
            }
        public IEnumerable<Finition> RecupererFinitionsSelonModele(int modeleId)
        {
           return _finitionRepository.RecupererFinitionsSelonModele(modeleId);
        }
        public IEnumerable<Finition> RecupererToutesLesFinitions()
        {
            return _finitionRepository.RecupererToutesLesFinitions();
        }
    }
}
