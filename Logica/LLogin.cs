using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Utilitarios;

namespace Logica
{
    public class LLogin
    {
        public UMAC ingreso_login(URegistro login,string session_id)
        {
            UMAC datos = new UMAC();
            UAcceso acceso = new UAcceso();
            string msj=null;

            datos.Registro = new DAOLogin().verificar(login);

            if (datos.Registro.Usuario == null)
            {
                msj = "usuario incorrecto";
            }else if (datos.Registro.Contrasena == null)
            {
                msj = "contrasena incorrecta";
            }
            else
            {

                MAC conexion = new MAC();
                acceso.FechaInicio = DateTime.Now;
                acceso.Ip = conexion.ip();
                acceso.Mac = conexion.mac();
                acceso.Session = session_id;
                acceso.Userid = datos.Registro.Id;
                new DAOSeguridad().insertarAcceso(acceso);
                datos.Url = "Perfil.aspx";
            }

            //if (login == null)
            //{
            //    string msj = "Verifica tus datos\n usuario o contraseña incorrecto";
            //    return msj;
            //}
            //else
            //{
            //    Session["usuario"] = login;
            //    MAC conexion = new MAC();
            //    UAcceso acceso = new UAcceso();
            //    acceso.FechaInicio = DateTime.Now;
            //    acceso.Ip = conexion.ip();
            //    acceso.Mac = conexion.mac();
            //    acceso.Session = Session.SessionID;
            //    acceso.Userid = login.Id;

            //    new DAOSeguridad().insertarAcceso(acceso);

            //    return datos;
            //}

            return datos;
        }
    }
}
