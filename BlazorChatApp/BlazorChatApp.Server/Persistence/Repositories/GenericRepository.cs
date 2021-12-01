using BlazorChatApp.Server.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Persistence.Repositories
{
    //Generic Repository to give crud functions to all entitys.
    //I plan to hide the implementation of this behind a service so that the application only talks to the service and not the repository directly
    public class GenericRepository<TRepository> : IRepository<TRepository> where TRepository : class 
    {
        protected readonly BlazorChatDbContext _context;
        protected DbSet<TRepository> dbset;
        public GenericRepository(BlazorChatDbContext context)
        {
           this._context = context;
           this.dbset = context.Set<TRepository>();
        }
        public IEnumerable<TRepository> GetAll()
        {
            throw new NotImplementedException();
        }

        public TRepository GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Create(TRepository obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(TRepository obj)
        {
            throw new NotImplementedException();
        }
    }
}
