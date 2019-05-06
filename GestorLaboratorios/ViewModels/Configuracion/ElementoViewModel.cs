using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class ElementoViewModel
    {
        public List<SelectListItem> ListadoEstadoElemento { get; set; }

        public List<ElementoViewModel> ListadoDetalleElemento { get; set; }
        public int IdElemento { get; set; }
        //public int IdLaboratorio { get; set; }
        public int IdTipoElemento { get; set; }
        public string TipoElemento { get; set; }

        public int IdEstadoElemento { get; set; }
        public string Placa { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Observacion { get; set; }
        public string NombreUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public string JsFunction { get; set; }
    }
}
