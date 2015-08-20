using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cadastro.NHibernate.Repository;
using Cadastro.Entidades;

namespace Cadastro.Web.Controllers
{
    public class HomeController : Controller
    {
        private DadosCadastraisRepository _dadosRep;
        // GET: Home
        public ActionResult Index()
        {
            _dadosRep = new DadosCadastraisRepository();

            IList<DadosCadastrais> dados = _dadosRep.Consultar();
            return View(dados);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Create(DadosCadastrais lItem)
        {
            _dadosRep = new DadosCadastraisRepository();

            try
            {
                _dadosRep.Inserir(lItem);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(DadosCadastrais lItem)
        public ActionResult Delete(int lItem)
        {
            _dadosRep = new DadosCadastraisRepository();

            try
            {
                DadosCadastrais reg = _dadosRep.ObtemPorId(lItem);
                _dadosRep.Excluir(reg);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int lItem)
        {
            _dadosRep = new DadosCadastraisRepository();

            DadosCadastrais reg = _dadosRep.ObtemPorId(lItem);

            return View("Editar", reg);
        }
        public ActionResult Editar(DadosCadastrais lItem)
        {
            _dadosRep = new DadosCadastraisRepository();

            try
            {
                _dadosRep.Alterar(lItem);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return RedirectToAction("Index");
        }
    }
}