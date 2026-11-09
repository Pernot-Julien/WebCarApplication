using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.Repositories.Interfaces;

namespace WebCarApplication.Models.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public IEnumerable<Photo> RecupererPhotosSelonIdVoiture(int voitureId)
        {
            return _photoRepository.RecupererPhotosSelonIdVoiture(voitureId);
        }
    }
}
