using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Vew_Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        /*
        new DAOSeguridad().cerrarAcceso(((Registro)Session["usuario"]).Id);
        Session.Remove("usuario");
        Session.Remove("visitarhotel");
        Response.Redirect("Login.aspx");
        */
    }



    protected void B_SubirFoto_Click(object sender, EventArgs e)
    {
        /*
        //verifica si hay archivos seleccionados
        if (FU_FotoPerfil.HasFile)
        {
            string direccion;
            string ext = System.IO.Path.GetExtension(FU_FotoPerfil.FileName);//obtiene la extencion del archivo
            ext = ext.ToLower();//minusculas

            int tam = FU_FotoPerfil.PostedFile.ContentLength;//obtiene tamano archivo
            //string fotoperfil;

            if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg") && (tam < 1048576))//menor a 1MB en bytes
            {
                direccion = "~/Vew/imgusuarios/" + ((Registro)Session["usuario"]).Usuario + FU_FotoPerfil.FileName;
                FU_FotoPerfil.SaveAs(Server.MapPath(direccion));//mapea y guarda el archivo en la direccion
                L_Pcargaimagen.Text = "*Imagen aceptada";
                //actualiza foto de perfil
                Registro nuevodat = new Registro();
                nuevodat.Id = ((Registro)Session["usuario"]).Id;
                nuevodat.Fotoperfil = direccion;
                new DAOLogin().actualizarfoto(nuevodat);
                fotoperfil.ImageUrl = ((Registro)Session["usuario"]).Fotoperfil;
                L_Pcargaimagen.Text = "*Imagen cargada con exito";
       
            }
            else
            {
                L_Pcargaimagen.Text = "*Imagen no esta en formato correcto o es muy pesada";
            }
            
        }
        else
        {
            L_Pcargaimagen.Text = "*Selecciona una imagen";
        }
        */
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