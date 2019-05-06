using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class ElementoDetalleViewModel
    {
        public List<SelectListItem> ListadoTipoElemento { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int IdTipoElemento { get; set; }
        public int IdElemento { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Placa { get; set; }

        public string Descripcion { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Observacion { get; set; }
        public string NombreUsuarioCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
