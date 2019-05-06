using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmPerfil
    {
        public AdmPerfil()
        {
            AdmUsuario = new HashSet<AdmUsuario>();
        }

        public int PerId { get; set; }
        public string PerDescripcion { get; set; }
        public int PerActivo { get; set; }

        public ICollection<AdmUsuario> AdmUsuario { get; set; }
    }
}
