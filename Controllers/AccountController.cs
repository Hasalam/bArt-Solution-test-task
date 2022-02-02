using bArt_Test_task.Data;
using bArt_Test_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bArt_Test_task.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBcontext _db;

        private Account _account;

        private IMemoryCache cache;

        public AccountController(ApplicationDBcontext db, IMemoryCache memory)
        {
            _db = db;
            cache = memory;
            _account = memory.Get(1) as Account;
        }

        public IActionResult Index()
        {
            if (_account==null)
            {
                return RedirectToAction("Index","Login");
            }
            var Contacts = from b in _db.Contact.Include(c => c.Account) where b.AccountId == _account.Name select b;

            _account.Contacts = Contacts.ToList();
            return View(Contacts.ToList());
        }

        public IActionResult CreateContactInRegistration()
        {
            return View();
        }

        public IActionResult CreateContactInRegistrationPost(Contact obj)
        {
            _db.Account.Add(_account);
            _db.SaveChanges();
            if (ModelState.IsValid)
            {
                obj.AccountId = _account.Name;
                _db.Contact.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult CreateContact()
        {
            return View();
        }

       

        public IActionResult CreateContact(Contact obj)
        {
            if (ModelState.IsValid)
            {
                obj.AccountId = _account.Name;
                _db.Contact.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        public IActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
            {
                return NotFound();
            }
            var obj = _db.Contact.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Contact.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        public IActionResult ViewIncident()
        {
            if (_account == null)
            {
                return RedirectToAction("Index", "Login");
            }
            AddingIncident Inc = new AddingIncident();
            Inc.Incident = _db.Incident.Find(_account.IncidentId);
            if (Inc.Incident != null)
            {
                List<Account> AccInvolved = _db.Account.Where(u => u.IncidentId == Inc.Incident.IncidentName).ToList();
                foreach (Account acc in AccInvolved)
                {
                    Inc.Accounts += acc.Name + " ";
                }
            }
            return View(Inc);
        }

        public IActionResult CreateIncident()
        {
            if (_account.IncidentId!=null)
            {
                return View();
            }
            return RedirectToAction("ViewIncident");
        }
        
        public IActionResult CreateIncidentPost(AddingIncident Inc)
        {   
            List<string> AccountsName=Inc.Accounts.Split(',',' ').ToList();
            List<Account> Accounts = new List<Account>();
            Inc.Incident.Accounts =new List<Account>();
            foreach (string name in AccountsName)
            {
                Account acc=_db.Account.Find(name);
                if (acc == null)
                {
                    return NotFound();
                    //return RedirectToAction("ViewIncident");
                }
                else
                {
                    Accounts.Add(acc);
                    Inc.Incident.Accounts.Add(acc);
                }
            }
            _db.Incident.Add(Inc.Incident);
            _db.SaveChanges();
            foreach (Account acc in Accounts)
            {
                acc.IncidentId = Inc.Incident.IncidentName;
                _db.Account.Update(acc);
            }
            _account.IncidentId = Inc.Incident.IncidentName;
            return RedirectToAction("ViewIncident");
        }
        
        public IActionResult DeleteIncident()
        {
            var obj = _db.Incident.Find(_account.IncidentId);

            if (obj == null)
            {
                return NotFound();
            }
            List<Account> Accounts = (from b in _db.Account.Include(c => c.Incident) where b.IncidentId == _account.IncidentId select b).ToList();
            foreach (Account acc in Accounts)
            {
                acc.IncidentId = null;
                _db.Account.Update(acc);
            }
            _db.Incident.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("ViewIncident");
        }


    }
}
