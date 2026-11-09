using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;

namespace WebCarApplication.Models.Repositories
{
    public class MarqueRepository : IMarqueRepository
    {
        private readonly ApplicationDbContext _context;

        public MarqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       public IEnumerable<Marque> RecupererToutesLesMarques()
        {
            return _context.Marques.ToList();
        }
        public Marque? RecupererMarqueSelonId(int id)
        {
            return _context.Marques.FirstOrDefault(m => m.Id == id);
        }
    }
}
