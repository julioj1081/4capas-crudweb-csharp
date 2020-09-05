using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ET;
namespace DL
{
    public class GrupoDAL
    {
        public List<Grupo> Listar()
        {
            var grupos = new List<Grupo>();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM grupo", con);
                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //grupos
                            var grupo = new Grupo
                            {
                                id = Convert.ToInt32(dr["id"]),
                                Grupos = dr["grupo"].ToString(),
                                Materia = dr["materia"].ToString()
                            };
                            //agregamos esto a la lista
                            grupos.Add(grupo);
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return grupos;
        }


        public Grupo Obtener(int id)
        {
            var grupo = new Grupo();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM grupo WHERE id = @id", con);
                    query.Parameters.AddWithValue("@id", id);
                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            grupo.id = Convert.ToInt32(dr["id"]);
                            grupo.Grupos = dr["Grupo"].ToString();
                            grupo.Materia = dr["Materia"].ToString();
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return grupo;
        }


        public bool Actualizar(Grupo grupo)
        {
            bool respuesta = false;
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE grupo SET Grupo = @p0, Materia = @p1 WHERE id = @p2", con);
                    query.Parameters.AddWithValue("@p0", grupo.Grupos);
                    query.Parameters.AddWithValue("@p1", grupo.Materia);
                    query.Parameters.AddWithValue("@p2", grupo.id);

                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }



        public bool Registrar(Grupo grupo)
        {
            bool respuesta = false;
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO grupo(Grupo,Materia) VALUES(@p0, @p1)", con);
                    query.Parameters.AddWithValue("@p0", grupo.Grupos);
                    query.Parameters.AddWithValue("@p1", grupo.Materia);
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

                    var query = new SqlCommand("DELETE FROM grupo WHERE id = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }

    }
}
