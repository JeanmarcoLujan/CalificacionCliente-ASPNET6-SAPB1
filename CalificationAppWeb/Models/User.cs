using System.ComponentModel.DataAnnotations;

namespace CalificationAppWeb.Models
{
    public class User
    {
        [Display(Name = "Base de datos")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Text)]
        public string CompanyDB { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
