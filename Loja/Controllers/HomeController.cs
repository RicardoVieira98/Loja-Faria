﻿using Loja.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Loja.Controllers
{
    /// <summary>
    /// 
    /// Sumário serve para expor informação adicional aos comentários ou para informar todos os bugs na aplicação em causa.
    /// 
    /// TODO:
    /// 
    ///     -Criar helper para sumariar os servicos que o web api tem e expolos aqui.
    ///     - Criar helper para sumariar os WebApi controller que  o web api tem.
    ///     - Validar data enviada para web service.
    /// </summary>
    public class HomeController : Controller
    {
        readonly private WebServiceRequest webShared = new WebServiceRequest();
        const string seccoes = "Bijutaria;Lembrancas;Religiosos;Diversos";
        public ActionResult Index()
        {
            ViewBag.Seccoes = seccoes;
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Us()
        {
            return View();
        }
        public ActionResult Store()
        {
            string[] urlParams = HttpContext.Request.Url.ToString().Split('/');
            string extraInfo = urlParams[5].ToUpper().First() + "-" + " ";
            List<Produto> produtos = webShared.CallWebService("web","GetProduct", extraInfo,false);
            ViewBag.Seccao = urlParams[5]; 
            ViewBag.Produtos = produtos;
            return View();
        }
    }
}