using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestaMVC.Models;
using FestaMVC.Repositorio;

namespace FestaMVC.Controllers
{
    public class FestaController : ControladorBaseController
    {
        //
        // GET: /Festa/

        public ActionResult Index()
        {
            var listaSexo = new List<dynamic>(){
                new { opcao = 1, descricao = "Masculino" },
                new { opcao = 2, descricao = "Feminino" },
                new { opcao = 3, descricao = "LGBTSKDJFKSJDFH++²" }
            };

            ViewBag.ListaOpcoesSexo = listaSexo;

            var listaFesta = new List<FestaModel>
            {
                new FestaModel(){ id=1 , Data = DateTime.Now, Nome="Festa Lucas", ValorDoIngresso = 54.00f},
                new FestaModel(){ id=2 , Data = DateTime.Now, Nome="Festa Felipe", ValorDoIngresso = 54.00f}
            };

            //RepositorioUniversal<FestaModel>.GravaListaDeObjetos(listaFesta);
            var listaFestaBanco = RepositorioUniversal<FestaModel>.RecuperaLista();


            return View(listaFestaBanco);

             
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FestaModel festaModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            RepositorioUniversal<FestaModel>.GravaObjeto(festaModel);
            
            return RedirectToAction("Index");
        }

    }
}
