using bArt_Test_task.Data;
using bArt_Test_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bArt_Test_task.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBcontext _db;

        private Account _account;

        private IMemoryCache cache;

        public LoginController(ApplicationDBcontext db, IMemoryCache memoryCache)
        {
            _db = db;
            cache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckPassword(string password, string name)
        {
            var Acc = _db.Account.Find(name);
            if (Acc == null)
            {
                return Json(false);
            }
            if (password == Acc.Password)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Account obj)
        {
            var Acc = _db.Account.Find(obj.Name);
            if (Acc == null)
            {
                _account = obj;
                cache.Set(1, _account);
                return RedirectToAction("CreateContactInRegistration", "Account");
            }
            _account = obj;
            return View(obj);
        }

        

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Account obj)
        {
            var Acc = _db.Account.Find(obj.Name);
            if (Acc == null)
            {
                return NotFound();
            }
            if (obj.Password == Acc.Password)
            {
                _account = obj;
                cache.Set(1, _db.Account.Find(_account.Name));
                return RedirectToAction("Index", "Account");
            }
            _account = obj;
            return View(obj);
        }
    }
}
