using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;
using Utilitarios.Entrada;

namespace Logica
{
    public class LActualizarContrasena
    {
        public async Task<UActualizarContrasena> verificarsession(URegistro session)
        {

            URegistro loginR = new URegistro();
            LoginRequest login = new LoginRequest();
            UActualizarContrasena mensaje = new UActualizarContrasena();

            login.Usuario = session.Usuario;
            login.Contrasena = session.Contrasena;


            loginR = await new DAOLogin().verificar(login);

            if (loginR == null)
            {
                mensaje.URL1 = "Login.aspx";
            }
            else
            {
                mensaje.Mensaje = "Complete los pasos para actualizar la contraseña";
            }

            return mensaje;

        }

        public async Task<UActualizarContrasena> actualizarContrasena(URegistro datosE, string contrasenaAct, string contrasenaNueva)
        {
            URegistro loginR = new URegistro();
            LoginRequest login = new LoginRequest();
            UActualizarContrasena mensaje = new UActualizarContrasena();

            loginR.Usuario = datosE.Usuario;
            loginR.Contrasena = contrasenaAct;
            loginR.Correo = datosE.Correo;

            loginR = await new DAOLogin().verificar(login);

            if (loginR == null)
            {
                mensaje.Mensaje = "Verifica tus datos.\n La contraseña no coinside con tu usuario";
            }
            else
            {
                loginR.Contrasena = contrasenaNueva;

                if (loginR.Contrasena.Length < 5)
                {
                    mensaje.Mensaje = "Su contraseña debe ser mayor a 5 caracteres.";
                }
                else
                {
                    new DAOLogin().actualizarcontrasena(loginR);
                    new Mail().mailactualizarcontrasena(loginR);
                    mensaje.Mensaje = "Contraseña actualizada";
                }
            }
            return mensaje;
        }
    }
}
