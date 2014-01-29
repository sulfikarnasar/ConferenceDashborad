using ConferenceDashborad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceDashborad.Controllers
{
     [Authorize]
    public class DashBoardController : Controller
    {
        //
        // GET: /DashBoard/

        public ActionResult Index()
        {
            return View();
        }
        public class DelgatesClass
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
        public JsonResult getCandidates()
        {
            UsersContext db = new UsersContext();
           
           // var user = HttpContext.User.Identity.Name;
                var user = "suneer@gmail.com";
                var district = (from c in db.UserProfiles where c.UserName == user select c.District).SingleOrDefault();
                var areaList = (from c in db.AreaSettingss where c.District == district select c).ToList();
                //var candidateList = (from c in db.Delegates where c.AreaId = 
                //    (from d in db.AreaSettingss where d.District==district select d.AreaId)) 
                //select c)
                List<ConferenceDashborad.Models.Delegate> delegate_s = new List<Models.Delegate>();
                //var del_data="";
                
                    //foreach (AreaSettings d in areaList)
                    //{
                    //    var del_data = (from c in db.Delegates where c.AreaId == d.AreaId select c).ToList();
                    //     foreach(ConferenceDashborad.Models.Delegate dd in  del_data)
                    //     {
                    //          ConferenceDashborad.Models.Delegate dobj = new Models.Delegate();

                    //           dobj.Name = dd.Name;
                    //           dobj.Gender = dd.Gender;
                    //           dobj.Age = dd.Age;
                    //           dobj.Cls = dd.Cls;
                    //           dobj.School = dd.School;
                    //           dobj.Address = dd.Address;
                    //           dobj.AreaId = dd.AreaId;
                    //           dobj.Contact = dd.Contact;
                    //           delegate_s.Add(dobj);
                    //     }
                        

                    //}
                    var dummy_data = (from st in db.Delegates join ar in db.AreaSettingss on st.AreaId equals ar.AreaId into data1 from dd in data1 join use in db.UserProfiles on dd.District equals use.District where use.UserName=="suneer@gmail.com" select  st ).ToList();
                   
                    JsonResult data = Json(new { data = dummy_data }, JsonRequestBehavior.AllowGet);
                   

                    return Json(new { data = dummy_data,data1=areaList }, JsonRequestBehavior.AllowGet);
        }
    }
}
