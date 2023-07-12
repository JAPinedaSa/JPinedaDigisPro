using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SLWeb_Api.Controllers
{
    public class MateriaController : ApiController
    {

        // GET: Materia
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {

            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);

            }
        }

        // GET: Materia
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetById/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {

            ML.Result result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);

            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/Delete/{IdMateria}")]
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Aseguradora/Update/{IdMateria}")]
        public IHttpActionResult Update(int IdMateria, [FromBody] ML.Materia materia)
        {
            materia.IdMateria = IdMateria;

            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);
            }

        }
    }
}