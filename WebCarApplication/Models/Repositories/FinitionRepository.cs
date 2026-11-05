using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Data;

namespace WebCarApplication.Models.Repositories
{
    public class FinitionRepository : IFinitionRepository
    {
        private readonly ApplicationDbContext _context;

        public FinitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Finition> RecupererFinitionsSelonModele(int modeleId)
        {
            return _context.Finitions.Where(f => f.ModeleId == modeleId).ToList();
        }

        public IEnumerable<Finition> RecupererToutesLesFinitions()
        {
            return _context.Finitions.ToList();
        }
    }
}