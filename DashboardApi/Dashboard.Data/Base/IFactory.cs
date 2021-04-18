using Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Data
{
    public interface IFactory
    {
        T Add<T>(T entities) where T : class;

        void AddRange<T>(IList<T> entities) where T : class;

        int SaveChanges();
        T Find<T>(params object[] keyvals) where T : class;

        Task<int> SaveChangesAsync();

        T UpdateItem<T>(T entity) where T : class;

        void HardDelete<T>(T entity) where T : class;

        //This method can only used in Connected Scenarios only
        void HardDeleteRange<T>(IList<T> entities) where T : class;

        void SoftDelete<T>(T entity) where T : class, IDeletable;

        Task<T> GetAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;

        IQueryable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;

        IQueryable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, string children) where T : class;

        IQueryable<T> GetMany<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetAll<T>() where T : class;

        IQueryable<T> GetFilterData<T>(string[] role, System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetFilterData<T>(string[] role) where T : class;

        void DetachEntities<T>() where T : class;

  

    }
}
