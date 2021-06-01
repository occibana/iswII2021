using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using Utilitarios;


namespace DataNC
{
    public class DAOSeguridad
    {
        private readonly Mapeo _context;

        public DAOSeguridad(Mapeo context)
        {
            _context = context;
        }

        public void insertartoken(UToken tokenE)
        {
            _context.token.Add(tokenE);
            _context.SaveChanges();            
        }
        
        public UToken getTokenusuario(int userid)
        {
            return _context.token.Where(x => x.User_id == userid && x.Fecha_caducidad > DateTime.Now).FirstOrDefault();
        }
        
        public UToken validartoken(string token, URegistro id)
        {
            return _context.token.Where(x => x.Tokengenerado == token && x.User_id == id.Id).FirstOrDefault();
        }

        //actualiza contraseña
        public void actualizarcontrasenarecuperacion(URegistro datoE)
        {

            URegistro datoanterior = _context.usuario.Where(x => x.Id == datoE.Id).First();
            datoanterior.Contrasena = datoE.Contrasena;
            var entry = _context.Entry(datoanterior);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            
        }

        //Insertar registro de acceso
        public async Task insertarAcceso(UAcceso acceso)
        {

            _context.acceso.Add(acceso);
            await _context.SaveChangesAsync(); 

        }
        //capturar momento de des-logeo
        public void cerrarAcceso(int userid)
        {

            UAcceso acceso = new UAcceso();
            acceso = _context.acceso.Where(x=> x.Userid == userid && x.FechaFin == null).FirstOrDefault();
            acceso.FechaFin = DateTime.Now;

            _context.acceso.Attach(acceso);
            var entry = _context.Entry(acceso);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            
        }

        //berra token de autenticacion del login - API
        public void borrarTokenLogin(URegistro idUsuario)
        {
            LoginToken usuario = _context.login_token.Where(x => x.User_id == idUsuario.Id).First();
            _context.login_token.Remove(usuario);
            _context.SaveChanges();
        }

        //guardar datos de compra
        public void insertarCompra(UMembresia datos)
        {
            _context.membresia.Add(datos);
            _context.SaveChanges(); 
        }
        
        
        //actualizar estado membresia
        public void actualizarmembresia(URegistro datoE)
        {
            URegistro datoanterior = _context.usuario.Where(x => x.Id == datoE.Id).First();
            datoanterior.Idestado = datoE.Idestado;

            var entry = _context.Entry(datoanterior);
            entry.State = EntityState.Modified;
            _context.SaveChanges();    
        }
    
        //verifica vencimiento usuario con membresia
        public UMembresia verificarvencimientomembresia(int userid)
        {
            return _context.membresia.Where(x => x.Idusuario == userid && x.Fecha_vencimiento < DateTime.Now).FirstOrDefault();
        }
    
        //info compra
        
        public UMembresia fechavencimiento(URegistro usuarioidE)
        {
            return _context.membresia.Where(x=> x.Idusuario == usuarioidE.Id).FirstOrDefault();
        }
        
        //registro de ingresos
        
        public List<UAcceso> RegistrosAcceso(int usuarioE)
        {
            return _context.acceso.Where(x => x.Userid == usuarioE).ToList();
        }

        //guardar token usuario - API
       
        public async Task guardarTokenLogin(LoginToken token)
        {
            _context.login_token.Add(token);
            _context.SaveChanges();
        }
    }
}
    