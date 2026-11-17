using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services.Interfaces;
namespace WebCarApplication.Models.Services
{
    public class ParametresApplicationService : IParametresApplicationService
    {
        private readonly IParametresApplicationRepository _parametresApplicationRepository;
        public ParametresApplicationService(IParametresApplicationRepository parametresApplicationRepository)
        {
            _parametresApplicationRepository = parametresApplicationRepository;
        }
        public ParametresApplication RecupererParametres()
        {
            return _parametresApplicationRepository.RecupererParametres();
        }
        public void ModifierParametres(ParametresApplication parametres)
        {
            _parametresApplicationRepository.ModifierParametres(parametres);
        }
    }
}
