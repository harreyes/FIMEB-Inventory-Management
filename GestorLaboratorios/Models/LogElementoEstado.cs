using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class LogElementoEstado
    {
        public int LogId { get; set; }
        public int LogElemento { get; set; }
        public int LogEstadoInicio { get; set; }
        public int LogEstadoFin { get; set; }
        public DateTime LogFecha { get; set; }

        public AdmElemento LogElementoNavigation { get; set; }
        public AdmUsuario LogEstadoFinNavigation { get; set; }
        public AdmUsuario LogEstadoInicioNavigation { get; set; }
    }
}
