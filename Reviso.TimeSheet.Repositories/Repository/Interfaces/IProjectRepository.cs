using Reviso.TimeSheet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviso.TimeSheet.Repositories.Repository.Interfaces
{
    public interface IProjectRepository : IGenericRepository<ProjectEntity>
    {
        ProjectEntity GetSingle(int id);
    }
}
