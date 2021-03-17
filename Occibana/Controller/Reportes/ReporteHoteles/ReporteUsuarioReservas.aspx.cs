using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_Reportes_ReporteHoteles_ReporteUsuarioReservas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_NombreUsuario.Text = ((URegistro)Session["usuario"]).Usuario;
            CRS_ReservasUsuario.ReportDocument.SetDataSource(llenarReserva((URegistro)Session["usuario"]));
            CRV_Reserva.ReportSource = CRS_ReservasUsuario;
        }
        catch (Exception ex)
        {
            Session.Remove("usuario");
            Response.Redirect("~/vew/Login.aspx");
        }
    }

    public HistorialReservas llenarReserva(URegistro usuario)
    {
        HistorialReservas informe = new HistorialReservas();
        LReporte reporte = new LReporte();
        List<UReserva> misReservas = reporte.listaMisHoteles(usuario); 

        DataTable datosReportes = informe._HistorialReservas;
        DataRow filas;

        foreach (UReserva reservas in misReservas)
        {
            filas = datosReportes.NewRow();
            filas["NombreUsuario"] = reservas.Nombre;
            filas["NombreHotel"] = reservas.Nombrehotel;
            filas["FechaLlegada"] = reservas.Fecha_llegada;
            filas["FechaSalida"] = reservas.Fecha_salida;
            filas["ValorNoche"] = reservas.PrecioNoche;

            datosReportes.Rows.Add(filas);

        }
        return informe;
    }
}