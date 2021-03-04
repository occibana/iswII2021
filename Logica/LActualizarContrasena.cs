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
                mensaje.Mensaje = "Verifica tus datos\n usuario o contraseña incorrecto";
            }
            else
            {
                mensaje.Mensaje = "Redireccionando...";
                mensaje.URL1 = "Login.aspx";
            }

            return mensaje;

        }

        public UActualizarContrasena actualizar(URegistro datosE, string contrasenaAct, string contrasenaNueva)
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
                    mensaje.Mensaje = "";
                }

                else
                {

                    new DAOLogin().actualizarcontrasena(login);
                    new Mail().mailactualizarcontrasena(login);
                    mensaje.Mensaje = "Contraseña actualizada";
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Contraseña actualizada correctamente');window.location=\"Perfil.aspx\"</script>");
                    //L_Error_noregistro.Text = "Contraseña actualizada";
                }
            }
            return mensaje;
        }
    }
}
