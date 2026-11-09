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

        public Finition RecupererFinitionSelonId(int finitionId)
        {
            return _context.Finitions.FirstOrDefault(f => f.Id == finitionId);
        }

        public IEnumerable<Finition> RecupererToutesLesFinitions()
        {
            return _context.Finitions.ToList();
        }
    }
}