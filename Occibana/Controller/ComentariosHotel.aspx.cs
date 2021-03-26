using System;

using Utilitarios;
using Logica;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_ComentariosHotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UHotel hotel = new UHotel();
        hotel.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
        hotel = new LComentariosHotel().info_hotel(hotel);
        try
        {
            L_NombreHotel.Text = hotel.Nombre.ToUpper();
            L_Nombrehotel2.Text = hotel.Nombre.ToUpper();

            if ((URegistro)Session["usuario"] == null)
            {
                L_Usuario.Text = "Inicie sesion para comentar";
                B_Comentar.Enabled = false;
                B_Calificar.Enabled = false;
            }
            else
            {

                L_Usuario.Text = ((URegistro)Session["usuario"]).Nombre;
                B_Comentar.Enabled = true;
                B_Calificar.Enabled = true;
            }
        }
        catch
        {
            Session.Remove("visitarhotel");
            Response.Redirect(hotel.Url);
        }
    }

    protected void B_Comentar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        UComentarios comenta = new UComentarios();
        comenta.Comentario = TB_Comentario.Text;
        LComentariosHotel logica = new LComentariosHotel();
        UComentario_CalificacionDatos datos = new UComentario_CalificacionDatos();
        datos = logica.comentar((URegistro)Session["usuario"],comenta,(UHotel)Session["visitarhotel"]);
        TB_Comentario.Text = datos.ComentarioTb;
        L_Fallocalificacion.Text = datos.Mensaje;
        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('"+datos.Mensaje+"');</script>");

        /*
        ClientScriptManager cm = this.ClientScript;
        try
        {
            Comentarios comenta = new Comentarios();

            comenta.Id_hotel = ((Hotel)Session["visitarhotel"]).Idhotel;
            comenta.Id_usuario = ((Registro)Session["usuario"]).Id;
            comenta.Comentario = TB_Comentario.Text;
            comenta.Fecha_comentario = DateTime.Now;
            
            Boolean consulta = new DAOComentarios().consulta(comenta);
            if (consulta == true)
            {
                new DAOComentarios().insertComentario(comenta);
                TB_Comentario.Text = "";
                L_Mensaje.Text = "Comentario Agregado.";
            }
            else
            {
                L_Mensaje.Text = "No puede comentar.";
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No tiene permitido comentar');</script>");
            }

           // new DAOComentarios().insertComentario(comenta);
           // TB_Comentario.Text = "";
           // L_Mensaje.Text = "Comentario Agregado.";
           //// cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Comentario Agregado');</script>");
            
        }
        catch (Exception ex) 
        {
            L_Mensaje.Text = "Para comentar, inicie sesion.";
            L_Mensaje.Visible = true;
            TB_Comentario.Text = "";
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No tiene permitido comentar');</script>");
            //Response.Redirect("ComentariosHotel.aspx"); 
        }

        */
    }

    protected void B_Calificar_Click(object sender, EventArgs e)
    {

        RadioButton[] arrayRadioButton = { RB_0estrella, RB_1estrella, RB_2estrella, RB_3estrella, RB_4estrella, RB_5estrella };
        LComentariosHotel logica = new LComentariosHotel();
        UReserva inforeserva = new UReserva();
        UComentario_CalificacionDatos mensaje = new UComentario_CalificacionDatos();
        if (Session["calificarhotel"] != null)
        {
            inforeserva.Id = int.Parse(Session["calificarhotel"].ToString());
        }
        else
        {
            inforeserva.Idhotel = ((UHotel)Session["visitarhotel"]).Idhotel;
            inforeserva.Idusuario = ((URegistro)Session["usuario"]).Id;
        }
        mensaje = logica.calificar(((URegistro)Session["usuario"]), ((UHotel)Session["visitarhotel"]), inforeserva, arrayRadioButton);
        L_Fallocalificacion.Text = mensaje.Mensaje;
    }
}