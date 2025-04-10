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
    public class JobsController : Controller
    {
        IJobsDao dao = new JobsDaoImpl();
        // GET: Jobs
        public ActionResult Listar()
        {
            return View(dao.OperacionesLectura("listar", new Jobs()));
        }
    }
}