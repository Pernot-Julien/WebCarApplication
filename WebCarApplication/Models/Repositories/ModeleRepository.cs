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
  
        public IEnumerable<Modele> RecupererTousLesModeles()
        {
            return _context.Modeles.ToList();
        }
        public Modele? RecupererModeleSelonId(int modeleId)
        {
            return _context.Modeles.FirstOrDefault(m => m.Id == modeleId);
        }
    }
}
