using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntitiesRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
            public void Add(TEntity entity)
            {
                //IDisposable patter implementation
                //using ten cıkınca garbagecollectiona gider GC tarafından temizlenir
                using (TContext context = new TContext())
                {
                    //Referans yakalanır.
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    context.SaveChanges();

                }
            }

            public void Delete(TEntity entity)
            {
                using (TContext context = new TContext())
                {
                    //Referans yakalanır.
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();

                }
            }

            public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
            {
                using (TContext context = new TContext())
                {
                    return context.Set<TEntity>().SingleOrDefault(filter);
                }
            }
            public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
            {
                using (TContext context = new TContext())
                {
                    return filter == null
                        //select * from Products
                        ? context.Set<TEntity>().ToList()
                        : context.Set<TEntity>().Where(filter).ToList();
                }
            }

            public void Update(TEntity entity)
            {
                using (TContext context = new TContext())
                {
                    //Referans yakalanır.
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                }
            }
        }
}

