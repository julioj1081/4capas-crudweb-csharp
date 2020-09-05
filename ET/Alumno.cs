using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Alumno
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }




        public int Rol_id { get; set; }
        public Rol Rol { get; set; }


        public int Grupo_id { get; set; }
        public Grupo Grupo { get; set; }

        //adicional para crear el combobox

        public Alumno()
        {
            Rol = new Rol();
            Grupo = new Grupo();
        }

    
        
            
    }
}
