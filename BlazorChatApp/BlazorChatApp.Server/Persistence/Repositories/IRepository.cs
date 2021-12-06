using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(object id);
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
    }
}
