using System.Collections.Generic;

namespace GestorLaboratorios.ViewModels.Inicio
{
    public class ElementosPrestamoViewModel
    {
        public int IdReservaPrestamo { get; set; }
        public int IdEstadoReservaPrestamo { get; set; }
        public List<ElementosPrestamoViewModel> ListadoPrestamoElementos { get; set; }
        public int IdElemento { get; set; }
        public string PlacaElemento { get; set; }
        public string SerialElemento { get; set; }
        public string ModeloElemento { get; set; }
        public string MarcaElemento { get; set; }
        public int Entregado { get; set; }

        public string JsFuncion { get; set; }
    }
}
