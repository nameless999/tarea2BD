﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Tarea2BDRazor.Models;
using System.Windows.Forms;


namespace Tarea2BDRazor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["user_name"] = null;
            Session["IDG"] = -1;
            Session["ID"] = -1;

            Categoria categoria = new Categoria();
            List<Categoria> ListCategorias = new List<Categoria>();  
            ListCategorias = categoria.obtenerCategorias();
            ViewBag.ListCategorias = ListCategorias;

            return View();
        }

        public ActionResult Categorias()
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Categoria categoria = new Categoria();
            Tema tema = new Tema();
            
            List<Categoria> ListCategorias = new List<Categoria>();
            ListCategorias = categoria.obtenerCategorias();
            ViewBag.ListCategorias = ListCategorias;

            return View();
        }

        public ActionResult Registrarse()
        {

            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            ViewBag.Message = "Página de Registro.";
            return View();
        }

        public ActionResult Loguear()
        {
            ViewBag.Message = "Página de logueo.";

            return View();
        }

        [HttpPost]
        public ActionResult Loguear(string nombre, string contraseña)
        {
            ViewBag.Message = "Página de logueo.";
            ViewBag.ValidateLogin = false;

            Categoria categoria = new Categoria();
            List<Categoria> ListCategorias = new List<Categoria>();
            ListCategorias = categoria.obtenerCategorias();
            ViewBag.ListCategorias = ListCategorias;

            Usuario user = new Usuario();
            Usuario user2 = new Usuario();
            List<string> Listnombres = user.obtenerNombreUsuarios();
            List<string> Listcontraseñas = user.obtenerContraseñaUsuarios();
            int i = 0;

            while ( Listnombres.Count > i)
            {
                if (Listnombres[i] == nombre && Listcontraseñas[i] == contraseña)
                {
                    ViewBag.ValidateLogin = true;
                    user2 = user.obtenerUsuarioPorNombre(nombre);
                    Session["user_name"] = user2.nombre;
                    Session["ID"] = user2.id;
                    Session["IDG"] = user2.id_group;
                    return View("Categorias");
                }
                i++;
          }

            ViewBag.Message = "Error al loguear, intentelo otra vez.";
            return View();
               
         }

        public ActionResult Desloguear()
        {
            Session["user_name"] = null;
            Session["IDG"] = -1;
            Session["ID"] = -1;
            return Redirect("Index");
        }

        public ActionResult VerPerfil()
        {
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            Usuario usuario = new Usuario();
            GrupoUsuario GUser = new GrupoUsuario();
            usuario = usuario.obtenerUsuarioPorID(int.Parse(Session["ID"].ToString()));
            ViewBag.NombreUsuario = usuario.nombre;
            ViewBag.Edad = usuario.ObtenerEdad(int.Parse(Session["ID"].ToString()));
            ViewBag.Sexo = usuario.sexo;
            ViewBag.NComentarios = usuario.cantidad_comentarios;
            ViewBag.FechaRegistro = usuario.fecha_registro;
            ViewBag.AvatarUrl = usuario.avatar_url;
            ViewBag.TipoUsuario = GUser.obtenerNombreGrupoPorID(int.Parse(Session["IDG"].ToString()));
            return View();
        }

        [HttpPost]
        public ActionResult Register(string nombre, string contraseña, string re_contraseña, string fecha_nacimiento, string sexo, string avatar_url)
        {
            ViewBag.Message = "Página de registro.";
            Usuario user = new Usuario();
            
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            DateTime thisDay = DateTime.Now;
            string fecha_registro = thisDay.ToString();
            int retorno = 0;
            String sql = "Insert into Usuario (id_grupo,nombre,contraseña,cantidad_comentarios,avatar_url,fecha_nacimiento,sexo,fecha_registro) "
            + "values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql,4, nombre, contraseña, 0, avatar_url, fecha_nacimiento, sexo, fecha_registro), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();

            }

            if (retorno > 0)
            {
                MessageBox.Show("Registro completado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return Redirect("Loguear");
            }

            
             MessageBox.Show("No se pudo realizar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             return Redirect("Registracion");
        }
    }
}
