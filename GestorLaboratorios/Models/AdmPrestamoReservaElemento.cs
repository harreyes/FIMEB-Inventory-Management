using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmPrestamoReservaElemento
    {
        public int PreReserva { get; set; }
        public int PreElemento { get; set; }
        public int PreEntregado { get; set; }

        public AdmElemento PreElementoNavigation { get; set; }
        public AdmPrestamoReserva PreReservaNavigation { get; set; }
    }
}
