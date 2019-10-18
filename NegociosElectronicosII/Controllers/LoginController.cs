using NegociosElectronicosII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    public class LoginController : BaseController
    {
        
        public ActionResult Index()
        {
            ViewBag.Message = String.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            String Message = String.Empty;
            if (ModelState.IsValid)
            {
                if (db.NE_Usuario.Any(x => x.CorreoElectronico == model.Email))
                {
                    NE_Usuario usuario = db.NE_Usuario.Where(x => x.CorreoElectronico == model.Email).First();
                    //return RedirectToAction("Index", "Productos");
                }
                else
                {
                    Message = "Usuario no registrado";
                }
            }
            ViewBag.Message = Message;
            return View(model);
        }

    }
}