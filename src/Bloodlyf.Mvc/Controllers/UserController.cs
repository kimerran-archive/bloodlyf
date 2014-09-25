using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bloodlyf.Api.User;
using Bloodlyf.Domain;

namespace Bloodlyf.Mvc.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(string u, string p)
        {

            var user = _userService.Login(u, p);

            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _userService.Create(user);
            return View();
        }
    }
}