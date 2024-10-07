using System.Web;
using System.Web.Mvc;

namespace ucln_ngaythang_snt
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
