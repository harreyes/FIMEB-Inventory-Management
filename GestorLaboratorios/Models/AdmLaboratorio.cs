using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmLaboratorio
    {
        public AdmLaboratorio()
        {
            AdmElemento = new HashSet<AdmElemento>();
            AdmPrestamoReserva = new HashSet<AdmPrestamoReserva>();
            AdmTipoElemento = new HashSet<AdmTipoElemento>();
            AdmUsuarioLaboratorio = new HashSet<AdmUsuarioLaboratorio>();
        }

        public int LabId { get; set; }
        public string LabNombre { get; set; }
        public string ProAbreviatura { get; set; }
        public int LabEncargado { get; set; }
        public string LabTelefono { get; set; }
        public string LabCorreo { get; set; }
        public string LabLogo { get; set; }
        public int LabActivo { get; set; }

        public ICollection<AdmElemento> AdmElemento { get; set; }
        public ICollection<AdmPrestamoReserva> AdmPrestamoReserva { get; set; }
        public ICollection<AdmTipoElemento> AdmTipoElemento { get; set; }
        public ICollection<AdmUsuarioLaboratorio> AdmUsuarioLaboratorio { get; set; }
    }
}
