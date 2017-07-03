using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController()
        {
            UserRepository = new UserRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Users = UserRepository.GetAll();

            return View();
        }

        public ActionResult View(long id)
        {
            var user = UserRepository.Get(id);

            return View(user);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}