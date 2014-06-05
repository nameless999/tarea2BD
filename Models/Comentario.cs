using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Tarea2BDRazor.Models;

namespace Tarea2BDRazor.Models
{
    public class Comentario
    {

        public int id_comentario { get; set; }
        public int id_tema { get; set; }
        public int id_usuario { get; set; }
        public string mensaje { get; set; }

        public Comentario()
        {
        }

        public Comentario(int id_comentario, int id_tema, int id_usuario, string mensaje)
        {
            this.id_comentario = id_comentario;
            this.id_tema = id_tema;
            this.id_usuario = id_usuario;
            this.mensaje = mensaje;

        }

        public int cantidadComentariosPorIDTema(int id_tema)
        {
            String sql = "Select count(*) from Comentario where id_tema = '"+id_tema+"'";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql,id_tema), connection);
                int count = (int)Comando.ExecuteScalar();
                return count;
            }
        }

        public List<Comentario> ObtenerComentariosPorIDTema(int id_tema)
        {

            string sql = "Select * from Comentario where id_tema = '"+ id_tema + "'";
            List<Comentario> ListComentarios = new List<Comentario>();

            using ( SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_tema), connection);
                SqlDataReader reader = Comando.ExecuteReader();

                while (reader.Read())
                {

                    Comentario comentarios = new Comentario();
                    comentarios.id_comentario = reader.GetInt32(0);
                    comentarios.id_tema = reader.GetInt32(1);
                    comentarios.id_usuario = reader.GetInt32(2);
                    comentarios.mensaje = reader.GetString(3);
                    ListComentarios.Add(comentarios);
                }
            }

            return ListComentarios;

        }

    }
}