﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace PLN.Controllers
{
    public class MateriaController : Controller
    {
        ////GET: Materia
        public ActionResult GetAll()
        {


            ML.Materia resultMateria = new ML.Materia();
            resultMateria.Materias = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50390/api/");

                var responseTask = client.GetAsync("Materia/GetAll ");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia >(resultItem.ToString());
                        resultMateria.Materias.Add(resultItemList);
                    }
                }
            }
            return View(resultMateria);
        }
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
                      
            if (IdMateria == null)
            {

                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50390/api/");
                    var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Materia resultItemList = new ML.Materia();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Departamento";
                    }

                }


                //ML.Result result = BL.Aseguradora.GetById(idAseguradora.Value);
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;

                    ViewBag.Message = "Ocurrio un error al hacer la consulta:";


                    return View(materia);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta:" + result.ErrorMessage;
                    return View("Modal");
                }

            }


        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            if (materia.IdMateria == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50390/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var resultAseguradora = postTask.Result;
                    if (resultAseguradora.IsSuccessStatusCode)
                    {

                        //return RedirectToAction("GetAll");
                        ViewBag.Message = "El resigistro de Aseguradora a sido agrgado con exito";

                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al insertar el registro" + " " + result.ErrorMessage;
                    }
                   
                }

                return View("Modal");

                ////result = BL.Aseguradora.Add(materia);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "El resigistro de Aseguradora a sido agrgado con exito";
                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un error al insertar el registro" + " " + result.ErrorMessage;
                //}
            }
            else
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50390/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Aseguradora/Update/" + materia.IdMateria, materia);
                    postTask.Wait();

                    var resultAseguradora = postTask.Result;
                    if (resultAseguradora.IsSuccessStatusCode)
                    {

                        return RedirectToAction("GetAll");

                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al insertar el registro" + " " + result.ErrorMessage;
                    }

                }

                //result = BL.Aseguradora.Update(materia);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "El Registro de Aseguradora a sido Modificado con exito";
                //}
                //else
                //{
                //    ViewBag.Message = "Ocurrio un error al Modificar el registro" + " " + result.ErrorMessage;
                //}
            }
            return View("Modal");
        }
    }
}