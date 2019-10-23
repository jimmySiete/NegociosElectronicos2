using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.GlobalCode
{
    public class Settings
    {
        #region Config

        private static DB_NE_Entitties _db;
        public static DB_NE_Entitties db
        {
            get
            {
                if (_db == null)
                    _db = new DB_NE_Entitties();
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        #endregion

        //private static String GetValueFromSettings(String Key)
        //{
        //    return db.Tb_Settings.Where(x => x.Key == Key).First().Value;
        //}

        public static NE_Usuario LoggedUser
        {
            get
            {
                if (HttpContext.Current.Session["MIA_Session"] == null)
                    return null;
                return (NE_Usuario)HttpContext.Current.Session["MIA_Session"];
            }
            set
            {
                HttpContext.Current.Session["MIA_Session"] = value;
            }
        }

        //public static string ACCOUNT_SERVER
        //{
        //    get
        //    {
        //        return Settings.GetValueFromSettings("ACCOUNT_SERVER");
        //    }
        //}

        //public static string FROM
        //{
        //    get
        //    {
        //        return Settings.GetValueFromSettings("FROM_SERVER");
        //    }
        //}

        //public static string HOST_SERVER
        //{
        //    get
        //    {
        //        return Settings.GetValueFromSettings("HOST_SERVER");
        //    }
        //}

        //public static string PASSWORD_SERVER
        //{
        //    get
        //    {
        //        return Settings.GetValueFromSettings("PASSWORD_SERVER");
        //    }
        //}

        //public static int? PORT_SERVER
        //{
        //    get
        //    {
        //        String PORT = Settings.GetValueFromSettings("PORT_SERVER");
        //        if (String.IsNullOrEmpty(PORT))
        //            return null;
        //        else
        //            return Int32.Parse(PORT);
        //    }
        //}

        //public static string URL_TOConfirmEmail
        //{
        //    get
        //    {
        //        return WebConfigurationManager.AppSettings["URL_TOConfirmEmail"];
        //    }
        //}

        //Generate new code to new user
        public static string GetNewSuggestCode()
        {
            Int32 consecutive = db.NE_Usuario.Any() ? db.NE_Usuario.Max(x => x.UsuarioId) + 1 : 0;
            String CoreCode = consecutive.ToString().PadLeft(6, '0');
            return String.Format("X_{0}", CoreCode);
        }

        //public static Int32 GetPermission(String KEY)
        //{
        //    return db.Tb_Permission.Where(x => x.Description == KEY).First().ID_Permission;
        //}
    }
}