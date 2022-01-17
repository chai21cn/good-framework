using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace GoodFramework.Controllers
{
#if DEBUG
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            // return Redirect("~/swagger");
            return Redirect("http://localhost:3100/");
        }
    }
#endif
}
