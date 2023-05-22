using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MateriaAsignada
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaAlumnos = new DataTable("Tabla Alumnos");

                            da.Fill(tablaAlumnos);

                            if (tablaAlumnos.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaAlumnos.Rows)
                                {
                                    ML.Alumno alumno = new ML.Alumno();

                                    alumno.IdAlumno = int.Parse(row[0].ToString());
                                    alumno.Nombre = row[1].ToString();
                                    alumno.ApellidoPaterno = row[2].ToString();
                                    alumno.ApellidoMaterno = row[3].ToString();
                                    result.Objects.Add(alumno);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;

                            }

                        }
                        cmd.Connection.Open();
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

        public static ML.Result GetAllMateriaAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaAsignadaGetByAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaAlumnos = new DataTable("Tabla Alumnos");

                            da.Fill(tablaAlumnos);

                            if (tablaAlumnos.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaAlumnos.Rows)
                                {
                                    ML.MateriaAsignada materiasAsignadas = new ML.MateriaAsignada();

                                    materiasAsignadas.IdMateriaAsignada = int.Parse(row[0].ToString());
                                    materiasAsignadas.Materia = new ML.Materia();
                                    materiasAsignadas.Materia.IdMateria = int.Parse(row[1].ToString());
                                    materiasAsignadas.Materia.Nombre = row[2].ToString();
                                    materiasAsignadas.Materia.Costo = decimal.Parse(row[3].ToString());
                                    materiasAsignadas.Alumno = new ML.Alumno();
                                    materiasAsignadas.Alumno.IdAlumno = int.Parse(row[4].ToString());
                                    materiasAsignadas.Alumno.Nombre = row[5].ToString();
                                    result.Objects.Add(materiasAsignadas);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;

                            }

                        }
                        cmd.Connection.Open();
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

        public static ML.Result GetAllMateriaNoAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriasNoAsignadasGetByAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaAlumnos = new DataTable("Tabla Alumnos");

                            da.Fill(tablaAlumnos);

                            if (tablaAlumnos.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaAlumnos.Rows)
                                {
                                    ML.MateriaAsignada materiasNoAsignadas = new ML.MateriaAsignada();
                                    materiasNoAsignadas.Materia = new ML.Materia();
                                    materiasNoAsignadas.Materia.IdMateria = int.Parse(row[0].ToString());
                                    materiasNoAsignadas.Materia.Nombre = row[1].ToString();
                                    materiasNoAsignadas.Materia.Costo = decimal.Parse(row[2].ToString());

                                    result.Objects.Add(materiasNoAsignadas);
                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;

                            }

                        }
                        cmd.Connection.Open();
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

        public static ML.Result Add(ML.MateriaAsignada asignarMaterias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "MateriaAsignadaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Arreglo para almacenar los datos que fueron solicitados
                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar);
                        collection[0].Value = asignarMaterias.Materia.IdMateria;

                        collection[1] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
                        collection[1].Value = asignarMaterias.Alumno.IdAlumno;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery(); //0 -no se insertó //>=1 se insertó

                        if (RowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al ingresar el Alumno";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "ocurrio un error" + ex.Message;
            }
            return result;
        }


        public static ML.Result Delete(ML.MateriaAsignada borrarMaterias)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaAsignadaDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Arreglo para almacenar los datos que fueron solicitados
                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar);
                        collection[0].Value = borrarMaterias.Materia.IdMateria;
                        collection[1] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
                        collection[1].Value = borrarMaterias.Alumno.IdAlumno;



                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery(); //0 -no se insertó //>=1 se insertó

                        if (RowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al Eliminar el Registro";
                        }
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
    }
}
