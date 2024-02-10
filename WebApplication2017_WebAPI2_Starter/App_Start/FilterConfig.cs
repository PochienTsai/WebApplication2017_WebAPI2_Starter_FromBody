using System.Web;
using System.Web.Mvc;

namespace WebApplication2017_WebAPI2_Starter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
