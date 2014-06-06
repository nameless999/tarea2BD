using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Tarea2BDRazor.Models
{
    public class MensajePrivado
    {

        public int id_mensaje;
        public int id_remitente;
        public int id_buzon;
        public bool leido;
        public string mensaje;
        public string fecha_de_envio;

        public MensajePrivado()
        {

        }

         public MensajePrivado(int id_mensaje, int id_remitente, int id_buzon, bool leido, string mensaje, string fecha_de_envio)
         {
             this.id_mensaje = id_mensaje;
             this.id_remitente = id_remitente;
             this.id_buzon = id_buzon;
             this.leido = leido;
             this.mensaje = mensaje;
             this.fecha_de_envio = fecha_de_envio;
         }

         public List<MensajePrivado> obtenerMensajesIDbuzon(int id_buzon)
         {
            List<MensajePrivado> ListMensajes = new List<MensajePrivado>();
            String sql = "Select * From Mensaje_Privado where id_buzon = '" + id_buzon + "'";
            
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_buzon), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    MensajePrivado men = new MensajePrivado();
                    men.id_mensaje = reader.GetInt32(0);
                    men.id_remitente = reader.GetInt32(1);
                    men.id_buzon = reader.GetInt32(2);                       
                    men.leido = reader.GetBoolean(3);
                    men.mensaje = reader.GetString(4);             
                    men.fecha_de_envio = reader.GetString(5);

                    ListMensajes.Add(men);
                }
            }
            return ListMensajes;
        }

         public MensajePrivado obtenerMensajeIDMensaje(int id_mensaje)
         {

             String sql = "Select * From Mensaje_Privado where id_mensaje = '" + id_mensaje + "'";

             using (SqlConnection connection = Conexion.getConnection())
             {
                 SqlCommand Comando = new SqlCommand(string.Format(sql, id_mensaje), connection);

                 SqlDataReader reader = Comando.ExecuteReader();
                 reader.Read();
            
                     MensajePrivado men = new MensajePrivado();
                     men.id_mensaje = reader.GetInt32(0);
                     men.id_remitente = reader.GetInt32(1);
                     men.id_buzon = reader.GetInt32(2);
                     men.leido = reader.GetBoolean(3);
                     men.mensaje = reader.GetString(4);
                     men.fecha_de_envio = reader.GetString(5);
                     return men;
             }
             
         }
         


    }
}