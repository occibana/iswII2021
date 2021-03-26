using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;
using System.Web.UI.WebControls;
using System.Web.SessionState;

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
            }
            else
            {
                hotel.Url = "index.aspx";
                return hotel;
            }
        }

        public UComentario_CalificacionDatos comentar(URegistro session, UComentarios comentario, UHotel hotelSession)
        {
            UComentario_CalificacionDatos datos = new UComentario_CalificacionDatos();
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

        public UComentario_CalificacionDatos calificar(URegistro sessionUsuario, UHotel hotelSession, UReserva inforeserva, RadioButton[] arrayRadioButton)
        {
            UComentario_CalificacionDatos mensaje = new UComentario_CalificacionDatos();
            DateTime fechaparacalificar;

            if (inforeserva != null)
            {
                inforeserva = new DAOReserva().inforeserva(inforeserva);
                try
                {

                
                fechaparacalificar = inforeserva.Fecha_salida;
                if (DateTime.Now >= fechaparacalificar.AddDays(1))
                {
                    if (inforeserva.Calificacion == null)
                    {

                        if (arrayRadioButton[0].Checked)
                        {
                            inforeserva.Calificacion = 0;
                        }
                        else if (arrayRadioButton[1].Checked)
                        {
                            inforeserva.Calificacion = 1;
                        }
                        else if (arrayRadioButton[2].Checked)
                        {
                            inforeserva.Calificacion = 2;
                        }
                        else if (arrayRadioButton[3].Checked)
                        {
                            inforeserva.Calificacion = 3;
                        }
                        else if (arrayRadioButton[4].Checked)
                        {
                            inforeserva.Calificacion = 4;

                        }
                        else if (arrayRadioButton[5].Checked)
                        {
                            inforeserva.Calificacion = 5;
                        }

                        if (inforeserva.Calificacion != null)
                        {
                            new DAOReserva().actualizarcalificacion(inforeserva);
                            mensaje.Mensaje = "Calificacion realizada con exito";
                            new DAOReserva().cantidaddereservasconcalificacion(inforeserva);
                            var promediocalificacion = new DAOReserva().cantidaddereservasconcalificacion(inforeserva);
                            UHotel hotel = new UHotel();
                            hotel.Idhotel = int.Parse((inforeserva.Idhotel).ToString());
                            hotel.Promediocalificacion = promediocalificacion;
                            new DAOhotel().actualizarcalificacion(hotel);
                        }
                        else
                        {
                            mensaje.Mensaje = "Seleccione una opcion a calificar";
                        }

                    }
                    else if (inforeserva.Calificacion != null)
                    {
                        mensaje.Mensaje = "Este servicio ha sido calificado antes";
                    }
                }
                else
                {
                    mensaje.Mensaje = "No es posible realizar aun esta calificación";
                }
                }
                catch
                {
                    mensaje.Mensaje = "No es posible realizar aun esta calificación ";
                }

            }
            else if (inforeserva == null)
            {
                mensaje.Mensaje = "Todas sus reservas han sido calificadas";
            }

            return mensaje;

        }
    }
}
