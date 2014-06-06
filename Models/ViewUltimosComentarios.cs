using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Tarea2BDRazor.Models;

namespace Tarea2BDRazor.Models
{
    public class ViewUltimosComentarios
    {
        public int id_tema;
        public int id_usuario;
        public int id_comentario;
        public string nombre_tema;
        public string nombre_usuario;

        public ViewUltimosComentarios()
        {


        }

        public List<ViewUltimosComentarios> ObtenerComentariosRealizados(int id)
        {
            List<ViewUltimosComentarios> views = new List<ViewUltimosComentarios>();
            String sql = "Select TOP 5 *From VIEW_ULTIMOS_COMENTARIOS where id_usuario = '" + id + "' ORDER BY id_comentario DESC";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    ViewUltimosComentarios view = new ViewUltimosComentarios();
                    view.id_usuario = reader.GetInt32(0);
                    view.nombre_usuario = reader.GetString(1);
                    view.id_tema = reader.GetInt32(2);
                    view.nombre_tema = reader.GetString(3);
                    view.id_comentario = reader.GetInt32(4);
                    views.Add(view);
                }
            }

            return views;

        }
    }
}