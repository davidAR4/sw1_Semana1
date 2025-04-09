using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using sw1_Semana1.Models;
using System.Configuration;
using System.Diagnostics;
using sw1_Semana1.dao;
using sw1_Semana1.dao.DaoImpl;
using Microsoft.Ajax.Utilities;

namespace sw1_Semana1.Controllers
{
    public class RegionController : Controller
    {
        IRegionDao dao = new RegionDaoImpl();
        // GET: Region

        public ActionResult Accion_listado()
        {

            return View(dao.OperacionesLectura("consultarTodo", new Regions()));
        }

        [HttpGet]
        public ActionResult Accion_crear()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Accion_crear(Regions objReg)
        {
            int procesar = dao.operacionesEscritura("Insertar", objReg);
            if (procesar >= 0)
            {
                return RedirectToAction("Accion_Listado");
            }
            Debug.WriteLine("Rpta operacionesEscritura: " + procesar);
            return View(objReg);
        }


        [HttpGet]
        public ActionResult accion_eliminar() { 
            return View();
        }


        [HttpPost]
        public ActionResult accion_eliminar(int id) 
        {
            int region = dao.operacionesEscritura("eliminar", new Regions { region_id = id });

            if (region >0) {
                
                return RedirectToAction("accion_Listado");
            }
            Debug.WriteLine("Rpta operacionesEscritura: " + region);
          

            return RedirectToAction("Accion_Listado");
        }


        [HttpGet]
        public ActionResult accion_editar(int id) {
            Regions region = dao.OperacionesLectura("actualidadazar", new Regions {region_id = id }).FirstOrDefault();
          
            
            if (region == null)
            {
                ViewBag.Message = "Región no encontrada";
                return View();
            }
            
            return View(region);
        }


        [HttpPost]

        public ActionResult accion_editar(Regions region)
        {
           
            if (region == null)
            {
                // Si no se encuentra la región, se muestra un mensaje en la vista
                ViewBag.Message = "Región no encontrada";
                return View(); 
            }
           
            int resultado = dao.operacionesEscritura("actualizar", region);

            if (resultado <= 0)
            {
                ViewBag.Message = "No se pudo actualizar la región";
                return View(region);
            }

            ViewBag.Message = "Región actualizada correctamente";
            return RedirectToAction("accion_listado"); 
        }

          

        [HttpGet]
        public ActionResult accion_buscarId()
        {
            return RedirectToAction("Accion_listado");
        }

        [HttpPost]
        public ActionResult accion_buscarId(int id)
        {
            // Llamada al DAO para buscar la región por id
            Regions region = dao.OperacionesLectura("consultarXdddtodo", new Regions { region_id = id }).FirstOrDefault();//sirve para recorrer toda la lista y verificar que el dato exista

            if (region == null)
            {
                // Si no se encuentra la región, se muestra un mensaje en la vista
                ViewBag.Message = "Región no encontrada";
                return View("Accion_listado", new List<Regions>());
            }

          
            return View("Accion_listado", new List<Regions> { region });
        }

    }
}
    
