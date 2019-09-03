using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.infraestructura.Behaviors
{
    [PSerializable]
    public class Transactional:OnMethodBoundaryAspect
    {
        private DbContext _ctx;
        private DbContextTransaction _trans;
        
        public Transactional(DbContext ctx)
        {
            _ctx = ctx;
            
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _trans = _ctx.Database.BeginTransaction();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _trans.Rollback();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _trans.Commit();
        }
    }
}
