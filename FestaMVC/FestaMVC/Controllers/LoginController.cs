using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestaMVC.Models;

namespace FestaMVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        const string login = "lucas";
        const string senha = "12345";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (loginModel.campoNome == login && loginModel.campoSenha == senha)
                {
                    CriaCookie();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public void CriaCookie()
        {
            var guidAutenticacao = Guid.NewGuid();

            var cookie = new HttpCookie("autenticacao");

            cookie.Expires = DateTime.Today.AddDays(1);

            cookie.Value = guidAutenticacao.ToString().ToUpper();

            Session["autenticacao"] = guidAutenticacao;

            Response.Cookies.Add(cookie);
        }
    }
}
