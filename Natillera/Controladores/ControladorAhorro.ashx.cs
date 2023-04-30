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
    /// Descripción breve de ControladorAhorro
    /// </summary>
    public class ControladorAhorro : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            Ahorro ahorro = JsonConvert.DeserializeObject<Ahorro>(Datos);
            context.Response.ContentType = "text/plain";
            string DatosRpta = Procesar(ahorro);
            context.Response.Write(DatosRpta);
        }
        private string Procesar(Ahorro ahorro)
        {
            clsAhorro _ahorro = new clsAhorro();
            _ahorro.ahorro = ahorro;
            switch (ahorro.Comando)
            {
                case "LlenarGrid":
                    return JsonConvert.SerializeObject(_ahorro.LlenarGrid());
                case "Insertar":
                    return _ahorro.Insertar();
                case "Eliminar":
                    return _ahorro.Eliminar();
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