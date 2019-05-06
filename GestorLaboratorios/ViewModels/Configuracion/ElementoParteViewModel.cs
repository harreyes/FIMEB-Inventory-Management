using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Configuracion
{
    public class ElementoParteViewModel
    {
        public int IdElemento { get; set; }
        public List<ElementoParteViewModel> ListadoParteElemento { get; set; }
        public int IdParteElemento { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
