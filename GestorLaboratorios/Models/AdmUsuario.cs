using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmUsuario
    {
        public AdmUsuario()
        {
            AdmElemento = new HashSet<AdmElemento>();
            AdmMantenimiento = new HashSet<AdmMantenimiento>();
            AdmPrestamoReserva = new HashSet<AdmPrestamoReserva>();
            AdmUsuarioLaboratorio = new HashSet<AdmUsuarioLaboratorio>();
            LogElementoEstadoLogEstadoFinNavigation = new HashSet<LogElementoEstado>();
            LogElementoEstadoLogEstadoInicioNavigation = new HashSet<LogElementoEstado>();
        }

        public int UsuId { get; set; }
        public int UsuPerfil { get; set; }
        public string UsuNombre { get; set; }
        public string UsuApellido { get; set; }
        public string UsuIdentificacion { get; set; }
        public string UsuCodigo { get; set; }
        public string UsuCorreo { get; set; }
        public string UsuContrasena { get; set; }
        public string UsuTelefono { get; set; }
        public string UsuFoto { get; set; }
        public DateTime UsuFechaCreacion { get; set; }
        public int UsuEstado { get; set; }
        public int UsuActivo { get; set; }

        public SysEstadoUsuario UsuEstadoNavigation { get; set; }
        public AdmPerfil UsuPerfilNavigation { get; set; }
        public ICollection<AdmElemento> AdmElemento { get; set; }
        public ICollection<AdmMantenimiento> AdmMantenimiento { get; set; }
        public ICollection<AdmPrestamoReserva> AdmPrestamoReserva { get; set; }
        public ICollection<AdmUsuarioLaboratorio> AdmUsuarioLaboratorio { get; set; }
        public ICollection<LogElementoEstado> LogElementoEstadoLogEstadoFinNavigation { get; set; }
        public ICollection<LogElementoEstado> LogElementoEstadoLogEstadoInicioNavigation { get; set; }
    }
}
