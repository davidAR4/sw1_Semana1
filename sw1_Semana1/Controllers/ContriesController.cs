using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sw1_Semana1.dao;
using sw1_Semana1.dao.DaoImpl;
using sw1_Semana1.Models;

namespace sw1_Semana1.Controllers
{
    public class ContriesController : Controller
    {
        ICountriesDao dao = new CountriesDaoImpl();
        // GET: Contries

        public ActionResult listarContries(Countries countries)
        {
            return View(dao.operacionesLectura("consultarTodo", new Countries()));
        }


        [HttpGet]
        public ActionResult ACCION_CREAR()
        {
            ViewBag.comboRegion = new SelectList(listaRegions(), "region_id", "region_name");
            return View();
        }


        [HttpPost]
        public ActionResult ACCION_CREAR(Countries objCountries)
        {
          int procesar =  dao.operacionesEscritura("Insertar", objCountries);
            ViewBag.comboRegion = new SelectList(listaRegions(), "region_id", "region_name");
            if (procesar >= 0)
            {

                return RedirectToAction("listarContries");
            }
            else {
                ViewBag.mensajeError = "ocurrio un problema al insertar";
                return View(objCountries);
            }

            

         

        }

        public List<Regions> listaRegions()
        {
            IRegionDao dao = new RegionDaoImpl();
            List<Regions> lista = dao.OperacionesLectura("consultarTodo", new Regions());
            return lista;
        }

    }
    }
