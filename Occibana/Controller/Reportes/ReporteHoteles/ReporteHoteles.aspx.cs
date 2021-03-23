using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_Reportes_ReporteHoteles_ReporteHoteles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_NombreUsuario.Text = ((URegistro)Session["usuario"]).Usuario;
            CRS_ReporteHoteles.ReportDocument.SetDataSource(llenarReporte(((URegistro)Session["usuario"])));
            CRV_ReporteHoteles.ReportSource = CRS_ReporteHoteles;
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("~/vew/Login.aspx");
        }
    }

    
    public ReporteHoteles llenarReporte(URegistro usuario)
    {
  
        ReporteHoteles informe = new ReporteHoteles();
        LReporte reporte = new LReporte();
        List<UHotel> listaMisHoteles = reporte.listaMisHoteles(usuario);

        DataTable datosReportes = informe._ReporteHoteles;
        DataRow filas;

        foreach (UHotel hoteles in listaMisHoteles)
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
        
        
    }
}