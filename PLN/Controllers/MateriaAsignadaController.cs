using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLN.Controllers
{
    public class MateriaAsignadaController : Controller
    {
        // GET: MateriaAsignada
        [HttpGet]
        public ActionResult GetAllAlumno()
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
        public ActionResult GetAllMateriaAsignada(int IdAlumno, string Nombre, string ApellidoPaterno, string ApellidoMaterno)
        {
            ML.MateriaAsignada materiaAsignada = new ML.MateriaAsignada();
            ML.Result resultMatriasAsignada= BL.MateriaAsignada.GetAllMateriaAsignada(IdAlumno);
            materiaAsignada.MatriasAsignadasAlumnos = resultMatriasAsignada.Objects.ToList();
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            materiaAsignada.Alumno = (ML.Alumno)resultAlumno.Object;

            return View(materiaAsignada);
        }
        [HttpGet]
        public ActionResult GetAllMateriaNoAsignada(int IdAlumno)
        {
            ML.MateriaAsignada materiaNoAsignada = new ML.MateriaAsignada();
            ML.Result resultMateriasNoAsignadas = BL.MateriaAsignada.GetAllMateriaNoAsignada(IdAlumno);
            materiaNoAsignada.MatriasAsignadasAlumnos = resultMateriasNoAsignadas.Objects.ToList();
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            materiaNoAsignada.Alumno = (ML.Alumno)resultAlumno.Object;

            return View(materiaNoAsignada);
        }
        [HttpPost]
        public ActionResult Form(ML.MateriaAsignada materiasAlumnos)
        {
            ML.Result result = new ML.Result();
            foreach (string IdMateria  in materiasAlumnos.MatriasAsignadasAlumnos)
            {
                ML.MateriaAsignada rowMateriasAsignadas = new ML.MateriaAsignada();

                rowMateriasAsignadas.Alumno = new ML.Alumno();
                rowMateriasAsignadas.Alumno.IdAlumno = materiasAlumnos.Alumno.IdAlumno;

                rowMateriasAsignadas.Materia = new ML.Materia();
                rowMateriasAsignadas.Materia.IdMateria = int.Parse(IdMateria);

                ML.Result resultAddMateriasAsignadas = BL.MateriaAsignada.Add(rowMateriasAsignadas);
                
            }
            return View();

        }

    }
}