using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Reportes_ReporteHoteles_HistorialLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        try
        {
            string idusuario = (((Registro)Session["usuario"]).Id).ToString();
            L_NombreUsuario.Text = ((Registro)Session["usuario"]).Usuario;
            pintarReporte(idusuario);
        }
        catch (Exception ex)
        {
            Session.Remove("usuario");
            Response.Redirect("~/vew/Login.aspx");
        }*/
    }

    protected void pintarReporte(string idusuario)
    {
        /*
        CRS_HistorialLogin.ReportDocument.SetDataSource(Reporte(idusuario));
        CRV_HistorialLogin.ReportSource = CRS_HistorialLogin;
        */
    }

    /*
    public HistorialLogin Reporte(string idusuario)
    {
        HistorialLogin informe = new HistorialLogin();
        int idusuarion = int.Parse(idusuario);
        List<Acceso> listaMisHoteles = new DAOSeguridad().RegistrosAcceso(idusuarion); ;

        DataTable datosReportes = informe.DT_HistorialLogin;
        DataRow filas;

        foreach (Acceso registros in listaMisHoteles)
        {
            filas = datosReportes.NewRow();
            filas["FechaIngreso"] = registros.FechaInicio;
            filas["FechaSalida"] = registros.FechaFin;
 
            datosReportes.Rows.Add(filas);

        }
        return informe;
    }
    */
}