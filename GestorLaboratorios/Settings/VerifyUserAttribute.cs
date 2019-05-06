
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GestorLaboratorios.Settings
{
    public class VerifyUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var user = filterContext.HttpContext.Session.GetString("id_usuario");
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    if (user == null)
                    {

                        filterContext.HttpContext.Response.StatusCode = 403;
                    }
                }
                else
                {
                    if (user == null)
                    {
                        filterContext.Result = new RedirectResult("~/Login/login");

                    }//RedirectToAction("Login/Se presento un inconveniente inesperado volver a intentar, si el incoveniente persiste comuniquese con el administrador", "Login", ModelState);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
