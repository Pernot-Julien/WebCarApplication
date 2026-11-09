using Microsoft.EntityFrameworkCore;
using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;

namespace WebCarApplication.Models.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _context;
        public PhotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }   
        public IEnumerable<Photo> RecupererPhotosSelonIdVoiture(int voitureId)
        {
            return _context.Photos.Where(p => p.VoitureId == voitureId).ToList();
        }

    }
}
