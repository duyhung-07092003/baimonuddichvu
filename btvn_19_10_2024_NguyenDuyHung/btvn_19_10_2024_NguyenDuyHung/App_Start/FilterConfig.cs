using System.Web;
using System.Web.Mvc;

namespace btvn_19_10_2024_NguyenDuyHung
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
