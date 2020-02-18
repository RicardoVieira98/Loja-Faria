﻿using Loja.Library;
using Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Loja.Dashboard.Controllers
{
    /// <summary>
    /// 
    /// Sumário serve para expor informação adicional aos comentários ou para informar todos os bugs na aplicação em causa.
    ///
    /// TODO:
    /// 
    ///     Quando dashboard efectua alteracoes a qql bd, chama o seu proprio API. quando apenas obtem informacao, chama os outros APIs
    /// </summary>
    public class DashboardController : Controller
    {
        readonly private WebServiceRequest webShared = new WebServiceRequest();
        readonly private WebServiceRequestPublic webSharedLibrary = new WebServiceRequestPublic();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tabelas(string message)
        {
            List<Produto> produtos = webShared.CallProdutoWebService("Dash", "GetProducts", "");
            List<Carrinho> carrinhos = webShared.CallCartWebService("Cart", "GetCarrinhos", "");
            List<User> users = webShared.CallUserWebService("User", "getAllUsers", "");
            ViewBag.AllProducts = produtos;
            ViewBag.AllCarts = carrinhos;
            ViewBag.AllUsers = users;
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Graficos()
        {
            return View();
        }
        public ActionResult Clientes()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult adicionarProduto(Produto prod)
        {
            string message = webSharedLibrary.CallWebService("Dash", "addProduct", new JavaScriptSerializer().Serialize(prod), false);
            return RedirectToAction("Tabelas", new { message = message });
        }

        [HttpPost]
        public RedirectToRouteResult adicionarTipo(SeccaoTipoProduto stp)
        {
            string message = webSharedLibrary.CallWebService("Dash", "addType", new JavaScriptSerializer().Serialize(stp), false);
            return RedirectToAction("Tabelas", new { message });
        }
        [HttpPost]
        public RedirectToRouteResult adicionarSeccao(SeccaoTipoProduto stp)
        {
            string message = webSharedLibrary.CallWebService("Dash", "addSection", new JavaScriptSerializer().Serialize(stp), false);
            return RedirectToAction("Tabelas", new { message });
        }
    }
}