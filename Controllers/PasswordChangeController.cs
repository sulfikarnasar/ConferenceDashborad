using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace ConferenceDashborad.Controllers
{
     [Authorize]
    public class PasswordChangeController : Controller
    {
        //
        // GET: /PasswordChange/
       
        public ActionResult Index()
        {
            return View();
        }
        public class Changepass
        {
            public string CurrentPass { get; set; }
            public string NewPass { get; set; }
        }
        [HttpPost]
        public JsonResult ResetPassword(string data)
        {
            Changepass cr = JsonConvert.DeserializeObject<Changepass>(data.ToString());
            string username = HttpContext.User.Identity.Name;
            var response= WebSecurity.ChangePassword(username,cr.CurrentPass,cr.NewPass);
            string res = string.Empty;
            if (response == true)
            {
                res = "success";
            }
            else
            {
                res = "fail";
            }
            return Json(new { data = res },JsonRequestBehavior.AllowGet);
        }
    }
}
