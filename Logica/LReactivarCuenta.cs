using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Utilitarios;

namespace Logica
{
    public class LReactivarCuenta
    {
        public UReactivarCuentaDatos page_load(System.Collections.Specialized.NameValueCollection url)
        {
            UReactivarCuentaDatos datos = new UReactivarCuentaDatos();

            if (url != null)
            {
                string urlToken = url.ToString();
                UToken token = new DAOSeguridad().validartoken(urlToken);//enviando url+token 
                
                if (token == null)
                {
                    datos.Mensaje = "No puede acceder sin un link de recuperacion, verifique su correo";
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No puede acceder sin un link de recuperacion, verifique su correo');window.location=\"Login.aspx\"</script>");
                }
                else if (token.Fecha_caducidad < DateTime.Now)
                {
                    datos.Mensaje = "Tiempo de validez de token ha terminado";
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Tiempo de validez de token ha terminado');window.location=\"Login.aspx\"</script>");
                }
                else
                {
                    datos.User_id = token.User_id;
                }
            }
            else
            {
                datos.Url = "Login.aspx";
            }
            return datos;
        }
    }
}
