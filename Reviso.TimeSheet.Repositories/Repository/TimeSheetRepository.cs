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

namespace Reviso.TimeSheet.Repositories.Repository
{
    public class TimeSheetRepository : ITimeSheetRepository
    {

        protected DbSet<TimeSheetEntity> _dbSet;
        protected TimeSheetContext _dataContext;

        public TimeSheetRepository()
        {
            var dataContext = new TimeSheetContext();
            this._dbSet = dataContext.Set<TimeSheetEntity>();
            this._dataContext = dataContext;
        }

        public TimeSheetEntity GetSingle(int id)
        {
            var query = GetAll().Include(c => c.Customer).Include(d => d.Project).FirstOrDefault(c => c.Id == id);
            return query;
        }
   
        public IQueryable<TimeSheetEntity> FindBy(Expression<Func<TimeSheetEntity, bool>> predicate)
        {
            IQueryable<TimeSheetEntity> query = _dbSet.Where(predicate);
            return query;
        }

        public IQueryable<TimeSheetEntity> GetAll()
        {
            return _dbSet.Include(c => c.Customer).Include(d => d.Project);
        }

        public TimeSheetEntity Add(TimeSheetEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public void Delete(TimeSheetEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(TimeSheetEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
