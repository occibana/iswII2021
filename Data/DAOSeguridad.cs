using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Utilitarios;


namespace Data
{
    public class DAOSeguridad
    {
        
        public void insertartoken(UToken tokenE)
        {
            using (var db = new Mapeo())
            {
                db.token.Add(tokenE);
                db.SaveChanges();
            }
        }
        
        public UToken getTokenusuario(int userid)
        {
            return new Mapeo().token.Where(x => x.User_id == userid && x.Fecha_caducidad > DateTime.Now).FirstOrDefault();
        }
        
        public UToken validartoken(string token)
        {
            return new Mapeo().token.Where(x => x.Tokengenerado == token).FirstOrDefault();
        }



        //actualiza contraseña
        public void actualizarcontrasenarecuperacion(URegistro datoE)
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


        //Insertar registro de acceso

        public void insertarAcceso(UAcceso acceso)
        {
            using (var db = new Mapeo())
            {
                db.acceso.Add(acceso);
                db.SaveChanges();
            }

        }
        //capturar momento de des-logeo
        public void cerrarAcceso(int userid)
        {
            using (var db = new Mapeo())
            {
                UAcceso acceso = new UAcceso();
                acceso = db.acceso.Where(x=> x.Userid == userid && x.FechaFin == null).FirstOrDefault();
                acceso.FechaFin = DateTime.Now;

                db.acceso.Attach(acceso);
                var entry = db.Entry(acceso);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //berra token de autenticacion del login - API
        public void borrarTokenLogin(URegistro idUsuario)
        {
            using (var db = new Mapeo())
            {
                LoginToken usuario = db.login_token.Where(x => x.User_id == idUsuario.Id).First();   
                db.login_token.Remove(usuario);
                db.SaveChanges();
            }
        }

        //guardar datos de compra
        public void insertarCompra(UMembresia datos)
        {
            using (var db = new Mapeo())
            {
                db.membresia.Add(datos);
                db.SaveChanges();
            }
        }
        
        
        //actualizar estado membresia
        public void actualizarmembresia(URegistro datoE)
        {
            using (var db = new Mapeo())
            {
                URegistro datoanterior = db.usuario.Where(x => x.Id == datoE.Id).First();
                datoanterior.Idestado = datoE.Idestado;

                var entry = db.Entry(datoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        
        
        //verifica vencimiento usuario con membresia
        public UMembresia verificarvencimientomembresia(int userid)
        {
            return new Mapeo().membresia.Where(x => x.Idusuario == userid && x.Fecha_vencimiento < DateTime.Now).FirstOrDefault();
        }
    
        //info compra
        
        public UMembresia fechavencimiento(URegistro usuarioidE)
        {
            return new Mapeo().membresia.Where(x=> x.Idusuario == usuarioidE.Id).FirstOrDefault();
        }
        
        //registro de ingresos
        
        public List<UAcceso> RegistrosAcceso(int usuarioE)
        {
            return new Mapeo().acceso.Where(x => x.Userid == usuarioE).ToList();
        }

        //guardar token usuario - API
       
        public async Task guardarTokenLogin(LoginToken token)
        {
            using (var db = new Mapeo())
            {
                db.login_token.Add(token);
                db.SaveChanges();
            }
        }

    }
}
    