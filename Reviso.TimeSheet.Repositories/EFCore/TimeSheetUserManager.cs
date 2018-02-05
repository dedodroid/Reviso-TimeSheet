using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reviso.TimeSheet.Repositories
{
    public class TimeSheetUserManager : UserManager<IdentityUser>
    {
        public TimeSheetUserManager() : base(new TimeSheetUserStore())
        {
        }
    }
}