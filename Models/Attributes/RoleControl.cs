using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Enums;

namespace Voyager.Models.Attributes
{
    public class RoleControl:ActionFilterAttribute
    {
        string pagerol = "0";
        public RoleControl(EnumRoles rolenumber)
        {
            pagerol = Convert.ToInt32(rolenumber).ToString();

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            string roles = context.HttpContext.User.Claims.ToArray()[1].Value;
            string[] userroles = roles.Split(";");
            bool yetkiVarmi = false;

            foreach (var item in userroles)
            {
                if (item== pagerol)
                {
                    yetkiVarmi = true;
                }
            }
            if (yetkiVarmi)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.HttpContext.Response.Redirect("/Error/YetkisizErisim");
            }

           
        }
    }
}
