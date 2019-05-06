using System.ComponentModel.DataAnnotations;

namespace GestorLaboratorios.ViewModels.Login
{
    public class LoginViewModel
    {
        public string sCodigo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "sCorreo")]
        public string sCorreo { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "sContrasena")]
        [Required(ErrorMessage = "Campo requerido")]
        public string sContrasena { get; set; }
        public string Mensaje { get; set; }
        public string JsFuncion { get; set; }
    }
}
