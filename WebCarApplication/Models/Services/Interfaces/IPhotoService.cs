using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Services.Interfaces
{
    public interface IPhotoService
    {
        IEnumerable<Photo> RecupererPhotosSelonIdVoiture(int voitureId);
    }
}
