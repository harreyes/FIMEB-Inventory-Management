using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class SysElementoEstado
    {
        public SysElementoEstado()
        {
            AdmElemento = new HashSet<AdmElemento>();
        }

        public int EesId { get; set; }
        public string EesDescripcion { get; set; }
        public int EesActivo { get; set; }

        public ICollection<AdmElemento> AdmElemento { get; set; }
    }
}
