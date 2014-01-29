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
    public class AreaSettingsController : Controller
    {
        //
        // GET: /AreaSettings/

        public ActionResult Index()
        {
            return View();
        }
        public class AreaSett
        {

            public string District { get; set; }
            public string Area { get; set; }
        }
        [HttpPost]
        public JsonResult AreaSubmition(string data)
        {
            try
            {
                AreaSett AreaSet = JsonConvert.DeserializeObject<AreaSett>(data.ToString());
                UsersContext db = new UsersContext();
                AreaSettings ass = new AreaSettings();
                ass.District = AreaSet.District;
                ass.Area = AreaSet.Area;
                db.AreaSettingss.Add(ass);
                db.SaveChanges();
                return Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                //throw;
                return Json(new { data = "fail" }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}
