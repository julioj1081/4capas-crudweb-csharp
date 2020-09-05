using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ET;
using System.Data.SqlClient;
using System.Configuration;
namespace DL
{
    public class AlumnoDAL
    {
        public List<Alumno> Listar()
        {
            var usuarios = new List<Alumno>();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM alumno WHERE Rol_id = 1", con);
                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //Usuario
                            var usuario = new Alumno
                            {
                                id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Rol_id = Convert.ToInt32(dr["Rol_id"]),
                                Grupo_id = Convert.ToInt32(dr["Grupo_id"])
                            };
                            //agregamos a la lista
                            usuarios.Add(usuario);
                        }
                    }
                    
                    //creamos el conbobox de roles de la entidad
                    foreach(var item in usuarios)
                    {
                        query = new SqlCommand("SELECT * FROM rol WHERE id = @id", con);
                        query.Parameters.AddWithValue("@id", item.Rol_id);
                        using(var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                item.Rol.id = Convert.ToInt32(dr["id"]);
                                item.Rol.Puesto = dr["Puesto"].ToString();
                            }
                        }
                    }
                    //segundo for de grupos
                    foreach(var item2 in usuarios)
                    {
                        var query2 = new SqlCommand("SELECT * FROM grupo WHERE id = @id", con);
                        query2.Parameters.AddWithValue("@id", item2.Grupo_id);
                        using(var dr = query2.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                item2.Grupo.id = Convert.ToInt32(dr["id"]);
                                item2.Grupo.Grupos = dr["Grupo"].ToString();
                                item2.Grupo.Materia = dr["Materia"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return usuarios;
        }

        public List<Alumno> Listar2()
        {
            var usuarios = new List<Alumno>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM alumno WHERE Rol_id = 2", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //Usuario
                            var usuario = new Alumno
                            {
                                id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Rol_id = Convert.ToInt32(dr["Rol_id"])
                            };
                            //agregamos a la lista
                            usuarios.Add(usuario);
                        }
                    }
                    //creamos el conbobox de roles de la entidad
                    foreach (var item in usuarios)
                    {
                        query = new SqlCommand("SELECT * FROM rol WHERE id = @id", con);
                        query.Parameters.AddWithValue("@id", item.Rol_id);
                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                item.Rol.id = Convert.ToInt32(dr["id"]);
                                item.Rol.Puesto = dr["Puesto"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return usuarios;
        }

        public List<Alumno> Listar3()
        {
            var usuarios = new List<Alumno>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM alumno WHERE NOT Rol_id = 1 AND NOT Rol_id = 2", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //Usuario
                            var usuario = new Alumno
                            {
                                id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Rol_id = Convert.ToInt32(dr["Rol_id"])
                            };
                            //agregamos a la lista
                            usuarios.Add(usuario);
                        }
                    }
                    //creamos el conbobox de roles de la entidad
                    foreach (var item in usuarios)
                    {
                        query = new SqlCommand("SELECT * FROM rol WHERE id = @id", con);
                        query.Parameters.AddWithValue("@id", item.Rol_id);
                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                item.Rol.id = Convert.ToInt32(dr["id"]);
                                item.Rol.Puesto = dr["Puesto"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
            return usuarios;
        }



        public Alumno Obtener(int id)
        {
            var usuario = new Alumno();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM alumno where id = @id", con);
                    query.Parameters.AddWithValue("@id", id);
                    using(var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            usuario.id = Convert.ToInt32(dr["id"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido = dr["Apellido"].ToString();
                            usuario.Rol_id = Convert.ToInt32(dr["Rol_id"]);
                            usuario.Grupo_id = Convert.ToInt32(dr["Grupo_id"]);
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return usuario;
        }



        public bool Actualizar(Alumno user)
        {
            bool respuesta = false;
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE alumno SET Nombre = @p0, Apellido = @p1, Rol_id = @p2, Grupo_id = @p3 where id = @p4", con);
                    query.Parameters.AddWithValue("@p0", user.Nombre);
                    query.Parameters.AddWithValue("@p1", user.Apellido);
                    query.Parameters.AddWithValue("@p2", user.Rol_id);
                    query.Parameters.AddWithValue("@p3", user.Grupo_id);
                    query.Parameters.AddWithValue("@p4", user.id);

                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }



        public bool Registrar(Alumno user)
        {
            bool respuesta = false;
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["colegio"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO alumno(Nombre, Apellido,Rol_id,Grupo_id) VALUES(@p0, @p1, @p2, @p3)", con);
                    query.Parameters.AddWithValue("@p0", user.Nombre);
                    query.Parameters.AddWithValue("@p1", user.Apellido);
                    query.Parameters.AddWithValue("@p2", user.Rol_id);
                    query.Parameters.AddWithValue("@p3", user.Grupo_id);

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
                    var query = new SqlCommand("DELETE FROM alumno WHERE id = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }catch(Exception e) { throw e; }
            return respuesta;
        }

        

    }
}
