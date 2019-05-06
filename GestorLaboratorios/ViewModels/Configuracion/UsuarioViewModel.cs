using System.Collections.Generic;
namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class UsuarioViewModel
    {
        public List<UsuarioViewModel> ListadoUsuarios { get; set; }
        public int IdUsuario { get; set; }
        public string Perfil { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }

        public string JsFuncion { get; set; }

    }
}
