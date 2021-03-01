using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;

namespace Data
{
    public class DAOComentarios
    {
        public List<UComentarios> obtenerComentarios(UHotel id)
        {
            using (var db = new Mapeo())
            {

                List<UComentarios> comentariosHotel = (from ch in db.comentario
                                                      join us in db.usuario on ch.Id_usuario equals us.Id

                                                      select new
                                                      {
                                                          ch,
                                                          us
                                                      }).ToList().Select(m => new UComentarios
                                                      {
                                                          Nombre_usuario = m.us.Nombre,
                                                          Comentario = m.ch.Comentario,
                                                          Id_usuario = m.ch.Id_usuario,
                                                          Id_hotel = m.ch.Id_hotel,
                                                      }).ToList<UComentarios>();

                if (comentariosHotel != null && id.Idhotel != null)
                {
                    comentariosHotel = comentariosHotel.Where(x => x.Id_hotel.Equals(id.Idhotel)).ToList();
                }

                return comentariosHotel;
            }
        }



        public void insertComentario(UComentarios coment)
        {
            using (var db = new Mapeo())
            {
                db.comentario.Add(coment);
                db.SaveChanges();
            }
        }


        public Boolean consulta(UComentarios user)
        {
            Double tdia = 3;
            List<UComentarios> comentario = new Mapeo().comentario.Where(x => (x.Id_hotel == user.Id_hotel) && (user.Id_usuario == x.Id_usuario)).ToList();
            int cantidad = new Mapeo().reserva.Where(x => x.Idhotel == user.Id_hotel &&
           ((user.Id_usuario == x.Idusuario && user.Fecha_comentario >= x.Fecha_salida &&
           user.Fecha_comentario <= x.Limite_comentario))).Count();
            if (cantidad > 0)
            {
                //confirma = true;
                return true;
            }
            else
            {
                //confirma = false;
                return false;
            }

        }


        //verificar si ya existe un comentario
        /*public int verificarcomentario(UComentarios infocomentario)
        {
        int cantcomentarios;
        return cantcomentarios = new Mapeo().comentario.Where(x => (x.Id_coment == infocomentario.Id_coment) && ()).Count();
        }*/

        /*
        public Boolean consult(UComentarios user)
        {
            using (var db = new Mapeo())
            {
                List<UComentarios> comentar = (from ch in db.comentario
                                              join re in db.reserva on ch.Id_usuario equals re.Idusuario

                                              select new
                                              {
                                                  ch,
                                                  re
                                              }).ToList().Select(m => new UReserva
                                              {

                                                  Idusuario = m.ch.Id_usuario,
                                                  Idhotel = m.ch.Id_hotel,
                                                  Fecha_comentario = user.Fecha_comentario,
                                                  Fecha_salida = m.re.Fecha_salida.AddDays(3),
                                              }).Where(x => x.Idhotel == user.Id_hotel &&
                                   ((user.Id_usuario == x.Idusuario && user.Fecha_comentario >= x.Fecha_salida &&
                                   user.Fecha_comentario))).ToList<UComentarios>();

                if (comentar != null && user.Idhotel != null)
                {
                    comentariosHotel = comentariosHotel.Where(x => x.Id_hotel.Equals(id.Idhotel)).ToList();
                }

                return comentariosHotel;
            }

            return false;
        }*/
    }
}
