using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;

namespace WebCarApplication.Models.Repositories
{
    public class ModeleFinitionRepository : IModeleFinitionRepository
    {
        private readonly ApplicationDbContext _context; // Remplace par le nom exact de ton DbContext

        public ModeleFinitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ModeleFinition RecupererModeleFinitionSelonId(int id)
        {
            return _context.ModeleFinitions
                .FirstOrDefault(mf => mf.Id == id);
        }
    }
}
