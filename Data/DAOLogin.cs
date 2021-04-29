using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Utilitarios.Entrada;

namespace Data
{
    public class DAOLogin
    {
        
            //verificacion login
            public async Task<URegistro> verificar(URegistro loginE)
            {
                URegistro verificacion = new URegistro();
                verificacion = await new Mapeo().usuario.Where(x => x.Usuario.Equals(loginE.Usuario) && x.Contrasena.Equals(loginE.Contrasena)).FirstOrDefaultAsync();
                return verificacion;
            }

            public async Task<URegistro> verificarLogin(LoginRequest loginE, UAcceso acceso)
            {
                URegistro verificacion = new URegistro();
                verificacion = await new Mapeo().usuario.Where(x => x.Usuario.Equals(loginE.Usuario) && x.Contrasena.Equals(loginE.Contrasena)).FirstOrDefaultAsync();
                acceso.Userid = verificacion.Id;
                new DAOSeguridad().insertarAcceso(acceso);
                return verificacion;
            }

        //verificacion login - compra
        public async Task<URegistro> verificarLogincompra(URegistro loginE)
            {
                URegistro verificacion = new URegistro();
                verificacion = await new Mapeo().usuario.Where(x => x.Usuario.Equals(loginE.Usuario) && x.Contrasena.Equals(loginE.Contrasena)).FirstOrDefaultAsync();
                return verificacion;
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
            public async Task<URegistro> verificaruser(URegistro registroE)
            {

                return await new Mapeo().usuario.Where(x => x.Usuario.ToUpper().Equals(registroE.Usuario.ToUpper()) || x.Correo.ToUpper().Equals(registroE.Correo.ToUpper())).FirstOrDefaultAsync();
            }
            //actualiza foto perfil
            public void actualizarfoto(URegistro fotoE)
            {
                using (var db = new Mapeo())
                {
                    URegistro fotoanterior = db.usuario.Where(x => x.Id == fotoE.Id).First();
                    //eliminar anterior
                    /*
                    if (File.Exists(fotoanterior.Fotoperfil))
                    {
                        File.Delete(fotoanterior.Fotoperfil);
                    }*/
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

        public URegistro mostrarDatos(URegistro datoE)
        {
            URegistro datosUsuario = new URegistro();
            datosUsuario = new Mapeo().usuario.Where(x => x.Usuario.Equals(datoE.Usuario)).FirstOrDefault();
            return datosUsuario;
        }

        
    }
}
