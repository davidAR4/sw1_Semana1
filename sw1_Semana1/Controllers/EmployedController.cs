using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using sw1_Semana1.dao;
using sw1_Semana1.dao.DaoImpl;
using sw1_Semana1.Models;

namespace sw1_Semana1.Controllers
{
    public class EmployedController : Controller
    {
        IEmployedsDao dao = new EmployedDaoImpl();
        // GET: Employed
        public ActionResult Listar()
        {
            return View(dao.OperacionesLectura("listar", new Employeds()));
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.comboDepartament = new SelectList(listaDepartamentos(), "department_id", "department_name");
            ViewBag.combojobs = new SelectList(listaJobs(), "job_id", "job_title");
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Employeds objEmployeds)
        {
            int procesar = dao.operacionesEscritura("Insertar", objEmployeds);
            ViewBag.comboDepartament = new SelectList(listaDepartamentos(), "department_id", "department_name");
            ViewBag.combojobs = new SelectList(listaJobs(), "job_id", "job_title");
            if (procesar >= 0)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                ViewBag.mensajeError = "Ocurrió un problema al insertar";
                return View(objEmployeds);
            }
        }
        public List<Department> listaDepartamentos()
        {
            IDepartamentDao dao = new DepartamentImpl();
            List<Department> lista = dao.operacionesEscritura("listar", new Department());
            return lista;
        }
        public List<Jobs> listaJobs()
        {
            IJobsDao dao = new JobsDaoImpl();
            List<Jobs> lista = dao.OperacionesLectura("listar", new Jobs());
            return lista;
        }


        [HttpGet]
        public ActionResult ObteneriD()
        {
            return RedirectToAction("Listar");
        }


        [HttpPost]
        public ActionResult ObtenerID(int id) {
            Employeds employeds = dao.OperacionesLectura("buscariD", new Employeds { employe_id = id }).FirstOrDefault();
            if (employeds == null)
            {
                // Si no se encuentra la región, se muestra un mensaje en la vista
                ViewBag.Message = "Región no encontrada";
                return View("Listar", new List<Employeds>());
            }


            return View("Listar", new List<Employeds> { employeds });
        }
    

        [HttpGet]
        public ActionResult Accion_eliminar() {
            return View();
        }
        [HttpPost]
        public ActionResult Accion_eliminar(int id) {
            int employed = dao.operacionesEscritura("eliminar", new Employeds { employe_id = id });
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Accion_editar(int id) { 
        Employeds employed = dao.OperacionesLectura("buscariD", new Employeds { employe_id = id }).FirstOrDefault();
            ViewBag.comboDepartament = new SelectList(listaDepartamentos(), "department_id", "department_name");
            ViewBag.combojobs = new SelectList(listaJobs(), "job_id", "job_title");
            return View(employed);
        }

        [HttpPost]
        public ActionResult Accion_editar(Employeds employeds) {
        
            int procesar = dao.operacionesEscritura("Actualizar", employeds);


            if (procesar <= 0)
            {
                ViewBag.Message = "No se pudo actualizar la región";
                return View(employeds);
            }

            ViewBag.Message = "Región actualizada correctamente";
            return RedirectToAction("Listar");
        }
    } 
}
