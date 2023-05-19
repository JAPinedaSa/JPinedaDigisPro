using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PLN.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno

        [HttpGet]
        public ActionResult GetAll()
        {  
            ML.Alumno alumno = new ML.Alumno();

           
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

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            //ML.Usuario usuario = new ML.Usuario();
            //ML.Result resultUsuario = BL.Usuario.GetAll(usuario);
            ML.Alumno alumno = new ML.Alumno();
            //alumno.Usuario = new ML.Usuario();

            //if (resultUsuario.Correct)
            //{
            //    alumno.Usuario.Usuarios = resultUsuario.Objects;
            //}
            if (IdAlumno == null)
            {

                return View(alumno);
            }
            else
            {
                //ML.Result result = new ML.Result();

                AlumnoService.AlumnoClient alumnoGetById = new AlumnoService.AlumnoClient();
                var resultGetById = alumnoGetById.GetById(IdAlumno.Value);


                //ML.Result result = BL.Aseguradora.GetById(idAseguradora.Value);
                if (resultGetById.Correct)
                {
                    alumno = (ML.Alumno)resultGetById.Object;
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta:" + resultGetById.ErrorMessage;
                    return View("Modal");
                }

            }


        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            
            if (alumno.IdAlumno == 0)
            {
                AlumnoService.AlumnoClient alumnoAdd = new AlumnoService.AlumnoClient();
                var resultAdd = alumnoAdd.Add(alumno);

                
                if (resultAdd.Correct)
                {
                    ViewBag.Message = "El resigistro de Aseguradora a sido agrgado con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro" + " " + resultAdd.ErrorMessage;
                }

                return View("Modal");

                
            }
            else
            {

                AlumnoService.AlumnoClient alumnoUpdate = new AlumnoService.AlumnoClient();
                var resultUpdate = alumnoUpdate.Add(alumno);

               
                if (resultUpdate.Correct)
                {
                    ViewBag.Message = "El Registro de Aseguradora a sido Modificado con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al Modificar el registro" + " " + resultUpdate.ErrorMessage;
                }
            }
            return View("Modal");
        }
    }
}