using System;
using System.Collections.Generic;

namespace GestorLaboratorios.Models
{
    public partial class AdmPrestamoReserva
    {
        public AdmPrestamoReserva()
        {
            AdmPrestamoReservaElemento = new HashSet<AdmPrestamoReservaElemento>();
        }

        public int PreId { get; set; }
        public int PreLaboratorio { get; set; }
        public int PreUsuario { get; set; }
        public DateTime PreFechaCreacion { get; set; }
        public DateTime PreFechaPrestamoReserva { get; set; }
        public TimeSpan? PreHoraInicio { get; set; }
        public TimeSpan? PreHoraFin { get; set; }
        public string PreProfesor { get; set; }
        public string PreMateria { get; set; }
        public int PreTipo { get; set; }
        public int? PreEstado { get; set; }

        public SysEstadoPrestamoReserva PreEstadoNavigation { get; set; }
        public AdmLaboratorio PreLaboratorioNavigation { get; set; }
        public SysTipoPrestamoReserva PreTipoNavigation { get; set; }
        public AdmUsuario PreUsuarioNavigation { get; set; }
        public ICollection<AdmPrestamoReservaElemento> AdmPrestamoReservaElemento { get; set; }
    }
}
