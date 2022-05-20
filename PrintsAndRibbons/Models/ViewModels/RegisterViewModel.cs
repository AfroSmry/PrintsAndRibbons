using System.ComponentModel.DataAnnotations;

namespace PrintsAndRibbons.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Ваше имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Ваш Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}

