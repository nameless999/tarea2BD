using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Tarea2BDRazor.Models
{
    public class BuzonEntrada
    {

        public int id_buzon;
        public int id_usuario;
        public int CantidadMensajes;
        public int MensajesSinLeer;

        public BuzonEntrada() { }

        public BuzonEntrada(int id_buzon, int id_usuario, int CantidadMensajes, int MensajesSinLeer) 
        {
            this.id_buzon = id_buzon;
            this.id_usuario = id_usuario;
            this.CantidadMensajes = CantidadMensajes;
            this.MensajesSinLeer = MensajesSinLeer;
        }

        public List<BuzonEntrada> ObtenerListaBuzones()
        {
            string sql = "Select * from Buzon_entrada"; 
            List<BuzonEntrada> Buzones = new List<BuzonEntrada>();
            
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                while(reader.Read())
                {
                BuzonEntrada Buzon = new BuzonEntrada();
                Buzon.id_buzon = reader.GetInt32(0);
                Buzon.id_usuario = reader.GetInt32(1);  
                Buzon.CantidadMensajes = reader.GetInt32(2);
                Buzon.MensajesSinLeer = reader.GetInt32(3);
                Buzones.Add(Buzon);
                }
            }
           return Buzones;
        }

        public int ObtenerIDUsuarioConIDBuzon(int id_buzon)
        {
            string sql = "Select id_usuario from Buzon_entrada where id_buzon= '"+id_buzon+"'"; 

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_buzon), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                reader.Read();
                int id_usuario = reader.GetInt32(0);
                return id_usuario;
            }
        }

        public int CantidadMensajess(int id_buzon)
        {
            string sql = "Select Count(*) from Buzon_entrada where id_buzon = '" + id_buzon + "'";

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_buzon), connection);
                int count = (int)Comando.ExecuteScalar();
                return count;
            }
        }

        public int ObtenerIDBuzonconIDUsuario(int id_usuario)
        {
            string sql = "Select id_buzon from Buzon_entrada where id_usuario = '" + id_usuario + "'";

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_usuario), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                reader.Read();
                int id_buzon = reader.GetInt32(0);
                return id_buzon;
            }
        }

       
        }
    }
