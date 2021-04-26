using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_index : System.Web.UI.Page
{

    protected void DL_Listaprincipalhoteles_ItemCommand(object source, DataListCommandEventArgs e)
    {
        UHotel hotelinfo = new UHotel();
        hotelinfo.Idhotel = int.Parse(e.CommandArgument.ToString());
        Session["visitarhotel"] = hotelinfo;
        Session.Remove("calificarhotel");
        Response.Redirect("PanelHotel.aspx");
    }

    protected void IB_Busquedageneral_Click(object sender, ImageClickEventArgs e)
    {
        UFiltro busqueda = new UFiltro();
        busqueda.nombrehotel = TB_Busquedageneral.Text;
        busqueda.nombrehotel = new LFiltro().filtro_general_nombre(busqueda);

        Session["hotelseleccionado"] = busqueda;
        DL_Listaprincipalhoteles.DataBind();
    }

    protected void B_Filtrar_Click(object sender, EventArgs e)
    {
        LFiltro filtro = new LFiltro();
        UFiltro busqueda = new UFiltro();
    
        busqueda = filtro.filtro_general(TB_PrecioMin.Text,TB_PrecioMax.Text,TB_Maxpersonas.Text, TB_DateAntesDe.Text, TB_DateDespuesDe.Text, DDL_Calificacion.Text, DDL_Zona.Text, DDL_Municipio.Text, DDL_Tipo.Text);   

        //L_MensajeFalloFechas.Text = msj;
        Session["hotelseleccionado"] = busqueda;
        DL_Listaprincipalhoteles.DataBind();
        
    }

    protected void B_LimpiarFechas_Click(object sender, EventArgs e)
    {
        //TB_DateAntesDe.Text = "";
        //TB_DateDespuesDe.Text = "";
        //DDL_Zona.Text = "--Seleccionar--";
        //DDL_Municipio.Text = "--Seleccionar--";

        Response.Redirect("index.aspx");
    }

    protected void B_DescargaManual_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://drive.google.com/file/d/1Qe0pdKkkGwYtIuNSlGKGYyXOAf_fwyMF/view?usp=sharing");
    }
}
