using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.Dal.entities.Comun.Paginacion
{
    public class PaginacionDto
    {
        #region CONSTANTES

        public readonly static int PAGINA_ACTUAL_POR_DEFECTO = 1;

        public readonly static int CANTIDAD_POR_PAGINA_POR_DEFECTO = 10;

        public readonly static string ORDEN_ASCENDENTE = "ASC";

        public readonly static string ORDEN_DESCENDENTE = "DESC";

        #endregion

        #region Constructor

        public PaginacionDto()
        {

        }

        #endregion

        #region Campos Privados

        private int _paginaActual;

        private int _cantidadPorPagina;

        private string _orden;

        private string _campoOrden;

        #endregion

        #region Propiedades

        public string Busqueda { get; set; }

        public int PaginaActual {
                    get
                    {
                        return (_paginaActual <= 0) ? PAGINA_ACTUAL_POR_DEFECTO : _paginaActual;
                    }
                    set
                    {
                        _paginaActual = value;
                    }
        }

        public int CantidadPorPagina {
                    get
                    {
                        return (_cantidadPorPagina <= 0) ? CANTIDAD_POR_PAGINA_POR_DEFECTO : _cantidadPorPagina;
                    }
                    set
                    {
                        _cantidadPorPagina = value;
                    }
        }

        public int TotalElementos { get; set; }

        public string Orden {
                        get {
                                if((String.IsNullOrEmpty(_orden) || _orden != ORDEN_ASCENDENTE && _orden != ORDEN_ASCENDENTE))
                                {
                                    return ORDEN_ASCENDENTE;
                                }
                                return _orden;
                            }
                        set {
                                _orden = value;
                            }
        }

        public string CampoOrden { get; set; }

        public bool TieneOrden
        {
            get
            {
                return (String.IsNullOrEmpty(CampoOrden))? true : false;
            }
        }
        
        #endregion



    }
}
