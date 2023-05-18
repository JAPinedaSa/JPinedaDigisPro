
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //TECNOLOGIA ENTITY FRAMEWORK
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.JPinedaDigisProEntities context = new DL.JPinedaDigisProEntities())
                {
                    int RowsAffected = context.MateriaAdd(materia.Nombre, materia.Costo);

                    if (RowsAffected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al ingresar el materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JPinedaDigisProEntities context = new DL.JPinedaDigisProEntities())
                {
                    int RowsAffected = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    if (RowsAffected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al Actualizar el materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JPinedaDigisProEntities context = new DL.JPinedaDigisProEntities())
                {
                    int query = context.MateriaDelete(IdMateria);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al eliminar el Usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JPinedaDigisProEntities context = new DL.JPinedaDigisProEntities())
                {
                    var query = context.MateriaGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;

                            result.Objects.Add(materia);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JPinedaDigisProEntities context = new DL.JPinedaDigisProEntities())
                {
                    var query = context.MateriaGetById(IdMateria).FirstOrDefault();
                    if(query != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo.Value;

                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Hubo un error" +ex.Message;
            }
            return result;
        }


    }
}
