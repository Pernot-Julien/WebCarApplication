using System.ComponentModel.DataAnnotations;

namespace WebCarApplication.Models.ViewModels
{
    public class LoginViewModel
    {  
            [Required(ErrorMessage = "L'email est obligatoire")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Le mot de passe est obligatoire")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }
    }

