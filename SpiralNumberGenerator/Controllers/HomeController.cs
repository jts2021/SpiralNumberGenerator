using BusinessLogic;
using System.Web.Mvc;

namespace DeveloperCodeTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Index(int inputNumber)
        {
            SpiralGenerator sg = new SpiralGenerator();

            int?[,] arr = sg.Generate(inputNumber);

            return View(arr);
        }
    }
}