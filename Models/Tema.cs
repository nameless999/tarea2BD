using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Tarea2BDRazor.Models
{
    public class Tema
    {
        public int id_tema { get; set; }
        public int id_categoria { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string mensaje { get; set; }
        public bool publico { get; set; }
   
        public List<Tema> ObtenerTemasPorCategoriaID(int id_categoria)
        {

            List<Tema> ListTemas = new List<Tema>();
            String sql = "Select * From Tema where id_categoria = '" + id_categoria + "' order by nombre";
            
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_categoria), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    Tema tem = new Tema();
                    tem.id_tema = reader.GetInt32(0);
                    tem.id_categoria = reader.GetInt32(1);
                    tem.id_usuario = reader.GetInt32(2);
                    tem.nombre = reader.GetString(3);
                    tem.descripcion = reader.GetString(4);
                    tem.mensaje = reader.GetString(5);
                    tem.publico = reader.GetBoolean(6);
                    ListTemas.Add(tem);
                }
            }
            return ListTemas;
        }

        public string ObtenerNombreTemaPorID(int id_tema)
        {
            String sql = "Select nombre From Tema where id_tema = '" + id_tema + "'";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_tema), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                reader.Read();
                    string nombre = reader.GetString(0);
                    return nombre;
            }
            
        }

        

        public Tema ObtenerTemaPorNombre(string nombreTema)
        {
            
            String sql = "Select * From Tema where nombre = '" + nombreTema + "'";

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, nombreTema), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                reader.Read();
                    Tema tem = new Tema();
                    tem.id_tema = reader.GetInt32(0);
                    tem.id_categoria = reader.GetInt32(1);
                    tem.id_usuario = reader.GetInt32(2);
                    tem.nombre = reader.GetString(3);
                    tem.descripcion = reader.GetString(4);
                    tem.mensaje = reader.GetString(5);
                    tem.publico = reader.GetBoolean(6);
                    return tem;
            }
            
        }



    }
}