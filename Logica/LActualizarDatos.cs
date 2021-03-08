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

        public UActualizarDatos actualizarDatos(URegistro datosRegistro)
        {
            UActualizarDatos datos = new UActualizarDatos();
            datosRegistro = new DAOLogin().verificaruser(datosRegistro);
            if ((datosRegistro != null) && (datosRegistro.Usuario != String.Empty))//si tb tiene algo
            {
                datos.Mensaje = "Utiliza otro usuario, este ya existe o esta registrado";
            }
            else if ((datosRegistro != null) && (datosRegistro.Correo != String.Empty))//si tb tiene algo
            {
                datos.Mensaje = "Utiliza otro correo, este ya existe o esta registrado";
            }
            else
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
                    nuevodat.Usuario = ((Registro)Session["usuario"]).Usuario;
                }
                if (TB_Actnombre.Text == String.Empty)
                {
                    nuevodat.Nombre = ((Registro)Session["usuario"]).Nombre;
                }
                if (TB_Actapellido.Text == String.Empty)
                {
                    nuevodat.Apellido = ((Registro)Session["usuario"]).Apellido;
                }
                if (TB_Acttelefono.Text == String.Empty)
                {
                    nuevodat.Telefono = ((Registro)Session["usuario"]).Telefono;
                }
                if (TB_Actcorreo.Text == String.Empty)
                {
                    nuevodat.Correo = ((Registro)Session["usuario"]).Correo;
                }
                new DAOLogin().actualizarperfil(nuevodat);

                ((Registro)Session["usuario"]).Usuario = nuevodat.Usuario;
                ((Registro)Session["usuario"]).Nombre = nuevodat.Nombre;
                ((Registro)Session["usuario"]).Apellido = nuevodat.Apellido;
                ((Registro)Session["usuario"]).Telefono = nuevodat.Telefono;
                ((Registro)Session["usuario"]).Correo = nuevodat.Correo;

                LB_Actfallo.Text = "Datos actualizados correctamente";
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Datos actualizados correctamente');window.location=\"Perfil.aspx\"</script>");

               

                this.Controls.OfType<TextBox>().ToList().ForEach(o => o.Text = "");
                B_Volver.Text = "VOLVER";

                return;
            }

            return datos;
        }
    }
}
