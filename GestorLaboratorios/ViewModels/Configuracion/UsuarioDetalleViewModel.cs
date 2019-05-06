using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class UsuarioDetalleViewModel
    {
        public List<SelectListItem> ListadoPerfiles { get; set; }
        public List<SelectListItem> ListadoEstados { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdEstado { get; set; }
        public bool Activo { get; set; }
    }
}
