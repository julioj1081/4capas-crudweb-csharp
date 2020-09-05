using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//System.configuration
using ET;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace DL
{
    public class RolDAL
    {
        public List<Rol> Listar()
        {
            var roles = new List<Rol>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("Select * FROM rol", con);
                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            roles.Add(new Rol { id = Convert.ToInt32(dr["id"]), Puesto = dr["Puesto"].ToString() });
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return roles;
        }



        public Rol Obtener(int id)
        {
            var rol = new Rol();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM rol where id = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using(var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            rol.id = Convert.ToInt32(dr["id"]);
                            rol.Puesto = dr["Puesto"].ToString();
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return rol;
        }


        public bool Actualizar(Rol rol)
        {
            bool respuesta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE rol SET Puesto = @p0 WHERE id = @p1", con);
                    query.Parameters.AddWithValue("@p0", rol.Puesto);
                    query.Parameters.AddWithValue("@p1", rol.id);
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }

        public bool Registrar(Rol rol)
        {
            bool respuesta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO rol(Puesto) VALUES(@p0)", con);
                    query.Parameters.AddWithValue("@p0", rol.Puesto);
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }


        public bool Eliminar(int id)
        {
            bool respuesta = false;
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("DELETE FROM rol WHERE id = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }
    }
}
