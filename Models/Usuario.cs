using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Tarea2BDRazor.Models;

namespace Tarea2BDRazor.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public int id_group { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string contraseña { get; set; }
        [Required]
        public int cantidad_comentarios { get; set; }
        [Required]
        public string avatar_url { get; set; }
        [Required]
        public string fecha_nacimiento { get; set; }
        [Required]
        public string sexo { get; set; }
        [Required]
        public string fecha_registro { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, int id_group, string nombre, string contraseña, int cantidad_comentarios, string avatar_url,
            string fecha_nacimiento, string sexo, string fecha_registro)
        {
            this.id = id;
            this.id_group = id_group;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.cantidad_comentarios = cantidad_comentarios;
            this.avatar_url = avatar_url;
            this.fecha_nacimiento = fecha_nacimiento;
            this.sexo = sexo;
            this.fecha_registro = fecha_registro;
        }

        public Usuario obtenerUsuarioPorNombre(string Nombre)
        {
            String sql = "Select * From Usuario where nombre = '" + Nombre + "'";
            Usuario user = new Usuario();
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, Nombre), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    user.id = reader.GetInt32(0);
                    user.id_group = reader.GetInt32(1);
                    user.nombre = reader.GetString(2);
                    user.contraseña = reader.GetString(3);
                    user.cantidad_comentarios = reader.GetInt32(4);
                    user.avatar_url = reader.GetString(5);
                    user.fecha_nacimiento = reader.GetString(6);
                    user.sexo = reader.GetString(7);
                    user.fecha_registro = reader.GetString(8);
                }
            }
            return user;
        }

        public string obtenerNombreUsuarioPorID(int id_usuario)
        {
            String sql = "Select nombre From Usuario where id = '" + id_usuario +"'";
 
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                reader.Read();
                    string nombre = reader.GetString(0);
                    return nombre;
            }
            
        }

        public List<string> obtenerNombreUsuarios()
        {
            String sql = "Select nombre From Usuario order by id";
            List<string> nombres = new List<string>();

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    string nombre = reader.GetString(0);
                    nombres.Add(nombre);

                }
            }
            return nombres;
        }

        public Usuario obtenerUsuarioPorID(int id_usuario)
        {
            String sql = "Select * From Usuario where id = '" + id_usuario + "'";
            Usuario user = new Usuario();
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_usuario), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    user.id = reader.GetInt32(0);
                    user.id_group = reader.GetInt32(1);
                    user.nombre = reader.GetString(2);
                    user.contraseña = reader.GetString(3);
                    user.cantidad_comentarios = reader.GetInt32(4);
                    user.avatar_url = reader.GetString(5);
                    user.fecha_nacimiento = reader.GetString(6);
                    user.sexo = reader.GetString(7);
                    user.fecha_registro = reader.GetString(8);
                }
            }
            return user;
        }


        /*public int cantidadUsuarios()
        {
            String sql = "Select count(*) from Usuario";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                int cantidad = reader.FieldCount;
                return cantidad;
            }
        }*/

        public int ObtenerEdad(int id_usuario)
        {
            Usuario usuario = new Usuario();
            string fecha_nacimiento = usuario.obtenerUsuarioPorID(id_usuario).fecha_nacimiento;
            string[] fecha = fecha_nacimiento.Split('-');

            DateTime nacimiento = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[0]), int.Parse(fecha[1])); //Fecha de nacimiento
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            return edad;
        }

        public List<string> obtenerContraseñaUsuarios()
        {
            String sql = "Select contraseña From Usuario order by id";
            List<string> contraseñas = new List<string>();

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    string nombre = reader.GetString(0);
                    contraseñas.Add(nombre);

                }
            }
            return contraseñas;
        }

      
    }
}


    
