using System;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Pdf
{
    public class HojaDeVidaElementoViewModel
    {
        public List<HojaDeVidaElementoViewModel> ListadoMantenimiento { get; set; }
        public string TipoMantenimiento { get; set; }
        public string Observacion { get; set; }
        public string Repuestos { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
