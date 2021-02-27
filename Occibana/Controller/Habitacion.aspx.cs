using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Habitacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_Prueba.Text = Session["tabla"].ToString();
            L_Prueba.Visible = false;
        }
        catch
        {
            Response.Redirect("index.aspx");
        }        
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mishoteles.aspx");
    }

    protected void B_AgregarHabitacion_Click(object sender, EventArgs e)
    {
        /*
        int idtipo = 0;
        Habitacion habit = new Habitacion();

        habit.Numpersonas = int.Parse(TB_NumPersonas.Text);
        habit.Numbanio = int.Parse(TB_NumBanio.Text);
        habit.Idhotel = int.Parse(L_Prueba.Text);
        habit.Tipo = DDL_Tipo.Text;
        idtipo = DDL_Tipo.SelectedIndex;
        habit.Numcamas = int.Parse(TB_NumeroDeCamas.Text);

        if (DDL_Tipo.Text != "--Seleccionar--")
        {
            Hotel infohotel = new Hotel();
            infohotel.Idhotel = habit.Idhotel;
            infohotel = new DAOhotel().infohotel(infohotel);
            if (idtipo == 1)//basica
            {
                habit.Precio = infohotel.Precionoche;
            }
            if (idtipo == 2)//doble
            {
                habit.Precio = infohotel.PrecioNocheDoble;
            }
            if (idtipo == 3)//premium
            {
                habit.Precio = infohotel.PrecioNochePremium;
            }
            int cantHabitaciones = new DAOHabitacion().cantidadHabitaciones(habit);
            if (cantHabitaciones == 150)
            {
                L_Error_habitacion.Text = " Limite de habitaciones alcanzado";
            }
            else
            {
                new DAOHabitacion().insertHabitacion(habit);
                new DAOhotel().actualizarhabiatacion(habit);
                L_Error_habitacion.Text = " Habitacion añadida con exito";

                TB_NumPersonas.Text = "";
                TB_NumBanio.Text = "";
                //DDL_Tipo.ID = "0";
                TB_NumeroDeCamas.Text = "";
            }
        }
        else
        {
            L_Tipo.Text = "Seleccione una opción";
        }
        */
 
    }
}