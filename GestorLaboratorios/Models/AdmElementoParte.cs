using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmElementoParte
    {
        public int EpaId { get; set; }
        public int? EpaElemento { get; set; }
        public string EpaDescripcion { get; set; }
        public int? EpaActivo { get; set; }

        public AdmElemento EpaElementoNavigation { get; set; }
    }
}
