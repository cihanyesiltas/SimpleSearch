using Microsoft.AspNetCore.Mvc;

namespace SimpleSearch.Api.Controllers
{
 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}