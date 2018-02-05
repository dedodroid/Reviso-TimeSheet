using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Reviso.TimeSheet.WebApi.App_Start
{
    public class FilterConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            //TODO: Handle authorize with JWT  
            //config.Filters.Add(new AuthorizeAttribute());
        }
    }
}