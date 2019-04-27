using System.Net;
using System.Web.Mvc;

namespace DADS.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }

        [HttpGet]

        public ActionResult Login(users model)
        {
            if(model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View("Index", User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp()
        {
            users newuser = new users();


            return View("Index", User);
        }

        [HttpGet]
        public ActionResult GameList(users model)
        {
            return View("../Game/GameView");    //change to GameList when made
        }
    }
}