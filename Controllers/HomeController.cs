using System;
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
            Session["IDG"] = 4;
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

        public ActionResult BuzonEntrada()
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            List<MensajePrivado> mensajes = new List<MensajePrivado>();
            MensajePrivado mensaje = new MensajePrivado();
            BuzonEntrada Buzon = new BuzonEntrada();
            mensajes = mensaje.obtenerMensajesIDbuzon(Buzon.ObtenerIDBuzonconIDUsuario(int.Parse(Session["ID"].ToString())));
            ViewBag.Mensajes = mensajes;


            return View();
        }


        public ActionResult MensajePrivado()
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            List<BuzonEntrada> Buzones = new List<BuzonEntrada>();
            BuzonEntrada Buzon = new BuzonEntrada();
            Buzones = Buzon.ObtenerListaBuzones();
            ViewBag.Buzones = Buzones;
            return View();
        }

        public ActionResult Logout()
        {
            return Redirect("Index");
        }

        public ActionResult VerPerfil(string nombre)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];

            Usuario usuario = new Usuario();
            GrupoUsuario GUser = new GrupoUsuario();
            usuario = usuario.obtenerUsuarioPorNombre(nombre);
            ViewBag.NombreUsuario = usuario.nombre;
            ViewBag.Edad = usuario.ObtenerEdad(usuario.id);
            ViewBag.Sexo = usuario.sexo;
            ViewBag.NComentarios = usuario.cantidad_comentarios;
            ViewBag.FechaRegistro = usuario.fecha_registro;
            ViewBag.AvatarUrl = usuario.avatar_url;
            ViewBag.TipoUsuario = GUser.obtenerNombreGrupoPorID(int.Parse(Session["IDG"].ToString()));
            List<ViewTemasCreados> VTC2 = new List<ViewTemasCreados>();
            ViewTemasCreados VTC = new ViewTemasCreados();
            VTC2 = VTC.ObtenerTemasCreados(usuario.id);
            ViewBag.TemasCreados = VTC2;

            List<ViewUltimosComentarios> VUC2 = new List<ViewUltimosComentarios>();
            ViewUltimosComentarios VUC = new ViewUltimosComentarios();
            VUC2 = VUC.ObtenerComentariosRealizados(usuario.id);
            ViewBag.ComentariosRealizados = VUC2;


            return View();
        }

        public ActionResult MiPerfil()
        {
            Session["user_name"] = Session["user_name"];
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
            List<ViewTemasCreados> VTC2 = new List<ViewTemasCreados>();
            ViewTemasCreados VTC = new ViewTemasCreados();
            VTC2 = VTC.ObtenerTemasCreados(usuario.id);
            ViewBag.TemasCreados = VTC2;
            
            List<ViewUltimosComentarios> VUC2 = new List<ViewUltimosComentarios>();
            ViewUltimosComentarios VUC = new ViewUltimosComentarios();
            VUC2 = VUC.ObtenerComentariosRealizados(usuario.id);
            ViewBag.ComentariosRealizados = VUC2;


            return View();
        }

        public ActionResult EditarPerfil(string nombre_usuario)
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            ViewBag.NombreUsuario2 = nombre_usuario;
            return View();
        }

        public ActionResult EditarPerfil2()
        {
            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            string contraseña = (string)Request["contraseña"];
            string fecha_nacimiento = (string)Request["fecha_nacimiento"];
            string avatar_url = (string)Request["avatar_url"];
            string nombre = (string)Request["nombre_usuario"];

            String sql = "Update Usuario set contraseña = '" + contraseña + "', fecha_nacimiento = '" + fecha_nacimiento + "', avatar_url = '" + avatar_url + "' where nombre = '" + nombre + "'";

            int retorno = 0;

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, nombre), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();
            }

            if (retorno > 0)
            {
                return Redirect("VerPerfil");
            }

 
             return Redirect("EditarPerfil");
        }
            

        [HttpPost]
        public ActionResult Register(string nombre, string contraseña, string re_contraseña, string fecha_nacimiento, string sexo, string avatar_url)
        {
            ViewBag.Message = "Página de registro.";
            Usuario user = new Usuario();

            Session["user_name"] = Session["user_name"];
            Session["IDG"] = Session["IDG"];
            Session["ID"] = Session["ID"];
            DateTime thisDay = DateTime.Now;
            string fecha_registro = thisDay.ToString();
            int retorno = 0;
            String sql = "Insert into Usuario (id_grupo,nombre,contraseña,cantidad_comentarios,avatar_url,fecha_nacimiento,sexo,fecha_registro) "
            + "values  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";

            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, 3, nombre, contraseña, 0, avatar_url, fecha_nacimiento, sexo, fecha_registro), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();

            }

            if (retorno > 0)
            {
                MessageBox.Show("Registro completado", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return RedirectToAction("crearBuzon", "Home", new { nombre_usuario = nombre});
            }

            
             MessageBox.Show("No se pudo realizar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             return Redirect("Registrarse");
        }

        public ActionResult crearBuzon(string nombre_usuario) 
        { 
            Usuario usuario = new Usuario();
            int id_usuario = usuario.obtenerUsuarioPorNombre(nombre_usuario).id;
            String sql = "Insert into Buzon_entrada (id_usuario,cantidad_mensajes,mensajes_sin_leer) "
            + "values  ('{0}','{1}','{2}')";

            int retorno = 0;
            using (SqlConnection connection = Conexion.getConnection())
            {
                SqlCommand Comando = new SqlCommand(string.Format(sql, id_usuario,0,0), connection);

                retorno = Comando.ExecuteNonQuery();
                connection.Close();

            }

            if (retorno > 0)
            {
                return Redirect("Loguearse");
            }

             return Redirect("Registrarse");
        }

        public ActionResult VerMensaje(int id_mensaje)
        {
            MensajePrivado mensaje = new MensajePrivado();
            ViewBag.Mensaje = mensaje.obtenerMensajeIDMensaje(id_mensaje);

            return View();

        }
        
    }
}
