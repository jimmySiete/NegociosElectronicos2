﻿using NegociosElectronicosII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    public class BaseController : Controller
    {
        public NE_Entities db = new NE_Entities();
    }
}