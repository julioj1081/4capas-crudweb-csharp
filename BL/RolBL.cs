using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DL;
using ET;
namespace BL
{
    public class RolBL
    {
        private RolDAL rolDal = new RolDAL();
        public List<Rol> Listar()
        {
            return rolDal.Listar();
        }

        public Rol Obtener(int id)
        {
            return rolDal.Obtener(id);
        }


        public bool Actualizar(Rol rol)
        {
            return rolDal.Actualizar(rol);
        }


        public bool Registrar(Rol rol)
        {
            return rolDal.Registrar(rol);
        }


        public bool Eliminar(int id)
        {
            return rolDal.Eliminar(id);
        }
    }
}
