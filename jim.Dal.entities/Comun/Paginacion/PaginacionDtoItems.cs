using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace jim.Dal.entities.Comun.Paginacion
{
    public class PaginacionDtoItems<T>: PaginacionDto where T : class
    {

        public PaginacionDtoItems(IEnumerable<T> items)
        {
            Items = items;
            TotalElementos = items.Count();
        }

        private IEnumerable<T> Items { get; set; }

        public IEnumerable<T> ObtenerElementosPaginados()
        {
            OrdenarElementos();

            return PaginarElementos();
        }

        private void OrdenarElementos()
        {
            if (TieneOrden)
            {
                Items = Items.OrderBy(CampoOrden + " " + Orden);
            }
        }

        private IEnumerable<T> PaginarElementos()
        {
           return Items.Skip((PaginaActual - 1) * CantidadPorPagina).Take(CantidadPorPagina);
        }
    }
}
