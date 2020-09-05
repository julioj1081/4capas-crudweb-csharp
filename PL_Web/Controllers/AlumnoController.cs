using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using BL;
using ET;
namespace PL_Web.Controllers
{
    public class AlumnoController : Controller
    {
        private AlumnoBL alumnoBL = new AlumnoBL();
        private RolBL rolBL = new RolBL();
        private GrupoBL grupoBL = new GrupoBL();

        // Listado de todos los alumnos
        public ActionResult Index()
        {
            return View(alumnoBL.Listar());
        }


        //vista de editar y agregar solo le pasamos el parametro
        public ActionResult Editar(int id = 0)
        {
            ViewBag.Roles = rolBL.Listar();
            ViewBag.Grupos = grupoBL.Listar();
            return View(id == 0 ? new Alumno() : alumnoBL.Obtener(id));
        }


        //guardar alumnos si no lo edita
        public ActionResult Guardar(Alumno user)
        {
            var r = user.id > 0 ?
                   alumnoBL.Actualizar(user) : alumnoBL.Registrar(user);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/View/Shared/_Mensaje.cshtml");
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Eliminar(int id)
        {
            var r = alumnoBL.Eliminar(id);
            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensaje.cshtml");
            }
            return RedirectToAction("Index");
        }
    }
}