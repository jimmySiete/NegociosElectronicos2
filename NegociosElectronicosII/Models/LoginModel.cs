using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NegociosElectronicosII.Models
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceName ="Required",ErrorMessageResourceType =typeof(Recursos))]
        [Display(Name ="Email",ResourceType =(typeof(Recursos)))]
        public String Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Recursos))]
        [Display(Name = "Password", ResourceType = (typeof(Recursos)))]
        public String Password { get; set; }

    }
}