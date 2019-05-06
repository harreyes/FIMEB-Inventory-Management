using System.Collections.Generic;
namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class TipoElementoViewModel
    {
        public List<TipoElementoViewModel> ListadoTipoElemento { get; set; }
        public int IdTipoElemento { get; set; }
        public int IdLaboratorio { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}
