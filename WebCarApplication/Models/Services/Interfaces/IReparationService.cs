using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IReparationService
    {
        public Reparation EnregistrerReparation(Reparation reparation);

        public Reparation? RecupererReparationSelonIdVoiture(int voitureId);

    }
}
