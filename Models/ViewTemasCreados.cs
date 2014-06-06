using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Tarea2BD.Models;
using Tarea2BDRazor.Models;

namespace Tarea2BD.Models
{
    public class ViewTemasCreados
    {
        public int id_tema;
        public string nombre_tema;
        public int id_usuario;
        public string nombre_usuario;

        public ViewTemasCreados()
        {


        }

        public List<ViewTemasCreados> ObtenerTemasCreados(int id)
        {
            List<ViewTemasCreados> views = new List<ViewTemasCreados>();
            String sql = "Select TOP 5 *From VIEW_TEMAS_CREADOS where id_user = '" + id + "' ORDER BY id_topic DESC";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    ViewTemasCreados view = new ViewTemasCreados();
                    view.id_tema = reader.GetInt32(0);
                    view.nombre_tema = reader.GetString(1);
                    view.id_usuario = reader.GetInt32(2);
                    view.nombre_usuario = reader.GetString(3);
                    views.Add(view);
                }
            }

            return views;

        }
    }
}