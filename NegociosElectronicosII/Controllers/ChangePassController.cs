using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    public class ChangePassController : BaseController
    {
        // GET: ChangePass
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Passwoord()
        {
            return PartialView();
        }
    }
}