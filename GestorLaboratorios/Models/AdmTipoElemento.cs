using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmTipoElemento
    {
        public AdmTipoElemento()
        {
            AdmElemento = new HashSet<AdmElemento>();
        }

        public int TelId { get; set; }
        public int TelLaboratorio { get; set; }
        public string TelDescripcion { get; set; }
        public int TelActivo { get; set; }

        public AdmLaboratorio TelLaboratorioNavigation { get; set; }
        public ICollection<AdmElemento> AdmElemento { get; set; }
    }
}
