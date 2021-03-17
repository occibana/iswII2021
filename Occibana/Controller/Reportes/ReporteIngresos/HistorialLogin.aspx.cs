using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_Reportes_ReporteHoteles_HistorialLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            string idusuario = (((URegistro)Session["usuario"]).Id).ToString();
            L_NombreUsuario.Text = ((URegistro)Session["usuario"]).Usuario;
            CRS_HistorialLogin.ReportDocument.SetDataSource(Reporte(idusuario));
            CRV_HistorialLogin.ReportSource = CRS_HistorialLogin;
        }
        catch (Exception ex)
        {
            Session.Remove("usuario");
            Response.Redirect("~/vew/Login.aspx");
        }
    }

    
    public HistorialLogin Reporte(string idusuario)
    {
        HistorialLogin informe = new HistorialLogin();
        LReporte reporte = new LReporte();
        int idusuarion = int.Parse(idusuario);
        List<UAcceso> listaMisHoteles = reporte.registrosAcceso(idusuarion);

        DataTable datosReportes = informe.DT_HistorialLogin;
        DataRow filas;

        foreach (UAcceso registros in listaMisHoteles)
        {
            filas = datosReportes.NewRow();
            filas["FechaIngreso"] = registros.FechaInicio;
            filas["FechaSalida"] = registros.FechaFin;
 
            datosReportes.Rows.Add(filas);

        }
        return informe;
    }
    
}