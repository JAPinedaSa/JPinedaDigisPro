using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumno" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumno
    {
        [OperationContract]
        SL.Result Add(ML.Alumno alumno);

        [OperationContract]
        SL.Result Update(ML.Alumno alumno);

        [OperationContract]
        SL.Result Delete(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL.Result GetById(int IdAseguradora);
    }
}
