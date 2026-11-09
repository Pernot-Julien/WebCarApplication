using WebCarApplication.Models.Entities;

namespace WebCarApplication.Models.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        public IEnumerable<Photo> RecupererPhotosSelonIdVoiture(int voitureId);
    }
}
