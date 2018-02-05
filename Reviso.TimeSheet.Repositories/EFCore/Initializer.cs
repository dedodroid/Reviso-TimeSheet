using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Reviso.TimeSheet.Repositories
{
    public class Initializer : MigrateDatabaseToLatestVersion<TimeSheetContext, Configuration>
    {
    }
}