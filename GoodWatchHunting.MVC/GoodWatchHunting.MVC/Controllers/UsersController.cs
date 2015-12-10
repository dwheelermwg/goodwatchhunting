using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GoodWatchHunting.Services;

namespace GoodWatchHunting.MVC.Controllers
{
  public class UsersController : Controller
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    // GET: /Users
    public ActionResult Index()
    {
      return View();
    }
  }
}