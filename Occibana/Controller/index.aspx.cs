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
    protected void Page_Load(object sender, EventArgs e)
    {
        LFiltro filtro = new LFiltro();
        filtro.filtro_general_inicial();
        
    }

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
        UFiltro busqueda = new UFiltro();

        try
        {
            busqueda.preciomin = int.Parse(TB_PrecioMin.Text);
            busqueda.preciomax = int.Parse(TB_PrecioMax.Text);
            busqueda.numpersonas = int.Parse(TB_Maxpersonas.Text);
            busqueda.fecha_antesde = DateTime.Parse(TB_DateAntesDe.Text);
            busqueda.fecha_despuesde = DateTime.Parse(TB_DateDespuesDe.Text);
        }
        catch
        {
            busqueda.preciomin = null;
            busqueda.preciomax = null;
            busqueda.numpersonas = null;
        }

        busqueda.calificacion = DDL_Calificacion.Text;
        busqueda.zona = DDL_Zona.Text;
        busqueda.municipio = DDL_Municipio.Text;
        busqueda.tipo = DDL_Tipo.Text;

        //string msj = (new LFiltro().filtro_general(busqueda)).Item2;
        busqueda = (new LFiltro().filtro_general(busqueda)).Item1;

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
}
