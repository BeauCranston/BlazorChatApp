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
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected readonly BlazorChatDbContext _context;
        protected DbSet<TEntity> dbset;
        public GenericRepository(BlazorChatDbContext context)
        {
            _context = context;
            dbset = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return dbset.ToList();
        }

        public TEntity GetById(object id)
        {
            return dbset.Find(id);
        }

        public void Create(TEntity obj)
        {
            dbset.Add(obj);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dbset.Find(id);
            dbset.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
