using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_ActualizarDatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LActualizarDatos actualizarDatos = new LActualizarDatos();
        UActualizarDatos datos = new UActualizarDatos();
        datos = actualizarDatos.pageLoad((URegistro)Session["usuario"]);
       
        try
        {
            L_Actusuario.Text = datos.Actusuario;
            L_Actnombre.Text = datos.Actnombre;
            L_Actapellido.Text = datos.Actapellido;
            L_Actcorreo.Text = datos.Actcorreo;
            L_Acttelefono.Text = datos.Acttelefono;
            L_Actusuario0.Text = datos.Actusuario;
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect(datos.URL1);

        }
        
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        URegistro nuevodato = new URegistro();
        nuevodato.Usuario = TB_Actusuario.Text.ToUpper();
        nuevodato.Correo = TB_Actcorreo.Text.ToUpper();
        nuevodato.Id = ((URegistro)Session["usuario"]).Id;

        /*
        ClientScriptManager cm = this.ClientScript;
        Registro nuevodato = new Registro();
        nuevodato.Usuario = TB_Actusuario.Text.ToUpper();
        nuevodato.Correo = TB_Actcorreo.Text.ToUpper();
        nuevodato = new DAOLogin().verificaruser(nuevodato);
        if ((nuevodato != null) && (TB_Actusuario.Text != String.Empty))//si tb tiene algo
        {
            LB_Actfallo.Text = "Utiliza otro usuario, este ya existe o esta registrado";
        }else if ((nuevodato != null) && (TB_Actcorreo.Text != String.Empty))//si tb tiene algo
        {
            LB_Actfallo.Text = "Utiliza otro correo, este ya existe o esta registrado";
        }
        else
        { 
            Registro nuevodat = new Registro();
            nuevodat.Id = ((Registro)Session["usuario"]).Id;
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

            //L_Actnombre.Text = TB_Actnombre.Text;
            //L_Actapellido.Text = TB_Actapellido.Text;
            //L_Actcorreo.Text = TB_Actcorreo.Text;
            //L_Acttelefono.Text = TB_Acttelefono.Text;
            //L_Actusuario0.Text = TB_Actusuario.Text;

            //if (TB_Actnombre.Text == "")
            //{
            //    L_Actusuario.Text = "Bienvenido usuario: " + ((Registro)Session["usuario"]).Nombre;
            //}
            //else
            //{
            //    L_Actusuario.Text = "Bienvenido usuario: " + TB_Actnombre.Text;
            //}

            //if (L_Actnombre.Text == "")
            //{
            //    L_Actnombre.Text = ((Registro)Session["usuario"]).Nombre;
            //}
            //if (L_Actapellido.Text == "")
            //{
            //    L_Actapellido.Text = ((Registro)Session["usuario"]).Apellido;
            //}
            //if (L_Actcorreo.Text == "")
            //{
            //    L_Actcorreo.Text = ((Registro)Session["usuario"]).Correo;
            //}
            //if (L_Acttelefono.Text == "")
            //{
            //    L_Acttelefono.Text = ((Registro)Session["usuario"]).Telefono;
            //}
            //if (L_Actusuario0.Text == "")
            //{
            //    L_Actusuario0.Text = ((Registro)Session["usuario"]).Usuario;
            //}

            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Sus datos han sido actualizados.');</script>");
            //TB_Actnombre.Text = "";
            //TB_Actapellido.Text = "";
            //TB_Actcorreo.Text = "";
            //TB_Acttelefono.Text = "";
            //TB_Actusuario.Text = "";

            this.Controls.OfType<TextBox>().ToList().ForEach(o => o.Text = "");
            B_Volver.Text = "VOLVER";

            return;
        }
        */
    }
}