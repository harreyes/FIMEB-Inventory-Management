using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class SysEstadoPrestamoReserva
    {
        public SysEstadoPrestamoReserva()
        {
            AdmPrestamoReserva = new HashSet<AdmPrestamoReserva>();
        }

        public int EprId { get; set; }
        public string EprDescripcion { get; set; }
        public int EprActivo { get; set; }

        public ICollection<AdmPrestamoReserva> AdmPrestamoReserva { get; set; }
    }
}
