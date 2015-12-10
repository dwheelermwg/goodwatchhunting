using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GoodWatchHunting.Services;

namespace MvcAdminTemplate.Controllers
{
  public class HomeController : Controller
  {
    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
      _userService = userService;
    }

    public ActionResult Index()
    {
      // Example usage: var users = _userService.GetAllUsers();
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}