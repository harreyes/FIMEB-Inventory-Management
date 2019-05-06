using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class SysTipoPrestamoReserva
    {
        public SysTipoPrestamoReserva()
        {
            AdmPrestamoReserva = new HashSet<AdmPrestamoReserva>();
        }

        public int TprId { get; set; }
        public string TprDescripcion { get; set; }
        public int TprActivo { get; set; }

        public ICollection<AdmPrestamoReserva> AdmPrestamoReserva { get; set; }
    }
}
