using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea2BDRazor.Models
{
    public class MensajePrivado
    {

        public int id_mensaje;
        public int id_remitente;
        public int id_buzon;
        public int leido;
        public string mensaje;
        public string fecha_de_envio;

         public MensajePrivado()
        {

        }



    }
}