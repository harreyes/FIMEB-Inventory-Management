using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class ElementoPrestamoViewModel
    {
        public int IdUsuario { get; set; }
        public List<SelectListItem> ListadoUsuarios { get; set; }
        public DateTime Fecha { get; set; }

        public string Profesor { get; set; }
        public string Materia { get; set; }
    }
}
