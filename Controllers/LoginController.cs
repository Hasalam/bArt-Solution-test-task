using bArt_Test_task.Data;
using bArt_Test_task.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBcontext _db;

        private readonly Account _account;

        public LoginController(ApplicationDBcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
