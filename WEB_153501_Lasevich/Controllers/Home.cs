using Microsoft.AspNetCore.Mvc;

namespace WEB_153501_Lasevich.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		
	}
}
