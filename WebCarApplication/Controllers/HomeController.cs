using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMarqueService _marqueService;
        private readonly IModeleService _modeleService;
        private readonly IFinitionService _finitionService;
        private readonly IVoitureService _voitureService;
        private readonly IPhotoService _photoService;
        private readonly IModeleFinitionService _modeleFinitionService;

        public HomeController(ILogger<HomeController> logger, IVoitureService voitureService, IMarqueService marqueService, IModeleService modeleService, IFinitionService finitionService, IPhotoService photoService, IModeleFinitionService modeleFinitionService)
        {
            _logger = logger;
            _voitureService = voitureService;
            _marqueService = marqueService;
            _modeleService = modeleService;
            _finitionService = finitionService;
            _photoService = photoService;
            _modeleFinitionService = modeleFinitionService;
        }

        public IActionResult Index()
        {
            var voituresStockees = _voitureService.ObtenirToutesLesVoitures();

            if (User.Identity?.IsAuthenticated != true)
            {
                voituresStockees = voituresStockees.Where(v => v.Disponible);
            }

            List<ListeVoitureViewModel> voitures = new();

            foreach (var voiture in voituresStockees)
            {
                var modeleFinition = _modeleFinitionService
                    .RecupererModeleFinitionSelonId(voiture.ModeleFinitionId);

                var finition = _finitionService
                    .RecupererFinitionSelonId(modeleFinition.FinitionId);

                var modele = _modeleService
                    .RecupererModeleSelonId(modeleFinition.ModeleId);

                var marque = _marqueService
                    .RecupererMarqueSelonId(modele.MarqueId);

                var photos = _photoService.RecupererPhotosSelonIdVoiture(voiture.Id);

                voitures.Add(new ListeVoitureViewModel
                {
                    Id = voiture.Id,
                    Vendu = voiture.Vendu,
                    Prix = _voitureService.CalculerPrixVente(voiture, voiture.Reparations),
                    Annee = voiture.Annee,
                    Marque = marque.NomMarque,
                    Modele = modele.NomModele,
                    Finition = finition.NomFinition,
                    Disponible = voiture.Disponible,
                    PhotoUrl = photos.FirstOrDefault()?.Url
                });
            }

            return View(voitures);
        }

        public IActionResult Details(int id)
        {
            var voiture = _voitureService.RechercherVoitureParId(id);

            if (voiture == null)
            {
                return NotFound();
            }

            // Un visiteur ne peut pas consulter une voiture indisponible
            if (User.Identity?.IsAuthenticated != true && !voiture.Disponible)
            {
                return NotFound();
            }

            var modeleFinition = _modeleFinitionService
                .RecupererModeleFinitionSelonId(voiture.ModeleFinitionId);

            var finition = _finitionService
                .RecupererFinitionSelonId(modeleFinition.FinitionId);

            var modele = _modeleService
                .RecupererModeleSelonId(modeleFinition.ModeleId);

            var marque = _marqueService
                .RecupererMarqueSelonId(modele.MarqueId);

            var photos = _photoService
                .RecupererPhotosSelonIdVoiture(voiture.Id);

            var viewModel = new ListeVoitureViewModel
            {
                Id = voiture.Id,
                Vendu = voiture.Vendu,
                Prix = _voitureService.CalculerPrixVente(voiture, voiture.Reparations),
                Annee = voiture.Annee,
                Marque = marque.NomMarque,
                Modele = modele.NomModele,
                Finition = finition.NomFinition,
                Disponible = voiture.Disponible,
                Description = voiture.Description,
                PhotoUrl = photos.FirstOrDefault()?.Url
            };

            return View(viewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
