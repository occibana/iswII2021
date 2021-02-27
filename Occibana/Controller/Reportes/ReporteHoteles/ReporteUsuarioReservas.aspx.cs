using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Reportes_ReporteHoteles_ReporteUsuarioReservas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        try
        {
            L_NombreUsuario.Text = ((Registro)Session["usuario"]).Usuario;
            pintarReporte((Registro)Session["usuario"]);
        }
        catch (Exception ex)
        {
            Session.Remove("usuario");
            Response.Redirect("~/vew/Login.aspx");
        }
        */
    }
    /*
    protected void pintarReporte(Registro usuario)
    {
        CRS_ReservasUsuario.ReportDocument.SetDataSource(llenarReserva(usuario));
        CRV_Reserva.ReportSource = CRS_ReservasUsuario;
    }

    public HistorialReservas llenarReserva(Registro usuario)
    {
        HistorialReservas informe = new HistorialReservas();
        List<Reserva> misReservas = new DAOReserva().mostrarmisreservas(usuario);

        DataTable datosReportes = informe._HistorialReservas;
        DataRow filas;

        foreach (Reserva reservas in misReservas)
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
    }*/
}