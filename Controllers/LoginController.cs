using ConferenceDashborad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ConferenceDashborad.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        UsersContext db = new UsersContext();
        public ActionResult Index()
        {
            return View();
        }
        public class Creadetials
        {
            public string Username { get; set; }
            public string password { get; set; }
        }
        [HttpPost]
        public JsonResult Loginmethod(string data)
        {
            string response = string.Empty;
            Creadetials cr = JsonConvert.DeserializeObject<Creadetials>(data.ToString());
            var res = false;
            if (cr.Username != null && cr.password != null)
            {
                res = WebSecurity.Login(cr.Username, cr.password);
            }
            if (res==true)
            {
                var userid = db.UserProfiles.Single(x => x.UserName == cr.Username);
                if (userid.UserType == "Admin")
                {

                    response = "Admin";
                    // return View("Admin/Index");
                }
                else if(userid.UserType=="User")
                {
                    response = "User";
                }
                
            }
            else
            {
                response = "failure";
                
            }

            return Json(new {data=response},JsonRequestBehavior.AllowGet);
        }
    }
}
