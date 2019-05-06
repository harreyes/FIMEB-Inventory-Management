using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmElemento
    {
        public AdmElemento()
        {
            AdmElementoParte = new HashSet<AdmElementoParte>();
            AdmMantenimiento = new HashSet<AdmMantenimiento>();
            AdmPrestamoReservaElemento = new HashSet<AdmPrestamoReservaElemento>();
            LogElementoEstado = new HashSet<LogElementoEstado>();
        }

        public int EleId { get; set; }
        public int EleLaboratorio { get; set; }
        public int EleTipoElemento { get; set; }
        public int EleEstado { get; set; }
        public string ElePlacaUan { get; set; }
        public string EleSerial { get; set; }
        public string EleModelo { get; set; }
        public string EleMarca { get; set; }
        public string EleDescripcion { get; set; }
        public string EleObservaciones { get; set; }
        public int EleUsuarioCreacion { get; set; }
        public DateTime EleFechaCreacion { get; set; }
        public int EleActivo { get; set; }

        public SysElementoEstado EleEstadoNavigation { get; set; }
        public AdmLaboratorio EleLaboratorioNavigation { get; set; }
        public AdmTipoElemento EleTipoElementoNavigation { get; set; }
        public AdmUsuario EleUsuarioCreacionNavigation { get; set; }
        public ICollection<AdmElementoParte> AdmElementoParte { get; set; }
        public ICollection<AdmMantenimiento> AdmMantenimiento { get; set; }
        public ICollection<AdmPrestamoReservaElemento> AdmPrestamoReservaElemento { get; set; }
        public ICollection<LogElementoEstado> LogElementoEstado { get; set; }
    }
}
