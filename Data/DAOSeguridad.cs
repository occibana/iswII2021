using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        

        /*
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
        */

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
        /*
        public void cerrarAcceso(int userid)
        {
            using (var db = new Mapeo())
            {
                Acceso acceso = new Acceso();
                acceso = db.acceso.Where(x=> x.Userid == userid && x.FechaFin == null).FirstOrDefault();
                acceso.FechaFin = DateTime.Now;

                db.acceso.Attach(acceso);
                var entry = db.Entry(acceso);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        */
        //guardar datos de compra
        /*
        public void insertarCompra(Membresia datos)
        {
            using (var db = new Mapeo())
            {
                db.membresia.Add(datos);
                db.SaveChanges();
            }
        }
        */
        /*
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
        */
        /*
        //verifica vencimiento usuario con membresia
        public Membresia verificarvencimientomembresia(int userid)
        {
            return new Mapeo().membresia.Where(x => x.Idusuario == userid && x.Fecha_vencimiento < DateTime.Now).FirstOrDefault();
        }
    */
        //info compra
        /*
        public Membresia fechavencimiento(URegistro usuarioidE)
        {
            return new Mapeo().membresia.Where(x=> x.Idusuario == usuarioidE.Id).FirstOrDefault();
        }
        */
        //registro de ingresos
        /*
        public List<Acceso> RegistrosAcceso(int usuarioE)
        {
            return new Mapeo().acceso.Where(x => x.Userid == usuarioE).ToList();
        }
        */
    }
}
    