using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DL;
using ET;
namespace BL
{
    public class AlumnoBL
    {
        private AlumnoDAL alumnoDAL = new AlumnoDAL();
        //lista alumnos
        public List<Alumno> Listar()
        {
            return alumnoDAL.Listar();
        }

        //lista profesores
        public List<Alumno> Listar2()
        {
            return alumnoDAL.Listar2();
        }
        //lista otros cargos
        public List<Alumno> Listar3()
        {
            return alumnoDAL.Listar3();
        }

        public Alumno Obtener(int id)
        {
            return alumnoDAL.Obtener(id);
        }

        public bool Actualizar(Alumno al)
        {
            return alumnoDAL.Actualizar(al);
        }

        public bool Registrar(Alumno al)
        {
            return alumnoDAL.Registrar(al);
        }

        public bool Eliminar(int id)
        {
            return alumnoDAL.Eliminar(id);
        }

    }
}
