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
            createVoitureViewModel.ModelesDisponibles = _modeleService.RecupererTousLesModeles().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.NomModele
            }).ToList();

            createVoitureViewModel.FinitionsDisponibles = _finitionService.RecupererToutesLesFinitions().Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.NomFinition
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
            };

            if (createVoitureViewModel.Photo != null)
            {
                var fileName = createVoitureViewModel.Photo.FileName;

                var filePath = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot", "images", "voitures", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    createVoitureViewModel.Photo.CopyToAsync(stream);
                }

                voiture.Photos.Add(new Photo
                {
                    Url = fileName
                });

               
            }
            _voitureService.AjouterVoiture(voiture);

            return RedirectToAction("Create");
        }
    }
}
