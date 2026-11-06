using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebCarApplication.Models.ViewModels
{
    public class CreateVoitureViewModel
    {
        [Display(Name = "Code VIN")]
        public int? CodeVin { get; set; }

        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1990, 2100, ErrorMessage = "Année invalide")]
        public int Annee { get; set; }

        [Required(ErrorMessage = "La date d'achat est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'achat")]
        public DateTime DateAchat { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Le prix d'achat est obligatoire")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro")]
        [Display(Name = "Prix d'achat (€)")]
        public decimal PrixAchat { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de disponibilité à la vente")]
        public DateTime? DateDisponibilite { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire")]
        [Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner une marque")]
        [Display(Name = "Marque")]
        public int MarqueId { get; set; }

        [Required(ErrorMessage = "Le modèle est obligatoire")]
        [Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner un modèle")]
        [Display(Name = "Modèle")]
        public int ModeleId { get; set; }

        [Required(ErrorMessage = "La finition est obligatoire")]
        [Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner une finition")]
        [Display(Name = "Finition")]
        public int FinitionId { get; set; }

        [Required(ErrorMessage = "La photo est obligatoire")]
        [Display(Name = "Photo")]
        public IFormFile? Photo { get; set; }

        // Données destinées aux listes déroulantes
        public List<SelectListItem> MarquesDisponibles { get; set; } = new();
        public List<SelectListItem> ModelesDisponibles { get; set; } = new();
        public List<SelectListItem> FinitionsDisponibles { get; set; } = new();
    }
}