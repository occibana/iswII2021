using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LActualizarDatos
    {
        public UActualizarDatos pageLoad(URegistro sessionE)
        {
            UActualizarDatos datos = new UActualizarDatos();

            if (sessionE == null)
            {
                datos.URL1 = "Login.aspx";
            }
            else
            {
                datos.Actusuario = sessionE.Nombre;
                datos.Actnombre = sessionE.Nombre;
                datos.Actapellido = sessionE.Apellido;
                datos.Actcorreo = sessionE.Correo;
                datos.Acttelefono = sessionE.Telefono;
                datos.Actusuario0 = sessionE.Usuario;       
            }
            return datos;
        }

        public UActualizarDatos actualizarDatos(URegistro datosRegistro, URegistro datosSession)
        {
            UActualizarDatos datos = new UActualizarDatos();
            //datosRegistro;
            datos.Actnombre = datosRegistro.Nombre;
            datos.Actapellido = datosRegistro.Apellido;
            datos.Actusuario = datosRegistro.Usuario;
            datos.Acttelefono = datosRegistro.Telefono;
            datos.Actcorreo = datosRegistro.Correo;
            URegistro actRegistro = new DAOLogin().verificaruser(datosRegistro);
            if ((actRegistro != null) && (actRegistro.Usuario != String.Empty))//si tb tiene algo
            {
                datos.Mensaje = "Utiliza otro usuario, este ya existe o esta registrado";
            }
            else if ((actRegistro != null) && (actRegistro.Correo != String.Empty))//si tb tiene algo
            {
                datos.Mensaje = "Utiliza otro correo, este ya existe o esta registrado";
            }
            else
            {
                if (datosRegistro.Usuario == String.Empty)
                {
                    datos.Actusuario = datosSession.Usuario;
                }
                if (datosRegistro.Nombre == String.Empty)
                {
                    datos.Actnombre = datosSession.Nombre;
                }
                if (datosRegistro.Apellido == String.Empty)
                {
                    datos.Actapellido = datosSession.Apellido;
                }
                if (datosRegistro.Telefono == String.Empty)
                {
                    datos.Acttelefono = datosSession.Telefono;
                }
                if (datosRegistro.Correo == String.Empty)
                {
                    datos.Actcorreo = datosSession.Correo;
                }
                URegistro reg = new URegistro();
                reg.Nombre = datos.Actnombre;
                reg.Apellido = datos.Actapellido;
                reg.Usuario = datos.Actusuario;
                reg.Telefono = datos.Acttelefono;
                reg.Correo = datos.Actcorreo;
                reg.Id = datosSession.Id;
                new DAOLogin().actualizarperfil(reg);

                datosSession.Nombre = reg.Nombre;
                datosSession.Apellido = reg.Apellido;
                datosSession.Usuario = reg.Usuario;
                datosSession.Telefono = reg.Telefono;
                datosSession.Correo = reg.Correo;
            }
            /*else
            {
                URegistro nuevodat = new URegistro();
                nuevodat.Id = datosRegistro.Id;
                nuevodat.Usuario = TB_Actusuario.Text;
                nuevodat.Nombre = TB_Actnombre.Text;
                nuevodat.Apellido = TB_Actapellido.Text;
                nuevodat.Telefono = TB_Acttelefono.Text;
                nuevodat.Correo = TB_Actcorreo.Text;

                if (TB_Actusuario.Text == String.Empty)
                {
                    nuevodat.Usuario = ((URegistro)Session["usuario"]).Usuario;
                }
                if (TB_Actnombre.Text == String.Empty)
                {
                    nuevodat.Nombre = ((URegistro)Session["usuario"]).Nombre;
                }
                if (TB_Actapellido.Text == String.Empty)
                {
                    nuevodat.Apellido = ((URegistro)Session["usuario"]).Apellido;
                }
                if (TB_Acttelefono.Text == String.Empty)
                {
                    nuevodat.Telefono = ((URegistro)Session["usuario"]).Telefono;
                }
                if (TB_Actcorreo.Text == String.Empty)
                {
                    nuevodat.Correo = ((URegistro)Session["usuario"]).Correo;
                }
                new DAOLogin().actualizarperfil(nuevodat);

                ((URegistro)Session["usuario"]).Usuario = nuevodat.Usuario;
                ((URegistro)Session["usuario"]).Nombre = nuevodat.Nombre;
                ((URegistro)Session["usuario"]).Apellido = nuevodat.Apellido;
                ((URegistro)Session["usuario"]).Telefono = nuevodat.Telefono;
                ((URegistro)Session["usuario"]).Correo = nuevodat.Correo;

                LB_Actfallo.Text = "Datos actualizados correctamente";
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Datos actualizados correctamente');window.location=\"Perfil.aspx\"</script>");

               

                this.Controls.OfType<TextBox>().ToList().ForEach(o => o.Text = "");
                B_Volver.Text = "VOLVER";

                return;
            }*/

            return datos;
        }

        
    }
}
