using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using BL;
using ET;
namespace PL_Web.Controllers
{
    public class RolController : Controller
    {
        //private Rol rol = new Rol();
        private RolBL rolBL = new RolBL();

        // GET: Rol
        public ActionResult Index()
        {
            return View(rolBL.Listar());
        }



        public ActionResult Editar(int id = 0)
        {
            ViewBag.Roles = rolBL.Listar();
            return View(id == 0 ? new Rol() : rolBL.Obtener(id));
        }



        public ActionResult Guardar(Rol rol)
        {
            var r = rol.id > 0 ?
                    rolBL.Actualizar(rol) :
                    rolBL.Registrar(rol);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inseperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            var r = rolBL.Eliminar(id);
            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }
            return RedirectToAction("Index");
        }
    }
}