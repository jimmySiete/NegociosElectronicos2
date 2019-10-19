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
            NE_Autenticacion userAuth = new NE_Autenticacion();
            NE_Usuario user = new NE_Usuario();
            String Message = String.Empty;

            if (db.NE_Usuario.Any(x => x.CorreoElectronico == model.Email && x.Activo))
            {
                user = db.NE_Usuario.Where(x => x.CorreoElectronico == model.Email).First();
                if (!db.NE_Autenticacion.Any(x => x.UsuarioId == user.UsuarioId && x.Contrasena == model.Password))
                {
                    userAuth = db.NE_Autenticacion.Where(x => x.UsuarioId == user.UsuarioId).First();
                    userAuth.Intentos = userAuth.Intentos + 1;
                    if (userAuth.Intentos >= 5)
                    {
                        userAuth.CuentaBloqueada = true;
                        db.SaveChanges();
                        ViewBag.Message = "Cuenta Bloqueada";
                        return View(model);

                    }
                    db.SaveChanges();
                    ViewBag.Message = "Contraseña Incorrecta";
                    return View(model);
                }
                else
                {
                    userAuth = db.NE_Autenticacion.Where(x => x.UsuarioId == user.UsuarioId).First();
                    if (userAuth.CuentaBloqueada)
                    {
                        ViewBag.Message = "Cuenta Bloqueada";
                        return View(model);
                    }
                    else
                    {
                        user = db.NE_Usuario.Where(x => x.CorreoElectronico == model.Email).First();
                        userAuth = db.NE_Autenticacion.Where(x => x.UsuarioId == user.UsuarioId).First();
                        userAuth.Intentos = 0;
                        userAuth.UltimoInicioSesion = DateTime.Now;
                        db.SaveChanges();
                        ViewBag.Message = "Bienvenido";
                        return View(model);
                    }


                }

            }
            else
            {
                ViewBag.Message = "Cuenta no encontrada";
                return View(model);
            }



        }
        //if (ModelState.IsValid)
        //{
        //    if (db.NE_Usuario.Any(x => x.CorreoElectronico == model.Email))
        //    {
        //        NE_Usuario usuario = db.NE_Usuario.Where(x => x.CorreoElectronico == model.Email).First();
        //        //return RedirectToAction("Index", "Productos");
        //    }
        //    else
        //    {
        //        Message = "Usuario no registrado";
        //    }
        //}
        //ViewBag.Message = Message;
        //return View(model);
    }

}
