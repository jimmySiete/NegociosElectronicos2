using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NegociosElectronicosII.GlobalCode;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    [NegociosII_Auth(Roles = "1")]
    public class EstadisticaController : BaseController
    {
        // GET: Estadistica
        public ActionResult Index()
        {
            return View();
        }
    }
}