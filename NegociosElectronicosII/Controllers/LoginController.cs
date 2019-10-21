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
            string pass;
            String Message = String.Empty;

            if (db.NE_Usuario.Any(x => x.CorreoElectronico == model.Email && x.Activo))
            {
                user = db.NE_Usuario.Where(x => x.CorreoElectronico == model.Email).First();
                pass = Security.Security.Encrypt(model.Password);
                if (!db.NE_Autenticacion.Any(x => x.UsuarioId == user.UsuarioId && x.Contrasena == pass))
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
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        user = db.NE_Usuario.Where(x => x.CorreoElectronico == model.Email).First();
                        userAuth = db.NE_Autenticacion.Where(x => x.UsuarioId == user.UsuarioId).First();
                        userAuth.Intentos = 0;
                        userAuth.UltimoInicioSesion = DateTime.Now;
                        db.SaveChanges();
                        ViewBag.Message = "Bienvenido";
                        return RedirectToAction("Index", "Panel");
                    }


                }

            }
            else
            {
                ViewBag.Message = "Cuenta no encontrada";
                return View(model);
            }
        }

        public ActionResult RecoveryPass()
        {
            return View();
        }


        [HttpPost]
        public JsonResult IsEmailValid(String userCode, String email)
        {
            try
            {
                if (db.NE_Usuario.Any(x => x.CorreoElectronico.ToUpper() == email.ToUpper()))
                {
                    //get user
                    NE_Usuario user = db.NE_Usuario.Where(x => x.CorreoElectronico.ToUpper() == email.ToUpper()).First();
                    //add confirmed request
                    NE_R recovery = new Tb_RecoveryPass()
                    {
                        Email = user.Email,
                        RecordDate = DateTime.Now,
                        ExpiredDate = DateTime.Now.AddDays(1),
                        IsConfirmed = false,
                    };
                    db.Tb_RecoveryPass.Add(recovery);
                    db.SaveChanges();

                    //fill template
                    String template = db.Tb_EmailsTemplate.Where(x => x.Name == "RecoveryPass").First().EmailTemplate;
                    template = String.Format(template, user.Name + " " + user.LastName, Settings.URL_TOConfirmEmail + recovery.ID_RecoveryPass.ToString(), "jf.castanion@hotmail.com");
                    //create Instance
                    Mail mail = new Mail()
                    {
                        AccountServer = Settings.ACCOUNT_SERVER,
                        Subject = Resources.TitleEmail_1,
                        From = Settings.FROM,
                        Host = Settings.HOST_SERVER,
                        PasswordServer = Settings.PASSWORD_SERVER,
                        Body = template,
                        To = new List<string>() { user.Email },
                        Port = Settings.PORT_SERVER
                    };
                    mail.Send();

                    return Json(new { Success = true, Message = Resources.AlertEmailAccountConfirm }, JsonRequestBehavior.DenyGet);
                }
                else
                    return Json(new { Success = false, Message = Resources.AlertEmailCodeIncorrect }, JsonRequestBehavior.DenyGet);

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = Resources.AlertErrorMessage }, JsonRequestBehavior.DenyGet);
            }
        }
    }

}
