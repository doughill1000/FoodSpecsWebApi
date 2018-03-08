using FoodSpecialsUI.Constants;
using System.Web.Mvc;

namespace FoodSpecialsUI.Controllers
{
    [Authorize(Roles = AuthConstants.Admin + "," +  AuthConstants.RestaurantManager)]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}