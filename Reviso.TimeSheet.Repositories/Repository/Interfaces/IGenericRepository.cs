using Abp.Application.Services;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reviso.TimeSheet.Repositories.Repository.Interfaces
{
    public interface IGenericRepository<T> : IApplicationService where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
