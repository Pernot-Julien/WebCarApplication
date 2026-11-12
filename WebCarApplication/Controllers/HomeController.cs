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

        public HomeController(ILogger<HomeController> logger, IVoitureService voitureService, IMarqueService marqueService, IModeleService modeleService, IFinitionService finitionService, IPhotoService photoService)
        {
            _logger = logger;
            _voitureService = voitureService;
            _marqueService = marqueService;
            _modeleService = modeleService;
            _finitionService = finitionService;
            _photoService = photoService;
        }
 
        public IActionResult Index()
        {
            var voituresStockees = _voitureService.ObtenirToutesLesVoitures();
            List<ListeVoitureViewModel> voitures = new();

            foreach (var voiture in voituresStockees)
            {
                var finition = _finitionService
                    .RecupererFinitionSelonId(voiture.FinitionId);

                var modele = _modeleService
                    .RecupererModeleSelonId(finition.ModeleId);

                var marque = _marqueService
                    .RecupererMarqueSelonId(modele.MarqueId);

                var photos = _photoService.RecupererPhotosSelonIdVoiture(voiture.Id);

                voitures.Add(new ListeVoitureViewModel
                {
                    Id = voiture.Id,
                    CodeVin = voiture.CodeVin,
                    Annee = voiture.Annee,
                    PrixAchat = voiture.PrixAchat,

                    Marque = marque.NomMarque,
                    Modele = modele.NomModele,
                    Finition = finition.NomFinition,

                    PhotoUrl = photos.FirstOrDefault()?.Url
                });
            }

            return View(voitures);
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
