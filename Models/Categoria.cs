using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Tarea2BDRazor.Models;
using System.Windows.Forms;

namespace Tarea2BDRazor.Models
{
    public class Categoria
    {
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool publico { get; set; }



        public Categoria()
        {
        }

        public Categoria(int id_categoria, string nombre, string descripcion, bool publico)
        {
            this.id_categoria = id_categoria;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.publico = publico;

        }

        public int cantidadCategorias()
        {
            String sql = "Select count(*) from Categoria";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                int cantidad = reader.FieldCount;
                return cantidad;
            }
        }


        public List<Categoria> obtenerCategorias()
        {
            String sql = "Select * From Categoria order by id_categoria";
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.id_categoria = reader.GetInt32(0);
                    categoria.nombre = reader.GetString(1);
                    categoria.descripcion = reader.GetString(2);
                    categoria.publico = reader.GetBoolean(3);

                    categorias.Add(categoria);

                }
            }
            return categorias;
        }

        public string obtenerNombreCategoriaById(int id)
        {
            String sql = "Select nombre From Categoria where id_categoria = '" + id + "'";
            

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();

                reader.Read();
                    string nombre = reader.GetString(0);
                    return nombre;

                }
            
            
        }

        public int obtenerPrimerIDCategoria()
        {
            String sql = "Select id_categoria From Categoria";


            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();

                reader.Read();
                int id_categoria = reader.GetInt32(0);
                return id_categoria;

            }


        }

        /*public List<string> obtenerDescripcionCategoria()
        {
            String sql = "Select descripcion From Categoria";
            List<string> descripcion_categoria = new List<string>();

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    string descripcion = reader.GetString(0);
                    descripcion_categoria.Add(descripcion);

                }
            }
            return descripcion_categoria;
        }*/
        /*public List<string> obtenerIDCategoria()
        {
            String sql = "Select publico From Categoria";
            List<string> ids_categoria = new List<string>();

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql), connection);
                SqlDataReader reader = Comando.ExecuteReader();
                while (reader.Read())
                {

                    string id_categoria = reader.GetString(0);
                    ids_categoria.Add(nombre);

                }
            }
            return ids_categoria;
        }*/


    }
}