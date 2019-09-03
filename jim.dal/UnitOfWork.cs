using jim.infraestructura.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.dal
{
    public class UnitOfWork
    {
        private ApplicationDbContext _ctx;
        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        
        public void FuncionPrueba()
        {

        }
    }
}
