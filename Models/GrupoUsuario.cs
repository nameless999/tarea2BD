using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Tarea2BDRazor.Models
{
    public class GrupoUsuario
    {
        public int id_grupo { get; set; }
   
        public string nombre_grupo { get; set; }
   
        public bool creacion_categoria { get; set; }

        public bool creacion_tema { get; set; }

        public bool publicar_comentario { get; set; }

        public bool eliminar_categoria { get; set; }

        public bool eliminar_tema { get; set; }

        public bool eliminar_mensaje { get; set; }

        public bool editar_mensaje { get; set; }

        public bool editar_usuario { get; set; }

        public GrupoUsuario()
        { 
        }

        public GrupoUsuario(int id_grupo, string nombre_grupo, bool creacion_categoria, bool creacion_tema, bool publicar_comentario, bool eliminar_categoria, bool eliminar_tema, bool eliminar_mensaje, bool editar_mensaje, bool editar_usuario)
        {
         
            this.id_grupo = id_grupo;
   
            this.nombre_grupo = nombre_grupo;
   
            this.creacion_categoria = creacion_categoria;

            this.creacion_tema = creacion_tema;

            this.publicar_comentario = publicar_comentario;

            this.eliminar_categoria = eliminar_categoria;

            this.eliminar_tema = eliminar_tema;

            this.eliminar_mensaje = eliminar_mensaje;

            this.editar_mensaje = editar_mensaje;

            this.editar_usuario = editar_usuario;
        }

        public string obtenerNombreGrupoPorID(int id_grupo)
        {
            String sql = "Select nombre_grupo From Grupo_Usuario where id_grupo = '" + id_grupo + "'";
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_grupo), connection);

                SqlDataReader reader = Comando.ExecuteReader();
                reader.Read();
                string nombre = reader.GetString(0);
                return nombre;
            }
        }


    }

}