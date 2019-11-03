using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    public class PrincipalController : BaseController
    {
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }
    }
}