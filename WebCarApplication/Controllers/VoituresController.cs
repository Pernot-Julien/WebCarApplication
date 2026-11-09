using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCarApplication.Models.Entities;
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
        private readonly IPhotoService _photoService;

        public VoituresController(IVoitureService voitureService, IMarqueService marqueService, IModeleService modeleService, IFinitionService finitionService, IPhotoService photoService  )
        {
            _voitureService = voitureService;
            _marqueService = marqueService;
            _modeleService = modeleService;
            _finitionService = finitionService;
            _photoService = photoService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createVoitureViewModel = new CreateVoitureViewModel();
            // ici je veux rechercher toutes les marques 
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

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "voitures", fileName);

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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var voiture = _voitureService.RechercherVoitureParId(id);

            if (voiture == null)
            {
                return NotFound();
            }

            var finition = _finitionService.RecupererFinitionSelonId(voiture.FinitionId);
            var modele = _modeleService.RecupererModeleSelonId(finition.ModeleId);
            var marque = _marqueService.RecupererMarqueSelonId(modele.MarqueId);
            var photos = _photoService.RecupererPhotosSelonIdVoiture(voiture.Id);

            var updateVoitureViewModel = new UpdateVoitureViewModel
            {
                Id = voiture.Id,
                CodeVin = voiture.CodeVin,
                Annee = voiture.Annee,

                MarqueId = marque.Id,
                MarquesDisponibles = _marqueService
                    .RecupererToutesLesMarques()
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomMarque
                    }).ToList(),
                ModeleId = modele.Id,
                ModelesDisponibles = _modeleService
                    .RecupererTousLesModeles()
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomModele
                    }).ToList(),
                FinitionId = finition.Id,
                FinitionsDisponibles = _finitionService
                    .RecupererToutesLesFinitions()
                    .Select(f => new SelectListItem
                    {
                        Value = f.Id.ToString(),
                        Text = f.NomFinition
                    }).ToList(),

                DateAchat = voiture.DateAchat,
                PrixAchat = voiture.PrixAchat,
                DateDisponibilite = voiture.DateDisponibilite,
                PhotoActuelle = voiture.Photos.FirstOrDefault()?.Url
            };

            return View(updateVoitureViewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateVoitureViewModel updateVoitureViewModel)
        {
            if (!ModelState.IsValid)
            {
                updateVoitureViewModel.MarquesDisponibles = _marqueService
                    .RecupererToutesLesMarques()
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.NomMarque
                    }).ToList();
                return View(updateVoitureViewModel);
            }
            var voiture = _voitureService.RechercherVoitureParId(updateVoitureViewModel.Id);
            if (voiture == null)
            {
                return NotFound();
            }
            voiture.CodeVin = updateVoitureViewModel.CodeVin;
            voiture.Annee = updateVoitureViewModel.Annee;
            voiture.DateAchat = updateVoitureViewModel.DateAchat;
            voiture.PrixAchat = updateVoitureViewModel.PrixAchat;
            voiture.DateDisponibilite = updateVoitureViewModel.DateDisponibilite;
            voiture.FinitionId = updateVoitureViewModel.FinitionId;
            if (updateVoitureViewModel.Photo != null)
            {
                var fileName = updateVoitureViewModel.Photo.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "voitures", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    updateVoitureViewModel.Photo.CopyToAsync(stream);
                }
                voiture.Photos.Clear();
                voiture.Photos.Add(new Photo
                {
                    Url = fileName
                });
            }
            _voitureService.ModifierVoiture(voiture);
            return RedirectToAction("Update", new { id = voiture.Id });
        }
    }
}
