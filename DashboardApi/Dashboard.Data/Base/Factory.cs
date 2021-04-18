using Dashboard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dashboard.Data
{
    public abstract class Factory : IFactory 
    {
        protected DbContext _ctx;

        public Factory(DbContext ctx)
        {
            _ctx = ctx;

        }

        /// <summary>
        /// Project Factory will be auto resolved using DI
        /// </summary>

        public virtual T Add<T>(T entities) where T : class
        {

            var tracking = _ctx.Set<T>().Add(entities);
            return tracking.Entity;
        }

        public virtual void AddRange<T>(IList<T> entities) where T : class
        {

            _ctx.Set<T>().AddRange(entities);

        }

        public virtual int SaveChanges()
        {
            
            return _ctx.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }


        public virtual T UpdateItem<T>(T entity) where T : class
        {
            _ctx.Update(entity);
            return entity;

        }

        public virtual void HardDelete<T>(T entity) where T : class
        {
            _ctx.Attach(entity);           
            _ctx.Entry(entity).State = EntityState.Deleted;
        }

        //This method can only used in Connected Scenarios only
        public virtual void HardDeleteRange<T>(IList<T> entities) where T : class
        {
            _ctx.Set<T>().RemoveRange(entities);
        }

        public virtual void SoftDelete<T>(T entity) where T : class, IDeletable
        {
            _ctx.Entry(entity).CurrentValues["IsDeleted"] = true;         

        }

        public virtual async Task<T> GetAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            var qry = _ctx.Set<T>().Where(predicate);
            return await Task.FromResult(qry.FirstOrDefault());
        }

        public virtual IQueryable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            var qry = _ctx.Set<T>().Where(predicate);
            return qry;
        }

        public virtual T Find<T>(params object[] keyvals) where T : class
        {
            var qry = _ctx.Set<T>().Find(keyvals);
            return qry;
        }

        public virtual IQueryable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, string children) where T : class
        {
            var qry = _ctx.Set<T>().Where(predicate);
            return qry.Include(children);
        }


        public virtual IQueryable<T> GetMany<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            var qry = _ctx.Set<T>().Where(predicate);
            return qry;
        }
        public virtual IQueryable<T> GetAll<T>() where T : class
        {
            return _ctx.Set<T>();
        }

        

        public void DetachEntities<T>() where T : class
        {
            _ctx.ChangeTracker.Entries<T>().ToList().ForEach(x => x.State = EntityState.Detached);
        }

        public IQueryable<T> GetFilterData<T>(string[] role, Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetFilterData<T>(string[] role) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
