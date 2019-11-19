using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegociosElectronicosII.Models
{
    public class VentasDetalle
    {
        public int? vehiculoid { get; set; }
        public int? productoid { get; set; }
        public int? cantidad { get; set; }
        public int? total { get; set; }
    }
}