using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Natillera.Modelos;

namespace Natillera.Controladores
{
    public class clsPermiso
    {
        private NatilleraEntities dbNatillera = new NatilleraEntities();

        public List<Permiso> LlenarCombo()
        {
            return dbNatillera.Permisoes
                .OrderBy(p => p.Nombre)
                .ToList();
        }

    }
}