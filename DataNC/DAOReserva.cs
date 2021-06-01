using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Utilitarios;

namespace DataNC
{
    public class DAOReserva
    {
        private readonly Mapeo _context;

        public DAOReserva(Mapeo context)
        {
            _context = context;
        }


        //insert registro
        public void insertReserva(UReserva reservaE)
        {           
            _context.reserva.Add(reservaE);
            _context.SaveChanges();
            
        }

        //select habitaciones disponibles segun filtro
        public int habitacionesdisponibles(UReserva disponibilidadE)
        {
            return _context.habitacion.Where(x => (x.Idhotel == disponibilidadE.Idhotel) && (x.Numpersonas == disponibilidadE.Numpersona)).ToList().Count();
        }


        //select fechas disponibles
        public int fechasdisponibles(UReserva disponibilidadE)
        {
            return _context.reserva.Where(x => (x.Idhotel == disponibilidadE.Idhotel) &&
            (disponibilidadE.Fecha_llegada >= x.Fecha_llegada && disponibilidadE.Fecha_llegada <= x.Fecha_salida) ||
            (disponibilidadE.Fecha_salida >= x.Fecha_llegada && disponibilidadE.Fecha_salida <= x.Fecha_salida)
            && (x.Numpersona == disponibilidadE.Numpersona) && (x.Id_habitacion == disponibilidadE.Id_habitacion)).ToList().Count();                                                                                                    //(disponibilidadE.Fecha_salida >= x.Fecha_llegada && disponibilidadE.Fecha_salida <= x.Fecha_salida)                                                                                                                                                                        //)).ToList().Count();
        }


        //select mostrar reservas
        public List<UReserva> mostrarreservas(int disponibilidadE)
        {
            return _context.reserva.Where(x => x.Idhotel == disponibilidadE && x.Fecha_salida >= DateTime.Now).ToList();
        }

        //select mostrar reservas completadas
        public List<UReserva> mostrarreservascompletadas(int disponibilidadE)
        {
            return _context.reserva.Where(x => x.Idhotel == disponibilidadE && x.Fecha_salida <= DateTime.Now).ToList();
        }

        // select mis reservas
        public List<UReserva> mostrarmisreservas(URegistro disponibilidadE)
        {

                return (from h in _context.hotel
                        join r in _context.reserva on h.Idhotel equals r.Idhotel
                        where r.Idusuario == disponibilidadE.Id
                        select new
                        {
                            h,
                            r
                        }).ToList().Select(m => new UReserva
                        {
                            Id = m.r.Id,
                            Idhotel = m.h.Idhotel,
                            Numpersona = m.r.Numpersona,
                            Nombrehotel = m.h.Nombre,
                            Fecha_llegada = m.r.Fecha_llegada,
                            Fecha_salida = m.r.Fecha_salida,
                            Nombre = m.r.Nombre,
                            Apellido = m.r.Apellido,
                            Correo = m.r.Correo,
                            Mediopago = m.r.Mediopago,
                            Calificacion = m.r.Calificacion,
                            PrecioNoche = m.r.PrecioNoche,
                        }).ToList();
            
            //return new Mapeo().reserva.Where(x => x.Idusuario == disponibilidadE.Id).ToList();
        }

        //select reserva
        //select fechas disponibles
        public async Task<UReserva> inforeserva(UReserva reserva)
        {
            return await _context.reserva.Where(x => (x.Id == reserva.Id)).FirstOrDefaultAsync();
        }

        //eliminar reserva 
        public void deleteReserva(UReserva inforeserva)
        {

            UReserva mireserva = _context.reserva.Where(x => x.Id == inforeserva.Id).First();
            _context.reserva.Remove(mireserva);
            _context.SaveChanges();
           
        }

        //actualizar calificacion
        //actualiza foto perfil
        public void actualizarcalificacion(UReserva datosE)
        {
            
            
            UReserva calificacionanterior = _context.reserva.Where(x => x.Id == datosE.Id).First();

            calificacionanterior.Calificacion = datosE.Calificacion;
            var entry = _context.Entry(calificacionanterior);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            
        }


        //actualizar promedio de calificacion
        //contar elementos
        public int cantidaddereservasconcalificacion(UReserva hotel)
        {
            double? reservas = _context.reserva.Where(x => (x.Idhotel == hotel.Idhotel) && (x.Calificacion != null)).Average(x => x.Calificacion);
            double variable = Convert.ToDouble(reservas);
            reservas = Math.Round(variable);
            return int.Parse(reservas.ToString());
        }


        //informacion de la reserva - ultima reserva sin calificar
        public UReserva ultimareserva(UReserva reservaE)
        {
            UReserva ultimareserva = _context.reserva.Where(x => (x.Idhotel == reservaE.Idhotel) && (x.Idusuario == reservaE.Idusuario) && (x.Calificacion == null)).FirstOrDefault();

            return ultimareserva;
        }


        //verificar si la reserva ya se encuentra antes de hacerla efectiva
        public int verificarreserva(UReserva reservaE)
        {
            int reserva = _context.reserva.Where(x => (x.Idhotel == reservaE.Idhotel) && (x.Numpersona == reservaE.Numpersona) && (x.Fecha_llegada == reservaE.Fecha_llegada) && (x.Fecha_salida == reservaE.Fecha_salida) && (x.Id_habitacion == reservaE.Id_habitacion)).Count();
            return reserva;
        }

        //disponibbilidad de personas
        public List<UHabitacion> disponibilidadDePeronas(UHotel datosE)
        {
            List<UHabitacion> limiteDePersonas = (from hhab in _context.habitacion
                                                    where hhab.Idhotel == datosE.Idhotel
                                                    select new
                                                    {
                                                        hhab
                                                    }).ToList().Select(m => new UHabitacion
                                                    {
                                                        Id = m.hhab.Numpersonas,
                                                    }).ToList();

            return limiteDePersonas;
            
        }
    }
}
