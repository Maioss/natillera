using Natillera.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natillera.Controladores
{
    public class clsLLenarCombo
    {
        private NatilleraEntities dbNatillera = new NatilleraEntities();

        
        public List<Tipo_Ahorro> LlenarComboTipoAhorro()
        {
            return dbNatillera.Tipo_Ahorro
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public List<Tipo_Prestamo> LlenarComboTipoPrestamo()
        {
            return dbNatillera.Tipo_Prestamo
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public List<Usuario> LlenarComboUsuario()
        {
            return dbNatillera.Usuarios
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public List<Evento> LlenarComboEvento()
        {
            return dbNatillera.Eventoes
                .OrderBy(p => p.Nombre)
                .ToList();
        }
        public List<Permiso> LlenarComboPermiso()
        {
            return dbNatillera.Permisoes
                .OrderBy(p => p.Nombre)
                .ToList();
        }


    }
}