using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sw1_Semana1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           
            return View();
        }

        public ActionResult Contact()


        {

            string url1 = ConfigurationManager.AppSettings["url_servicio_cliente"];

            ViewBag.url.Servicio.Cliente = url1;
            ViewBag.Message = "Pagina de contacto";
            ViewBag.nombre = "david";
            ViewBag.apellido = "anaya";
            ViewBag.codigoEstudiante = "4757747477";

            return View();
        }
    }
}