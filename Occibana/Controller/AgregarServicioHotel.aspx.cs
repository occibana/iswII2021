using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_AgregarServicioHotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            L_SesionAnadirHotel.Text = ((URegistro)Session["usuario"]).Nombre;
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
        
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }


    protected void B_CargarHotel_Click(object sender, EventArgs e)
    {
        string direccionImagen;
        string direccionImagenA1; 
        string direccionImagenA2;

        UHotel hotel = new UHotel();
        hotel.Nombre = TB_NombreHotel.Text;
        hotel.Idmunicipio = int.Parse(DDL_Municipio.Text);
        hotel.Idzona = int.Parse(DDL_Zona.Text);
        hotel.Checkin = TB_Checkin.Text;
        hotel.Checkout = TB_Checkout.Text;
        hotel.Descripcion = TB_Descripcion.Text;
        hotel.Condicion = TB_Condiciones.Text;
        hotel.Usuarioencargado = ((URegistro)Session["usuario"]).Usuario;
        hotel.Condicionesbioseguridad = TB_descripcioncovid19.Text;
        hotel.Direccion = TB_Direccion.Text;
        hotel.PrecioNocheDoble = int.Parse(TB_PrecioNocheDoble.Text);
        hotel.PrecioNochePremium = int.Parse(TB_PrecioNochePremium.Text);
        hotel.Precionoche = int.Parse(TB_PrecioNoche.Text);
        hotel.Imagen = null;
        hotel.Imagen_secundaria = null;
        hotel.Imagen_secundaria2 = null;
        direccionImagen = "/Vew/hoteles/imgprincipal/" + ((URegistro)Session["usuario"]).Usuario + FU_ImgPrincipal.FileName;
        direccionImagenA1 ="/Vew/hoteles/imgadicional/" + ((URegistro)Session["usuario"]).Usuario + FU_ImgAdicional.FileName;
        direccionImagenA2 = "/Vew/hoteles/imgadicional/" + ((URegistro)Session["usuario"]).Usuario + FU_ImgAdicional0.FileName;
        direccionImagen = Server.MapPath(direccionImagen);
        direccionImagenA1 = Server.MapPath(direccionImagenA1);
        direccionImagenA2 = Server.MapPath(direccionImagenA2);
        hotel = new LAgregarServicioHotel().insertHotel(FU_ImgPrincipal, FU_ImgAdicional, FU_ImgAdicional0 ,direccionImagen, direccionImagenA1, direccionImagenA2,hotel);

        /*
        ClientScriptManager cm = this.ClientScript;
        Hotel serviciohotel = new Hotel();

        serviciohotel.Nombre = TB_NombreHotel.Text;
        serviciohotel.Precionoche = int.Parse(TB_PrecioNoche.Text);
        serviciohotel.Idmunicipio = int.Parse(DDL_Municipio.Text);
        serviciohotel.Idzona = int.Parse(DDL_Zona.Text);
        serviciohotel.Checkin = TB_Checkin.Text;
        serviciohotel.Checkout = TB_Checkout.Text;
        serviciohotel.Descripcion = TB_Descripcion.Text;
        serviciohotel.Condicion = TB_Condiciones.Text;
        serviciohotel.Usuarioencargado = ((Registro)Session["usuario"]).Usuario;
        serviciohotel.Condicionesbioseguridad = TB_descripcioncovid19.Text;
        serviciohotel.Direccion = TB_Direccion.Text;
        serviciohotel.PrecioNocheDoble = int.Parse(TB_PrecioNocheDoble.Text);
        serviciohotel.PrecioNochePremium = int.Parse(TB_PrecioNochePremium.Text); 


        //verifica si hay archivos seleccionados
        if (FU_ImgPrincipal.HasFile)
        {
            string direccion;
            string ext = System.IO.Path.GetExtension(FU_ImgPrincipal.FileName);//obtiene la extencion del archivo
            ext = ext.ToLower();//minusculas

            int tam = FU_ImgPrincipal.PostedFile.ContentLength;//obtiene tamano archivo

            if ((ext == ".jpg" || ext == ".png") && (tam < 1048576))//menor a 1MB en bytes
            {
                direccion = "~/Vew/hoteles/imgprincipal/" + ((Registro)Session["usuario"]).Usuario + FU_ImgPrincipal.FileName;
                FU_ImgPrincipal.SaveAs(Server.MapPath(direccion));//mapea y guarda el archivo en la direccion
                L_CargarimagenAgregarHotel.Text = "*Imagen aceptada";
                //actualiza foto de perfil
                
                serviciohotel.Imagen = direccion;
            }
            else
            {
                L_CargarimagenAgregarHotel.Text = "*Imagen no esta en formato correcto o es muy pesada";
            }
        }
        else
        {
            L_CargarimagenAgregarHotel.Text = "*Selecciona una imagen";
        }


        //verifica si hay archivos seleccionados
        if (FU_ImgAdicional.HasFile)
        {
            string direccion;
            string ext = System.IO.Path.GetExtension(FU_ImgAdicional.FileName);//obtiene la extencion del archivo
            ext = ext.ToLower();//minusculas

            int tam = FU_ImgAdicional.PostedFile.ContentLength;//obtiene tamano archivo

            if ((ext == ".jpg" || ext == ".png") && (tam < 1048576))//menor a 1MB en bytes
            {
                direccion = "~/Vew/hoteles/imgadicional/" + ((Registro)Session["usuario"]).Usuario + FU_ImgAdicional.FileName;
                FU_ImgAdicional.SaveAs(Server.MapPath(direccion));//mapea y guarda el archivo en la direccion
                L_CargarimagenAgregarHotel0.Text = "*Imagen aceptada";
                //actualiza foto de perfil

                serviciohotel.Imagen_secundaria = direccion;
            }
            else
            {
                L_CargarimagenAgregarHotel.Text = "*Imagen no esta en formato correcto o es muy pesada";
            }
        }
        else
        {
            serviciohotel.Imagen_secundaria = null;
        }


        //verifica si hay archivos seleccionados
        if (FU_ImgAdicional0.HasFile)
        {
            string direccion;
            string ext = System.IO.Path.GetExtension(FU_ImgAdicional0.FileName);//obtiene la extencion del archivo
            ext = ext.ToLower();//minusculas

            int tam = FU_ImgAdicional0.PostedFile.ContentLength;//obtiene tamano archivo

            if ((ext == ".jpg" || ext == ".png") && (tam < 1048576))//menor a 1MB en bytes
            {
                direccion = "~/Vew/hoteles/imgadicional/" + ((Registro)Session["usuario"]).Usuario + FU_ImgAdicional0.FileName;
                FU_ImgAdicional0.SaveAs(Server.MapPath(direccion));//mapea y guarda el archivo en la direccion
                L_CargarimagenAgregarHotel1.Text = "*Imagen aceptada";
                //actualiza foto de perfil

                serviciohotel.Imagen_secundaria2 = direccion;
            }
            else
            {
                L_CargarimagenAgregarHotel1.Text = "*Imagen no esta en formato correcto o es muy pesada";
            }
        }
        else
        {
            serviciohotel.Imagen_secundaria2 = null;
        }

        new DAOhotel().insertHotel(serviciohotel);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Hotel agregado correctamente');window.location=\"Perfil.aspx\"</script>");
     
        return;
        */
    }

}