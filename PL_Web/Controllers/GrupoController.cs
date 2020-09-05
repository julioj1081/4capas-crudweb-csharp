using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using BL;
using ET;
namespace PL_Web.Controllers
{
    public class GrupoController : Controller
    {
        public GrupoBL grupoBL = new GrupoBL();

        // GET: Grupo
        public ActionResult Index()
        {
            return View(grupoBL.Listar());
        }


        public ActionResult Editar(int id = 0)
        {
            ViewBag.Grupos = grupoBL.Listar();
            return View(id == 0 ? new Grupo() : grupoBL.Obtener(id));
        }


        public ActionResult Guardar(Grupo grupo)
        {
            var r = grupo.id > 0 ?
                    grupoBL.Actualizar(grupo) :
                    grupoBL.Registrar(grupo);
            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }
            return RedirectToAction("Index");
        }



        public ActionResult Eliminar(int id)
        {
            var r = grupoBL.Eliminar(id);
            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }
            return RedirectToAction("Index");
        }
    }
}