using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            //ML.Result result = BL.Aseguradora.GetAll();
            //aseguradora.Aseguradoras = result.Objects;
            AlumnoService.AlumnoClient alumnoGetAll = new AlumnoService.AlumnoClient();
            var resultGetAll = alumnoGetAll.GetAll();


            if (resultGetAll.Correct)
            {
                alumno.Alumnos = resultGetAll.Objects.ToList();
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al tratar de consultar la información";
            }
            return View(alumno);

        }
    }
}