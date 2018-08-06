using System.Web;
using System.Web.Mvc;

namespace KucnaKolekcijaKnjiga_VegaIT.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
