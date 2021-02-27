using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Reportes_ReporteHoteles_ReporteHoteles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        try
        {
            L_NombreUsuario.Text = ((Registro)Session["usuario"]).Usuario;
            pintarReporte(L_NombreUsuario.Text);
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("~/vew/Login.aspx");
        }
        */
    }

    protected void pintarReporte(string usuario)
    {
        /*
        CRS_ReporteHoteles.ReportDocument.SetDataSource(llenarReporte(usuario));
        CRV_ReporteHoteles.ReportSource = CRS_ReporteHoteles;
        */
    }

    /*
    public ReporteHoteles llenarReporte(string usuario)
    {
  
        ReporteHoteles informe = new ReporteHoteles();
        List<Hotel> listaMisHoteles = new DAOhotel().obtenerhoteles(usuario);

        DataTable datosReportes = informe._ReporteHoteles;
        DataRow filas;

        foreach (Hotel hoteles in listaMisHoteles)
        {
            filas = datosReportes.NewRow();
            filas["Numbre_del_Hotel"] = hoteles.Nombre;
            filas["Precio_Noche"] = hoteles.Precionoche;
            filas["#Hbitaciones"] = hoteles.Numhabitacion;
            filas["Precio_Noche_Doble"] = hoteles.PrecioNocheDoble;
            filas["Precio_Noche_Premium"] = hoteles.PrecioNochePremium;

            datosReportes.Rows.Add(filas);

        }
        return informe;
        
        
    }*/
}