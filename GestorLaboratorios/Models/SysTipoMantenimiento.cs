using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class SysTipoMantenimiento
    {
        public SysTipoMantenimiento()
        {
            AdmMantenimiento = new HashSet<AdmMantenimiento>();
        }

        public int TmaId { get; set; }
        public string TmaDescripcion { get; set; }
        public int TmaActivo { get; set; }

        public ICollection<AdmMantenimiento> AdmMantenimiento { get; set; }
    }
}
