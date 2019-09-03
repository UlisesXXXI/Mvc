using jim.dal.Int;
using jim.dal.Int.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace jim.dal.Imp
{
    public class RepositorioBase<T, C> : IRepositorioBase<T, C> where T : EntidadBase where C : DbContext
    {

        #region Campos privados

        private C _ctx;

        private DbSet<T> _dbSet;

        #endregion

        #region Propiedades

        public DbSet<T> DbSet {
                    get {
                        if(_dbSet == null)
                        {
                            _dbSet = _ctx.Set<T>();
                        }

                        return _dbSet;
                    } }

        #endregion


        public RepositorioBase(C ctx)
        {
            _ctx = ctx;

        }

        public void Delete(int id)
        {
           
        }

        public T Get(int id)
        {
            return DbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public T Get(Expression<Func<T,bool>> Where)
        {
            return DbSet.Where(Where).AsNoTracking().FirstOrDefault();
        }

        public T Get_NC(int id)
        {
            throw new NotImplementedException();
        }

        public T Get_NC(Expression<Func<T,bool>> Where)
        {
            throw new NotImplementedException();
        }

        public T UpdAndSaveChanges(T entidad)
        {
            throw new NotImplementedException();
        }

        public T Upddate(T entidad)
        {
            throw new NotImplementedException();
        }
    }
}
