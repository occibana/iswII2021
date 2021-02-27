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
        public string registro(URegistro registro)
        {
            URegistro pedidos = new DAOLogin().verificaruser(registro);
            if (pedidos == null)
            {
                if (registro.Contrasena.Length < 5)
                {
                    return "Ingrese una contraseña minimo de 5 caracteres";                             
                }
                else
                {
                    new DAOLogin().insertRegistro(registro);
                    new Mail().enviarmail(registro);
                    return "Registro Exitoso, Por Favor Inice Sesion";                    
                }

            }
            else
            {
                return "Este usuario o correo ya existe o esta registrado";
            }
        }
        
    }
}
