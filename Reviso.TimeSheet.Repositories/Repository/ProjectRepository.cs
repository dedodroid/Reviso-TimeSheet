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
    public class ProjectRepository : IProjectRepository
    {

        protected DbSet<ProjectEntity> _dbSet;
        protected TimeSheetContext _dataContext;

        public ProjectRepository()
        {
            var dataContext = new TimeSheetContext();
            this._dbSet = dataContext.Set<ProjectEntity>();
            this._dataContext = dataContext;
        }

        public ProjectEntity GetSingle(int id)
        {
            var query = GetAll().FirstOrDefault(c => c.Id == id);
            return query;
        }
   
        public IQueryable<ProjectEntity> FindBy(Expression<Func<ProjectEntity, bool>> predicate)
        {
            IQueryable<ProjectEntity> query = _dbSet.Where(predicate);
            return query;
        }

        public IQueryable<ProjectEntity> GetAll()
        {
            return _dbSet;
        }

        public ProjectEntity Add(ProjectEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public void Delete(ProjectEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(ProjectEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
