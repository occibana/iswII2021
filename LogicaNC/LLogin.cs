using System;
using System.Threading.Tasks;

using DataNC;
using Utilitarios;
using Utilitarios.Entrada;

namespace LogicaNC
{
    public class LLogin
    {
        private readonly Mapeo _context;

        public LLogin(Mapeo context)
        {
            _context = context;
        }

        public async Task<URegistro> ingresoLogin(LoginRequest login)
        {
            UMAC datos = new UMAC();
            UAcceso acceso = new UAcceso();
            MAC conexion = new MAC();
            LoginRequest user = new LoginRequest();
            user.Usuario = login.Usuario;
            user.Contrasena = login.Contrasena;
            acceso.FechaInicio = DateTime.Now;
            acceso.Ip = conexion.ip();
            acceso.Mac = conexion.mac();
            acceso.Session = "fgcypsr1u0ya0t5qd3o2runw";

            return await new DAOLogin(_context).verificarLogin(user,acceso);
        }
        
        public async Task guardarToken(LoginToken token){
            await new DAOSeguridad(_context).guardarTokenLogin(token);
        }

        public async Task<URegistro> ingreso(URegistro login)
        {
            return await new DAOLogin(_context).verificar(login);
        }



        /*
        public UMAC ingreso_login(URegistro login)
        {
            UMAC datos = new UMAC();
            UAcceso acceso = new UAcceso();
            datos.Registro = new DAOLogin().verificar(login);
            if (datos.Registro == null)
            {
                datos.Mensaje = "contrasena o usuario incorrecto";
            }
            else
            {
                MAC conexion = new MAC();
                acceso.FechaInicio = DateTime.Now;
                acceso.Ip = conexion.ip();
                acceso.Mac = conexion.mac();
                acceso.Session = "x";
                acceso.Userid = datos.Registro.Id;
                new DAOSeguridad().insertarAcceso(acceso);
                datos.Url = "Perfil.aspx";
            }
            return datos;
        }*/
    }
}
