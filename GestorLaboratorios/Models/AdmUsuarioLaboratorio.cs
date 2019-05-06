using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmUsuarioLaboratorio
    {
        public int UprUsuario { get; set; }
        public int UprLaboratorio { get; set; }

        public AdmLaboratorio UprLaboratorioNavigation { get; set; }
        public AdmUsuario UprUsuarioNavigation { get; set; }
    }
}
