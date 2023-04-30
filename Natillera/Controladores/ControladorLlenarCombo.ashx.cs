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
    /// Descripción breve de ControladorTipoAhorro
    /// </summary>
    public class ControladorTipoAhorro : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            string tabla = JsonConvert.DeserializeObject<string>(Datos);
            context.Response.ContentType = "text/plain";
            string DatosRpta = Procesar(tabla);
            context.Response.Write(DatosRpta);
        }
        private string Procesar(string tabla)
        {
            clsLLenarCombo combo = new clsLLenarCombo();
            switch (tabla)
            {
                case "Usuario":
                    return JsonConvert.SerializeObject(combo.LlenarComboUsuario());
                case "TipoAhorro":
                    return JsonConvert.SerializeObject(combo.LlenarComboTipoAhorro());
                case "TipoAPrestamo":
                    return JsonConvert.SerializeObject(combo.LlenarComboTipoPrestamo());
                case "Evento":
                    return JsonConvert.SerializeObject(combo.LlenarComboEvento());
                case "TipoPermiso":
                    return JsonConvert.SerializeObject(combo.LlenarComboPermiso());
                default:
                    return JsonConvert.SerializeObject("No tabla");
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