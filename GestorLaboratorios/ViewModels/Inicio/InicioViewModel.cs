using System;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Inicio
{
    public class InicioViewModel
    {
        public List<InicioViewModel> ListadoPrestamo { get; set; }

        public int IdPrestamo { get; set; }
        public int IdTipoSolicitud { get; set; }
        public string TipoSolicitud { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Profesor { get; set; }
        public string Materia { get; set; }
        public int ?IdEstado { get; set; }
        public string Estado { get; set; }

        public string JsFuncion { get; set; }
    }
}
