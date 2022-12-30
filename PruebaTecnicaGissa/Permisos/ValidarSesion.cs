using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGissa.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;


namespace PruebaTecnicaGissa.Permisos
{
    public class ValidarSesion : ActionFilterAttribute
    {
     

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            base.OnActionExecuting(context);
        }




    }
}
