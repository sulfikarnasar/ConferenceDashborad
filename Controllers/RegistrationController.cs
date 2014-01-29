using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConferenceDashborad.Models;
using Newtonsoft.Json;
using WebMatrix.WebData;
namespace ConferenceDashborad.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {

            return View();
        }
        
        public class pass
        {
            public string password { get; set; }
        }
        [HttpPost]
        [AllowAnonymous]
        public void Register(string data)
        {
            
            pass p = JsonConvert.DeserializeObject<pass>(data.ToString());
            UserProfile usr = JsonConvert.DeserializeObject<UserProfile>(data.ToString());
            WebSecurity.CreateUserAndAccount(usr.UserName, p.password, new  {Name=usr.Name,District=usr.District,Contact=usr.Contact,Status=false,UserType="User" });
            WebSecurity.Login(usr.UserName, p.password);
        }
    }
}
