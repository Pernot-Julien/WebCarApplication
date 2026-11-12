using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IReparationRepository
    {
       Reparation EnregistrerReparation(Reparation reparation);
       Reparation? RecupererReparationSelonIdVoiture(int voitureId);
    }
}
