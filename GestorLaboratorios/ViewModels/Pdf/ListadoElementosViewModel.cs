using System;
using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Pdf
{
    public class ListadoElementosViewModel
    {
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Partes { get; set; }
        public string PlacaUan { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }

        #region Se usan para exportar a excel
        public int IdEstadoElemento { get; set; }
        public string TipoElemento { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Activo { get; set; }
        #endregion

        public List<ListadoElementosViewModel> ListadoElementos { get; set; }

    }
}
