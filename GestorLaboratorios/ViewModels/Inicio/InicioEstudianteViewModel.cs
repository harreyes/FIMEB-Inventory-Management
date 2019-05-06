using GestorLaboratorios.ViewModels.Configuracion;
using System;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Inicio
{
    public class InicioEstudianteViewModel
    {
        public List<ElementoViewModel> ListadoDetalleElemento { get; set; }
        public int IdElemento { get; set; }
        public string TipoElemento { get; set; }
        public string Placa { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Observacion { get; set; }

        public DateTime Fecha { get; set; }
        public string Profesor { get; set; }
        public string Materia { get; set; }

        public string JsFuncion { get; set; }

    }
}
