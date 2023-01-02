
using Core.Abstract;
using Core.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class EfEnitiyRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity :class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity Entity)
        {
            using (TContext dbContext = new TContext())
            {
                var addedEntity = dbContext.Entry(Entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void Delete(TEntity Entity)
        {
            using (TContext dbContext = new TContext())
            {
                var deletedEntity = dbContext.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext dbContext = new TContext())
            {
                
                return dbContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext dbContext = new TContext())
            {
                
                return filter == null ? dbContext.Set<TEntity>().ToList()
                   : dbContext.Set<TEntity>().Where(filter).ToList();
            }
        }



        public void Update(TEntity Entity)
        {
            using (TContext dbContext = new TContext())
            {
                var updatedEntity = dbContext.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
