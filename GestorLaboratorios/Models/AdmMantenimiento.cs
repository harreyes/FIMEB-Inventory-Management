using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmMantenimiento
    {
        public int ManId { get; set; }
        public int ManElemento { get; set; }
        public int ManTipoMantenimiento { get; set; }
        public string ManDescripcion { get; set; }
        public string ManRepuestos { get; set; }
        public int ManUsuarioCreacion { get; set; }
        public DateTime ManFechaInicio { get; set; }
        public DateTime? ManFechaFin { get; set; }
        public int ManFinalizado { get; set; }

        public AdmElemento ManElementoNavigation { get; set; }
        public SysTipoMantenimiento ManTipoMantenimientoNavigation { get; set; }
        public AdmUsuario ManUsuarioCreacionNavigation { get; set; }
    }
}
