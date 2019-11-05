using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace FestaMVC.Filtro
{
    public class Autenticacao : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var cookieSessao = filterContext.RequestContext.HttpContext.Request.Cookies["autenticacao"];

            var valorAutCookie = cookieSessao != null ? cookieSessao.Value : string.Empty;
            var valorAutSessao = filterContext.HttpContext.Session["autenticacao"];

            if (valorAutSessao == null || valorAutCookie == null || valorAutCookie.ToUpper() != valorAutSessao.ToString().ToUpper())
            {
                var direcaoLogin = new { Controller = "Login", action = "Index" };
               filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(direcaoLogin));
            }
        }
    }
}