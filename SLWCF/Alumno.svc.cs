using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Alumno" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Alumno.svc o Alumno.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Alumno : IAlumno
    {
        public SL.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();


            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };

        }
        public SL.Result GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        public SL.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SL.Result Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.Delete(IdAlumno);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
