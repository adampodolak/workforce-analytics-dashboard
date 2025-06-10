using Microsoft.AspNetCore.Mvc;

namespace WorkforceAnalyticsDashboard.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
