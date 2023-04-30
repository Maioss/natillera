using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Natillera.Modelos;

namespace Natillera.Controladores
{
    public class clsUsuario 
    {
        NatilleraEntities dbNatillera = new NatilleraEntities();
        public Usuario usuario = new Usuario();

        //public List<Usuario> LlenarCombo()
        //{
        //    return dbNatillera.Usuarios
        //        .OrderBy(p => p.Nombre)
        //        .ToList();
        //}

        public List<Usuario> LlenarGrid()
        {
            return dbNatillera.Usuarios
                   .OrderByDescending(p => p.Id)
                   .ToList();
        }
        //public string Eliminar()
        //{
        //    Usuario usuario_Elim = dbNatillera.Usuarios.FirstOrDefault(p => p.Id == usuario.Id);
        //    dbNatillera.Usuarios.Remove(usuario_Elim);
        //    dbNatillera.SaveChanges();
        //    return "Se eliminó la usuario: " + usuario.Nombre;
        //}
        public string Insertar()
        {

            dbNatillera.Usuarios.Add(usuario);
            dbNatillera.SaveChanges();
            return "Se insertó la usuario documento: " + usuario.Documento;
        }
        //public string Actualizar()
        //{
        //    Usuario _usuario = dbNatillera.Usuarios.FirstOrDefault(p => p.Id == usuario.Id);
        //    _usuario.Nombre = usuario.Nombre;
        //    _usuario.Documento = usuario.Documento;
        //    _usuario.Id_Permiso = usuario.Id_Permiso;
        //    _usuario.Id_Estado = usuario.Id_Estado;

        //    dbNatillera.SaveChanges();
        //    return "Se actualizó el usuario con código: " + usuario.Id;
        //}

    }
}