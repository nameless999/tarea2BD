using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Tarea2BDRazor.Models
{
    public class Conexion
    {
        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=NAMELESS999\\SQLEXPRESS;Initial Catalog=Tarea2BD;Integrated Security=True;");
            connection.Open();

            return connection;

        }
    }
}

