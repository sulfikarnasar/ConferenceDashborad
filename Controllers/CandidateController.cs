using ConferenceDashborad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceDashborad.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {
        //
        // GET: /Candidate/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult getAreaList()
        {
            try
            {
                using (UsersContext db = new UsersContext())
                {
                    var user = HttpContext.User.Identity.Name;
                    var district = (from c in db.UserProfiles where c.UserName.Equals(user) select c).SingleOrDefault();
                    var areaList = (from c in db.AreaSettingss where c.District.Equals(district.District) select c).ToList();
                    return Json(new { data = areaList }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                return Json(new { data = "fail" }, JsonRequestBehavior.AllowGet);
            }
            

        }
        public class candiData
        {
           
            public string Name { get; set; }
            public bool Gender { get; set; }
            public int Age { get; set; }
            public string Cls { get; set; }
            public string School { get; set; }
            public string Address { get; set; }
            public int AreaId { get; set; }
            public string Contact { get; set; }
        }
        [HttpPost]
        public JsonResult submitData(string data)
        {
            try
            {
                using (UsersContext db = new UsersContext())
                {
                    candiData cr = JsonConvert.DeserializeObject<candiData>(data.ToString());
                    
                    ConferenceDashborad.Models.Delegate dd = new Models.Delegate();
                    dd.Name = cr.Name;
                    dd.Gender = cr.Gender;
                    dd.Age = cr.Age;
                    dd.Cls = cr.Cls;
                    dd.School = cr.School;
                    dd.Address = cr.Address;
                    dd.AreaId = cr.AreaId;
                    dd.Contact = cr.Contact;
                    db.Delegates.Add(dd);
                    db.SaveChanges();
                    ConferenceDashborad.Hubs.BroadCast bb = new Hubs.BroadCast();
                    bb.Hello();
                    return Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                
                return Json(new { data = "fail" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
