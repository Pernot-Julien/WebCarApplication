using WebCarApplication.Data;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Repositories.Interfaces;
namespace WebCarApplication.Models.Repositories;

public class VoitureRepository : IVoitureRepository
{
    private readonly ApplicationDbContext _context;
    public VoitureRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Voiture> ObtenirToutesLesVoitures()
    {
        return _context.Voitures.ToList();
    }
    public Voiture? ObtenirVoitureParId(int id)
    {
        return _context.Voitures.FirstOrDefault(v => v.Id == id);
    }
    public void AjouterVoiture(Voiture voiture)
    {
        _context.Voitures.Add(voiture);
        _context.SaveChanges();
    }
    public void ModifierVoiture(Voiture voiture)
    {
        _context.Voitures.Update(voiture);
        _context.SaveChanges();
    }
    public void SupprimerVoiture(int id)
    {
        var voiture = ObtenirVoitureParId(id);
        if (voiture != null)
        {
            _context.Voitures.Remove(voiture);
            _context.SaveChanges();
        }
    }
}
