using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sw1_Semana1.dao;
using sw1_Semana1.dao.DaoImpl;
using sw1_Semana1.Models;

namespace sw1_Semana1.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartamentDao dao = new DepartamentImpl();
        // GET: Department
        public ActionResult ACCION_LISTADO()
        {
            return View(dao.operacionesEscritura("listar", new Department()));
        }
    }
}