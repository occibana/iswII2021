using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LComentariosHotel
    {
        public UHotel info_hotel(UHotel session)
        {
            UHotel hotel = new UHotel();
            if (session != null)
            {
                hotel.Idhotel = session.Idhotel;
                hotel = new DAOhotel().infohotel(hotel);
                return hotel;

                /*
                if ((Registro)Session["usuario"] == null)
                {
                    L_Usuario.Text = "Inicie sesion para comentar";
                    B_Comentar.Enabled = false;
                    B_Calificar.Enabled = false;
                }
                else
                {

                    L_Usuario.Text = ((Registro)Session["usuario"]).Nombre;
                    B_Comentar.Enabled = true;
                    B_Calificar.Enabled = true;
                }
                */
            }
            else
            {
                return hotel;
            }
        }

        public UComentarioDatos comentar(URegistro session, UComentarios comentario, UHotel hotelSession)
        {
            UComentarioDatos datos = new UComentarioDatos();
            if (session != null)
            {
                UComentarios comenta = new UComentarios();
                comenta.Id_hotel = hotelSession.Idhotel;
                comenta.Id_usuario = session.Id;
                comenta.Comentario = comentario.Comentario;
                comenta.Fecha_comentario = DateTime.Now;

                Boolean consulta = new DAOComentarios().consulta(comenta);
                if (consulta == true)
                {
                    new DAOComentarios().insertComentario(comenta);
                    datos.ComentarioTb = "";
                    datos.Mensaje = "Comentario Agregado.";
                }
                else
                {
                    datos.Mensaje = "No puede comentar";
                }
            }
            else
            {
                datos.Mensaje = "Para comentar, inicie sesion.";
                datos.ComentarioTb = "";
            }

            return datos;
        }
    }
}
