using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceDashborad.Controllers
{
    [Authorize]
    public class Use_rController : Controller
    {
        //
        // GET: /Use_r/

        public ActionResult Index()
        {
            return View();
        }

    }
}
