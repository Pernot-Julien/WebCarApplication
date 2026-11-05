using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarApplication.Models.Entities;
using WebCarApplication.Models.Services;
using WebCarApplication.Models.Services.Interfaces;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    public class VoituresController : Controller
    {
        private readonly IMarqueService _marqueService;
        private readonly IModeleService _modeleService;
        private readonly IFinitionService _finitionService;
   
        private readonly IVoitureService _voitureService;

        public VoituresController(IVoitureService voitureService, IMarqueService marqueService, IModeleService modeleService, IFinitionService finitionService)
        {
            _voitureService = voitureService;
            _marqueService = marqueService;
            _modeleService = modeleService;
            _finitionService = finitionService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createVoitureViewModel = new CreateVoitureViewModel();
            // ici je veux recuperer toutes les marques 
            createVoitureViewModel.MarquesDisponibles = _marqueService.RecupererToutesLesMarques().Select(m => new SelectListItem
           {
               Value = m.Id.ToString(),
               Text = m.NomMarque
           }).ToList();
            createVoitureViewModel.ModelesDisponibles =_modeleService.RecupererTousLesModeles().Select(m => new SelectListItem
              {
                  Value = m.Id.ToString(),
                  Text = m.NomModele
              }).ToList();

            return View(createVoitureViewModel);
        }


        [HttpPost]
        public IActionResult Create(CreateVoitureViewModel createVoitureViewModel)
        {
            if (!ModelState.IsValid)
            {
                createVoitureViewModel.MarquesDisponibles = _marqueService
                    .RecupererToutesLesMarques()
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomMarque
                    }).ToList();

                return View(createVoitureViewModel);
            }

            var voiture = new Models.Entities.Voiture
            {
                CodeVin = createVoitureViewModel.CodeVin,
                Annee = createVoitureViewModel.Annee,
                DateAchat = createVoitureViewModel.DateAchat,
                PrixAchat = createVoitureViewModel.PrixAchat,
                DateDisponibilite = createVoitureViewModel.DateDisponibilite,
                FinitionId = createVoitureViewModel.FinitionId,
                Photos = new List<Photo>
            {
                    new Photo { Url = createVoitureViewModel.Photo }
                }
            };

            _voitureService.AjouterVoiture(voiture);

            return RedirectToAction("Index");
        }
    }
}
