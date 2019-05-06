using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class SysEstadoUsuario
    {
        public SysEstadoUsuario()
        {
            AdmUsuario = new HashSet<AdmUsuario>();
        }

        public int EusId { get; set; }
        public string EusDescripcion { get; set; }
        public int EusActivo { get; set; }

        public ICollection<AdmUsuario> AdmUsuario { get; set; }
    }
}
