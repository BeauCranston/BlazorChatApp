using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence
{
    public interface IRepository<TRepository> where TRepository : class
    {
        IEnumerable<TRepository> GetAll();
        TRepository GetById(object id);
        void Create(TRepository obj);
        void Update(TRepository obj);
        void Delete(object id);
    }
}
