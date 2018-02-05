using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Reviso.TimeSheet.Entities;
using Reviso.TimeSheet.Repositories.Repository.Interfaces;
using Abp.Application.Services;

namespace Reviso.TimeSheet.Repositories.Repository
{
    public class CustomerRepository : ApplicationService, ICustomerRepository
    {

        protected DbSet<CustomerEntity> _dbSet;
        protected TimeSheetContext _dataContext;

        public CustomerRepository()
        {
            var dataContext = new TimeSheetContext();
            this._dbSet = dataContext.Set<CustomerEntity>();
            this._dataContext = dataContext;
        }

        public CustomerEntity GetSingle(int id)
        {
            var query = GetAll().FirstOrDefault(c => c.Id == id);
            return query;
        }
   
        public IQueryable<CustomerEntity> FindBy(Expression<Func<CustomerEntity, bool>> predicate)
        {
            IQueryable<CustomerEntity> query = _dbSet.Where(predicate);
            return query;
        }

        public IQueryable<CustomerEntity> GetAll()
        {
            return _dbSet;
        }

        public CustomerEntity Add(CustomerEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public void Delete(CustomerEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(CustomerEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
