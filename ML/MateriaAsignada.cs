using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class MateriaAsignada
    {
        public int IdMateriaAsignada {get; set; }
        public Alumno Alumno { get; set; } //para sacar el IdAlumno
        public Materia Materia { get; set; }// sacar el IdMateria y las Materias que no esten Asignadas o esten Asignadas
        public List<object> MatriasAsignadasAlumnos { get; set; }
    }
}
