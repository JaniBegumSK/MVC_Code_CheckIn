using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandu.Models;

namespace Pandu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usertable u)
        {
            if(ModelState.IsValid)
            {
                using(janiEntities jb=new janiEntities())
                {
                    var v = jb.Usertables.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if(v!=null)
                    {
                        Session["LogedUsername"] = v.Username.ToString();
                        Session["Loged Password"] = v.Password.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }
        public ActionResult AfterLogin()
        {
            if(Session["LogedUsername"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
           
        }
    }
}