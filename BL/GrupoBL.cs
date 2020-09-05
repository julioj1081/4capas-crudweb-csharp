using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL;
using ET;
namespace BL
{
    public class GrupoBL
    {
        private GrupoDAL grupoDAL = new GrupoDAL();

        //select * from
        public List<Grupo> Listar()
        {
            return grupoDAL.Listar();
        }


        public Grupo Obtener(int id)
        {
            return grupoDAL.Obtener(id);
        }



        public bool Actualizar(Grupo grupo)
        {
            return grupoDAL.Actualizar(grupo);
        }


        public bool Registrar(Grupo grupo)
        {
            return grupoDAL.Registrar(grupo);
        }


        public bool Eliminar(int id)
        {
            return grupoDAL.Eliminar(id);
        }
    }
}
