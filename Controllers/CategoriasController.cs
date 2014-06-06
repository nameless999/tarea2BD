using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using Tarea2BDRazor.Models;


namespace Tarea2BDRazor.Controllers
{
    public class CategoriasController : Controller
    {
        public ActionResult Temas(string nid, string id_user )
        {
            int id_usuario = int.Parse(id_user);
            Session["ID"] = id_usuario ;
            Usuario usuario = new Usuario();
            Session["user_name"] = usuario.obtenerNombreUsuarioPorID(id_usuario);
            Session["IDG"] = Session["IDG"];
            Session["IdCategoria"] = Session["IdCategoria"];

            int id = int.Parse(nid);
            ViewBag.idCategoria = id;
            Tema tem = new Tema();
            List<Tema> temas = new List<Tema>();
            temas = tem.ObtenerTemasPorCategoriaID(id);
            ViewBag.Temas = temas;

            Categoria cat = new Categoria();
            ViewBag.NombreCat = cat.obtenerNombreCategoriaById(id);
            return View();
        }

        public ActionResult Tema(string nombreTema)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Session["IdCategoria"] = Session["IdCategoria"];
          
            Tema tem = new Tema();
            Tema tema = tem.ObtenerTemaPorNombre(nombreTema);

            Session["IDtema"] = tema.id_tema;
            ViewBag.Tema = tema;

            Comentario comentario = new Comentario();
            ViewBag.Comentarios = comentario.ObtenerComentariosPorIDTema(tema.id_tema);


            return View();
        }
        public ActionResult EliminarComentariosRec2(int id_tema, int id_categoria)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            String sql = "Delete from Comentario where id_tema = '" + id_tema + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_tema), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("EliminarTemaRec", "Categorias", new { id_cat = id_categoria, id_tem = id_tema });
            }
            return View();
        }

        public ActionResult EliminarComentariosRec(int id_tema, int id_categoria)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            String sql = "Delete from Comentario where id_tema = '" + id_tema + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql,id_tema), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("EliminarTema", "Categorias", new { id_cat = id_categoria, id_tem = id_tema });
            }
            return View();
        }

        public ActionResult EliminarTemaRec(int id_tema, int id_categoria)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            String sql = "Delete from Comentario where id_categoria = '" + id_categoria + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_categoria), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("EliminarCategoria", "Categorias", new { id_cat = id_categoria, id_tem = id_tema });
            }
            return View();
        }

        public ActionResult EliminarCategoria(int id_categoria)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            String sql = "Delete from Categoria where id_categoria = '" + id_categoria + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_categoria), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("Categorias", "Home"); ;
            }
            return View();
        }


        public ActionResult UpdateComentario(int id_comentario, int id_tema)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            Tema tema = new Tema();

            string mensaje = Microsoft.VisualBasic.Interaction.InputBox("Editar Mensaje:");
            String sql = "Update Comentario set mensaje = '" + mensaje + "' where id_comentario = '" + id_comentario + "'";
           
            int retorno = 0;
           
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_comentario), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("Tema", new { nombreTema = tema.ObtenerNombreTemaPorID(id_tema) });
            }
            return View();
        }

        public ActionResult EliminarComentarioPorID(int id_comentario, int id_tema)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Tema tema = new Tema();
            String sql = "Delete from Comentario where id_comentario = '" + id_comentario + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_comentario), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("Tema", new { nombreTema = tema.ObtenerNombreTemaPorID(id_tema) });
            }
            return View();
        }

        public ActionResult EliminarTema(int id_tem, int id_cat)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            String sql = "Delete from Tema where id_tema = '" + id_tem + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql,id_tem), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                MessageBox.Show("Tema Eliminado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return RedirectToAction("Temas", "Categorias", new { nid = id_cat });

            }

            else
            {
                MessageBox.Show("No se pudo eliminar el tema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            return View();
        }


        public ActionResult CrearTema(int id_categoria)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Session["IdCategoria"] = id_categoria;

            return View();
        }

        public ActionResult CrearCategoria()
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Session["IdCategoria"] = Session["IdCategoria"];

            return View();
        }

        public ActionResult IngresarCategoria()
        {
            ViewBag.Message = "Página de registro.";

            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Session["IdCategoria"] = Session["IdCategoria"];

            bool publico = true;
            if (Request["publico"] != null)
            {
                publico = false;
            }

            string nombre = (string)Request["nombre"];
            string descripcion = (string)Request["descripcion"];

            String sql = "Insert into Categoria (nombre,descripcion,publico) "
          + "values  ('{0}','{1}','{2}')";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, nombre, descripcion, publico), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                MessageBox.Show("Categoria creada", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return RedirectToAction("Categorias", "Home");

            }

            else
            {
                MessageBox.Show("No se pudo crear tema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Redirect("CrearCategoria");
            }

        }

        public ActionResult CrearComentario()
        {
            
            Session["IDtema"] = Session["IDtema"];
            Session["ID"] = Session["ID"];
            Session["IdCategoria"] = Session["IdCategoria"];

            int id_tema = int.Parse(Session["IDtema"].ToString());
            int id_usuario = int.Parse(Session["ID"].ToString());
            string mensaje = Request["mensaje"];

            Tema tema = new Tema();

            String sql = "Insert into Comentario (id_tema,id_usuario,mensaje) "
            + "values  ('{0}','{1}','{2}')";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_tema, id_usuario, mensaje), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return RedirectToAction("Tema", new { nombreTema = tema.ObtenerNombreTemaPorID(id_tema) }); 
            }

            else
            {
                MessageBox.Show("No se pudo agregar comentario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Redirect("CrearCategoria");
            }

        }


        public ActionResult IngresarTema()
        {
            ViewBag.Message = "Página de registro.";
            
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Session["IdCategoria"] = Session["IdCategoria"];

            bool publico = false;
            if (Request["publico"] != null)
            {
                publico = true;
            }
            int id_categoria = int.Parse(Session["idCategoria"].ToString());
            int id_usuario = int.Parse(Session["ID"].ToString());
            string nombre = (string)Request["nombre"];
            string descripcion = (string)Request["descripcion"];
            string mensaje = (string)Request["mensaje"];

            String sql = "Insert into Tema (id_categoria, id_usuario, nombre,descripcion,mensaje,publico) "
            + "values  ('{0}','{1}','{2}','{3}','{4}','{5}')";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_categoria, id_usuario, nombre, descripcion, mensaje, publico), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                MessageBox.Show("Tema creado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return RedirectToAction("Tema", new { nombreTema = nombre });

            }

            else
            {
                MessageBox.Show("No se pudo crear tema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Redirect("CrearTema");
            }

        }
    }
}
