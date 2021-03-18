using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LActualizarContrasena
    {
        public UActualizarContrasena verificarsession(URegistro session)
        {
            URegistro login = new URegistro();
            UActualizarContrasena mensaje = new UActualizarContrasena();

            login.Usuario = session.Usuario;
            login.Contrasena = session.Contrasena;

            login = new DAOLogin().verificar(login);

            if (login == null)
            {
                mensaje.URL1 = "Login.aspx";
            }
            else
            {
                mensaje.Mensaje = "Complete los pasos para actualizar la contraseña";
            }

            return mensaje;

        }

        public UActualizarContrasena actualizarContrasena(URegistro datosE, string contrasenaAct, string contrasenaNueva)
        {
            URegistro login = new URegistro();
            UActualizarContrasena mensaje = new UActualizarContrasena();

            login.Usuario = datosE.Usuario;
            login.Contrasena = contrasenaAct;
            login.Correo = datosE.Correo;

            login = new DAOLogin().verificar(login);

            if (login == null)
            {
                mensaje.Mensaje = "Verifica tus datos.\n La contraseña no coinside con tu usuario";
            }
            else
            {
                login.Contrasena = contrasenaNueva;

                if (login.Contrasena.Length < 5)
                {
                    mensaje.Mensaje = "Su contraseña debe ser mayor a 5 caracteres.";
                }
                else
                {
                    new DAOLogin().actualizarcontrasena(login);
                    new Mail().mailactualizarcontrasena(login);
                    mensaje.Mensaje = "Contraseña actualizada";
                }
            }
            return mensaje;
        }
    }
}
