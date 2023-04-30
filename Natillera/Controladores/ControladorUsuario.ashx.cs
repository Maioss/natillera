using Natillera.Controladores;
using Natillera.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Natillera.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorUsuario
    /// </summary>
    public class ControladorUsuario : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Datos);
            context.Response.ContentType = "text/plain";
            string DatosRpta = Procesar(usuario);
            context.Response.Write(DatosRpta);
        }
        private string Procesar(Usuario usuario)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            switch (usuario.Comando)
            {
                case "LlenarGrid":
                    return JsonConvert.SerializeObject(_usuario.LlenarGrid());
                case "Insertar":
                    return _usuario.Insertar();
                default:
                    return "sin implementar";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}