using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace jim.dal.Int.Repositorio
{
    public interface IRepositorioBase<T> where T : EntidadBase
    {
        /// <summary>
        /// Obtiene una entidad no cacheada
        /// </summary>
        /// <param name="id">identificador del objeto</param>
        /// <returns>Entidad no cacheada</returns>
        T Get_NC(int id);

        /// <summary>
        /// Obtiene una entidad CACHEADA
        /// </summary>
        /// <param name="id">identificador del objeto</param>
        /// <returns>Entidad CACHEADA</returns>
        T Get(int id);
        T Get_NC(Expression<Func<T>> Where);
        T Get(Expression<Func<T>> Where);


    }
}
