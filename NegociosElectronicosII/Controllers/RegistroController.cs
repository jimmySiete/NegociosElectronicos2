using NegociosElectronicosII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    public class RegistroController : BaseController
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }
    }
}