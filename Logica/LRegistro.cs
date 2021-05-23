using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LRegistro
    {
        public async Task<URegistroMensaje> registro(URegistro registro)
        {
            URegistro pedidos = await new DAOLogin().verificaruser(registro);
            
            URegistroMensaje msj = new URegistroMensaje();
            if (pedidos == null)
            {
                if (registro.Contrasena.Length < 5)
                {
                    msj.Mensaje = "Ingrese una contraseña minimo de 5 caracteres";
                    msj.TB_contrasenaregistro = "";
                    msj.TB_ccontrasena = "";
                }
                else
                {
                    new DAOLogin().insertRegistro(registro);
                    new Mail().enviarmail(registro);
                    msj.Mensaje = "Registro Exitoso, Por Favor Inice Sesion";
                    msj.TB_nombre = "";
                    msj.TB_apellido = "";
                    msj.TB_correo = "";
                    msj.TB_telefono = "";
                    msj.TB_usuarioregistro = "";
                    msj.TB_contrasenaregistro = "";
                    msj.TB_ccontrasena = "";
                }

            }
            else
            {
                msj.Mensaje =  "Este usuario o correo ya existe o esta registrado";
            }
            return msj;
        }
        
    }
}
