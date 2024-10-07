using System.Web;
using System.Web.Mvc;

namespace btvn_tuan2_nguyenduyhung
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
