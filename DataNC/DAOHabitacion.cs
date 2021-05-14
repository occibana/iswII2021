using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilitarios;

namespace DataNC
{
    public class DAOHabitacion
    {
        public void insertHabitacion(UHabitacion habitE)
        {
            using (var db = new Mapeo())
            {
                db.habitacion.Add(habitE);
                db.SaveChanges();
            }
        }

        public int cantidadHabitaciones(UHabitacion habitE)
        {
            return new Mapeo().habitacion.Where(x => x.Idhotel == habitE.Idhotel).ToList().Count();
        }


        //habitaciones por hotel
        public List<UHabitacion> habitacionesHotel(UHotel idE, UFiltro consulta)
        {
            try
            {
                if (consulta.numpersonas == null)
                {
                    using (var db = new Mapeo())
                    {
                        List<UHabitacion> habitaciones = (from hhab in db.habitacion

                                                          select new
                                                          {
                                                              hhab
                                                          }).ToList().Select(m => new UHabitacion
                                                          {
                                                              Tipo = m.hhab.Tipo,
                                                              Id = m.hhab.Id,
                                                              Numbanio = m.hhab.Numbanio,
                                                              Numcamas = m.hhab.Numcamas,
                                                              Numpersonas = m.hhab.Numpersonas,
                                                              Idhotel = m.hhab.Idhotel,
                                                              Precio = m.hhab.Precio,

                                                          }).Where(x => x.Idhotel == idE.Idhotel).ToList();
                        return habitaciones;
                    }
                }
                else
                {
                    using (var db = new Mapeo())
                    {
                        List<UHabitacion> habitaciones = (from hhab in db.habitacion

                                                          select new
                                                          {
                                                              hhab
                                                          }).ToList().Select(m => new UHabitacion
                                                          {
                                                              Tipo = m.hhab.Tipo,
                                                              Id = m.hhab.Id,
                                                              Numbanio = m.hhab.Numbanio,
                                                              Numcamas = m.hhab.Numcamas,
                                                              Numpersonas = m.hhab.Numpersonas,
                                                              Idhotel = m.hhab.Idhotel,
                                                              Precio = m.hhab.Precio,

                                                          }).Where(x => (x.Idhotel == idE.Idhotel) && (x.Numpersonas == consulta.numpersonas)).ToList();
                        return habitaciones;
                    }
                }
            }
            catch
            {
                if (consulta == null)
                {
                    using (var db = new Mapeo())
                    {
                        List<UHabitacion> habitaciones = (from hhab in db.habitacion

                                                          select new
                                                          {
                                                              hhab
                                                          }).ToList().Select(m => new UHabitacion
                                                          {
                                                              Tipo = m.hhab.Tipo,
                                                              Id = m.hhab.Id,
                                                              Numbanio = m.hhab.Numbanio,
                                                              Numcamas = m.hhab.Numcamas,
                                                              Numpersonas = m.hhab.Numpersonas,
                                                              Idhotel = m.hhab.Idhotel,
                                                              Precio = m.hhab.Precio,

                                                          }).Where(x => x.Idhotel == idE.Idhotel).ToList();
                        return habitaciones;
                    }
                }
                else
                {
                    using (var db = new Mapeo())
                    {
                        List<UHabitacion> habitaciones = (from hhab in db.habitacion

                                                          select new
                                                          {
                                                              hhab
                                                          }).ToList().Select(m => new UHabitacion
                                                          {
                                                              Tipo = m.hhab.Tipo,
                                                              Id = m.hhab.Id,
                                                              Numbanio = m.hhab.Numbanio,
                                                              Numcamas = m.hhab.Numcamas,
                                                              Numpersonas = m.hhab.Numpersonas,
                                                              Idhotel = m.hhab.Idhotel,
                                                              Precio = m.hhab.Precio,

                                                          }).Where(x => (x.Idhotel == idE.Idhotel) && (x.Numpersonas == consulta.numpersonas)).ToList();
                        return habitaciones;
                    }
                }
            }
        }


        //select info habitacion
        public UHabitacion infoHabitacion(int habitacionE)
        {
            return new Mapeo().habitacion.Where(x =>( x.Id == habitacionE)).FirstOrDefault();
        }


    }
}
