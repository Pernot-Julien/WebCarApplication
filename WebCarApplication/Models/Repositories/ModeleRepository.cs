using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;

namespace WebCarApplication.Models.Repositories
{
    public class ModeleRepository : IModeleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModeleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Modele> RecupererModeleSelonMarque(int marqueId)
        {
            return _context.Modeles.Where(m => m.MarqueId == marqueId).ToList();
        }
        public IEnumerable<Modele> RecupererTousLesModeles()
        {
            return _context.Modeles.ToList();
        }
    }
}
