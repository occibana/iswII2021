using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Utilitarios;
using Logica;

public partial class Vew_Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UPerfil datos = new UPerfil();
            datos = new LPerfil().cargardatos(((URegistro)Session["usuario"]));

            L_Pnombre.Text = datos.Datos.Nombre;
            L_Pcorreo.Text = datos.Datos.Correo;
            L_Ptelefono.Text = datos.Datos.Telefono;
            L_Pusuariodatospersonales.Text = datos.Datos.Usuario;
            L_Pusuario.Text = datos.Datos.Usuario;
            fotoperfil.ImageUrl = datos.Datos.Fotoperfil;
            L_EstadoMembresia.Text = datos.Mensaje;
            B_ComprarMembresia.Visible = datos.B_ComprarMembresia1;
            B_ActualizarMembresia.Visible = datos.B_ActualizarMembresia1;
            B_AgregarHotel.Visible = datos.B_AgregarHotel1;
            B_mishoteles.Visible = datos.B_mishoteles1;
        }
        catch
        {
            Session.Remove("usuario");
            Session.Remove("visitarhotel");
            Response.Redirect("Login.aspx");
        }
        

        /*
        try
        {
            L_Pnombre.Text = ((Registro)Session["usuario"]).Nombre;
            L_Pcorreo.Text = ((Registro)Session["usuario"]).Correo;

            L_Ptelefono.Text = ((Registro)Session["usuario"]).Telefono;
            L_Pusuariodatospersonales.Text = ((Registro)Session["usuario"]).Usuario;
            L_Pusuario.Text = ((Registro)Session["usuario"]).Usuario;
            fotoperfil.ImageUrl = ((Registro)Session["usuario"]).Fotoperfil;
            if (((Registro)Session["usuario"]).Fotoperfil == null)
            {
                fotoperfil.ImageUrl="~/Vew/img/perfilvacio.jpg";
            }
            //
            if (((Registro)Session["usuario"]).Idestado == 1) //1 Es con menbresia, 0 sin membresia
            {
                B_ComprarMembresia.Visible = false;
                B_ActualizarMembresia.Visible = true;
                B_AgregarHotel.Visible = true;
                L_EstadoMembresia.Text = "Con Membresia";
                var verificar = new DAOSeguridad().verificarvencimientomembresia(((Registro)Session["usuario"]).Id);
                if (verificar != null)
                {
                    Registro usuario = new Registro();
                    usuario.Id = ((Registro)Session["usuario"]).Id;
                    usuario.Idestado = 0;
                    new DAOSeguridad().actualizarmembresia(usuario);
                    Response.Redirect("Perfil.aspx");
                }
            }
            else
            {
                B_ComprarMembresia.Visible = true;
                B_ActualizarMembresia.Visible = false;
                B_AgregarHotel.Visible = false;
                L_EstadoMembresia.Text = "Sin Membresia";
                B_mishoteles.Visible = false;
            }
            //
        }
        catch
        {
            Session.Remove("usuario");
            Session.Remove("visitarhotel"); 
            Response.Redirect("Login.aspx");
        }
        */
    }

    protected void B_CerrarSession_Click(object sender, EventArgs e)
    {
        LPerfil perfil = new LPerfil();
        string result = perfil.cerrarsession(((URegistro)Session["usuario"]));
        Session.Remove("usuario");
        Session.Remove("visitarhotel");
        Response.Redirect(result);
    }



    protected void B_SubirFoto_Click(object sender, EventArgs e)
    {
        string direccion;
        string imagen;
        string imagenEliminar;
        string nombreArchivo;
        string nombreArchivoEliminar;
        nombreArchivo = ((URegistro)Session["usuario"]).Usuario + FU_FotoPerfil.FileName;
        nombreArchivoEliminar = ((URegistro)Session["usuario"]).Fotoperfil;
        direccion = "~\\Vew\\imgusuarios\\"+nombreArchivo;
        imagen = HttpContext.Current.Server.MapPath("~\\Vew\\imgusuarios\\")+nombreArchivo;
        imagenEliminar = HttpContext.Current.Server.MapPath(nombreArchivoEliminar);
        LPerfil logica = new LPerfil();
        UPerfil datos = new UPerfil();

        datos = logica.subirFoto(FU_FotoPerfil, (URegistro)Session["usuario"], direccion,imagen,imagenEliminar);

        L_Pcargaimagen.Text = datos.Mensaje;
        fotoperfil.ImageUrl = datos.Fotoperfil;

    }

    protected void B_ActualizarDatos_Click(object sender, EventArgs e)
    {
        Response.Redirect("ActualizarDatos.aspx");
    }

    protected void B_CambiarContrasena_Click(object sender, EventArgs e)
    {
        Response.Redirect("Actualizarcontrasena.aspx");
    }

    protected void B_AgregarHotel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgregarServicioHotel.aspx");
    }

    protected void B_ComprarMembresia_Click(object sender, EventArgs e)
    {
        Response.Redirect("Membresias.aspx");
    }

    protected void B_ActualizarMembresia_Click(object sender, EventArgs e)
    {
        Response.Redirect("Membresias.aspx");
    }

    protected void B_mishoteles_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mishoteles.aspx");
    }

    protected void B_Misreservas_Click(object sender, EventArgs e)
    {
        Response.Redirect("Misreservas.aspx");
    }

    protected void B_VerReporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vew/Reportes/ReporteHoteles/HistorialLogin.aspx");
    }
}