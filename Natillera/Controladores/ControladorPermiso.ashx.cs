using Natillera.Controladores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natillera.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorRol
    /// </summary>
    public class ControladorPermiso : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(LlenarCombo());
        }
        private string LlenarCombo()
        {
            clsPermiso rol = new clsPermiso();

            return JsonConvert.SerializeObject(rol.LlenarCombo());
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