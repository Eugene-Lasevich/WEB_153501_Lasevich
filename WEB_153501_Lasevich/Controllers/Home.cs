using Microsoft.AspNetCore.Mvc;
using WEB_153501_Lasevich.util;
using Microsoft.AspNetCore.Http;

namespace WEB_153501_Lasevich.Controllers
{

    public class Home : Controller
    {
        public IActionResult Index()

        {

            List<ListDemo> listDemo = new List<ListDemo>
            {
                new ListDemo { Id = 1, Name = "Элемент 1" },
                new ListDemo { Id = 2, Name = "Элемент 2" },
                new ListDemo { Id = 3, Name = "Элемент 3" }
            };

            ViewData["labVersionMessage"] = "Лабораторная работа #2";

            return View(listDemo);
        }

    }
}
