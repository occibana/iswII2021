using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;

namespace Data
{
    public class DAOLogin
    {
        
            //verificacion login
            public URegistro verificar(URegistro loginE)
            {
                return new Mapeo().usuario.Where(x => x.Usuario.Equals(loginE.Usuario) && x.Contrasena.Equals(loginE.Contrasena)).FirstOrDefault();
            }

            //insert registro
            public void insertRegistro(URegistro registroE)
            {
                using (var db = new Mapeo())
                {
                    db.usuario.Add(registroE);
                    db.SaveChanges();
                }
            }
            //verifica usuario no repetido
            public URegistro verificaruser(URegistro registroE)
            {

                return new Mapeo().usuario.Where(x => x.Usuario.ToUpper().Equals(registroE.Usuario.ToUpper()) || x.Correo.ToUpper().Equals(registroE.Correo.ToUpper())).FirstOrDefault();
            }
            //actualiza foto perfil
            public void actualizarfoto(URegistro fotoE)
            {
                using (var db = new Mapeo())
                {
                    URegistro fotoanterior = db.usuario.Where(x => x.Id == fotoE.Id).First();
                    //eliminar anterior
                    if (File.Exists(fotoanterior.Fotoperfil))
                    {
                        File.Delete(fotoanterior.Fotoperfil);
                    }
                    //
                    fotoanterior.Fotoperfil = fotoE.Fotoperfil;
                    var entry = db.Entry(fotoanterior);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            //actualiza datos perfil
            public void actualizarperfil(URegistro datoE)
            {
                using (var db = new Mapeo())
                {
                    URegistro datoanterior = db.usuario.Where(x => x.Id == datoE.Id).First();
                    datoanterior.Nombre = datoE.Nombre;
                    datoanterior.Apellido = datoE.Apellido;
                    datoanterior.Correo = datoE.Correo;
                    datoanterior.Telefono = datoE.Telefono;
                    datoanterior.Usuario = datoE.Usuario;
                    var entry = db.Entry(datoanterior);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            //verificacion usuario para token_segiruridad
            public URegistro verificarusuarioparatoken(URegistro usuarioE)
            {
                return new Mapeo().usuario.Where(x => x.Usuario.ToUpper().Equals(usuarioE.Usuario.ToUpper()) && x.Correo.Equals(usuarioE.Correo)).FirstOrDefault();
            }

            //actualiza contraseña
            public void actualizarcontrasena(URegistro datoE)
            {
                using (var db = new Mapeo())
                {
                    URegistro datoanterior = db.usuario.Where(x => x.Id == datoE.Id).First();
                    datoanterior.Contrasena = datoE.Contrasena;
                    var entry = db.Entry(datoanterior);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

        
    }
}
