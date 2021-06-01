using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Utilitarios;

namespace DataNC
{
    public class DAOhotel
    {
        private readonly Mapeo _context;

        public DAOhotel(Mapeo context)
        {
            _context = context;
        }

        public List<UHotelMunicipio> municipio()
        {

            return _context.hotelmunicipio.ToList();
        }
        public List<UHotelZona> zona()
        {
            return _context.hotelzona.ToList();
        }
        //insert registro
        public void insertHotel(UHotel hotelE)
        {
            _context.hotel.Add(hotelE);
            _context.SaveChanges();
            
        }

        //lista de hoteles destacados
        public List<UHotel> hotelesdestacados()
        {

                List<UHotel> hotelesdestacados = (from h in _context.hotel
                                                 orderby (h.Promediocalificacion != null ? h.Promediocalificacion : -1) descending

                                                 //where h.Numhabitacion > 4
                                                 select new
                                                 {
                                                     h
                                                 }).Take(6).ToList().Select(m => new UHotel
                                                 {
                                                     Idhotel = m.h.Idhotel,
                                                     Nombre = m.h.Nombre,
                                                     Imagen = m.h.Imagen,
                                                     Promediocalificacion = m.h.Promediocalificacion,
                                                 }).ToList();
                return hotelesdestacados;
            
        }

        //lista de hoteles por usuario 
        //(hoteles que se muestran en index)
        public List<UHotel> hotelesregistrados(UFiltro consulta)
        {
            int num = 0;

            if (consulta != null && consulta.numpersonas != null)
            {
                num = int.Parse((consulta.numpersonas).ToString());
            }

            if (consulta != null && (consulta.fecha_antesde != null && consulta.fecha_despuesde != null))
            {


                    List<UHotel> elementos = (from h in _context.hotel
                                             join hm in _context.hotelmunicipio on h.Idmunicipio equals hm.Idmunicipio
                                             join hz in _context.hotelzona on h.Idzona equals hz.Idzona
                                             //join rh in db.reserva on h.Idhotel equals rh.Idhotel

                                             select new
                                             {
                                                 h,
                                                 hm,
                                                 hz,
                                                 //rh,
                                             }).OrderBy(h => h.h.Nombre).ToList().Select(m => new UHotel
                                             {

                                                 NumHabitDisponibles = ((_context.habitacion.Where(x => x.Idhotel == m.h.Idhotel).Count()) - (_context.reserva.Where(x => (x.Idhotel == m.h.Idhotel) &&
                                                                        ((consulta.fecha_despuesde >= x.Fecha_llegada && consulta.fecha_despuesde <= x.Fecha_salida) || (consulta.fecha_antesde >= x.Fecha_salida && consulta.fecha_antesde <= x.Fecha_salida))).Count()) < 0 ? 0
                                                                        : (_context.habitacion.Where(x => x.Idhotel == m.h.Idhotel).Count()) - (_context.reserva.Where(x => (x.Idhotel == m.h.Idhotel) &&
                                                                        ((consulta.fecha_despuesde >= x.Fecha_llegada && consulta.fecha_despuesde <= x.Fecha_salida) || (consulta.fecha_antesde >= x.Fecha_salida && consulta.fecha_antesde <= x.Fecha_salida))).Count())),

                                                 Promediocalificacion = m.h.Promediocalificacion,
                                                 Idhotel = m.h.Idhotel,
                                                 Nombre = m.h.Nombre,
                                                 Precionoche = m.h.Precionoche,
                                                 PrecioNocheDoble = m.h.PrecioNocheDoble,
                                                 PrecioNochePremium = m.h.PrecioNochePremium,
                                                 Imagen = m.h.Imagen,
                                                 Municipio = m.hm.Nombre,
                                                 Zona = m.hz.Nombre,
                                                 //Fecha_antesde = m.rh.Fecha_salida,
                                                 //Fecha_despuesde = m.rh.Fecha_llegada,

                                             }).Where(x => x.NumHabitDisponibles > 0).ToList();
                    return elementos;
                


            }
            else
            {

                    List<UHotel> elementos = (from h in _context.hotel
                                             join hm in _context.hotelmunicipio on h.Idmunicipio equals hm.Idmunicipio
                                             join hz in _context.hotelzona on h.Idzona equals hz.Idzona

                                             //join rh in db.reserva on h.Idhotel equals rh.Idhotel
                                             //join hhab in db.habitacion on h.Idhotel equals hhab.Idhotel

                                             select new
                                             {
                                                 h,
                                                 hm,
                                                 hz,

                                             }).OrderBy(h => h.h.Nombre).ToList().Select(m => new UHotel
                                             {

                                                 NumHabitDisponibles = _context.habitacion.Where(x => x.Idhotel == m.h.Idhotel).Count(),
                                                 Promediocalificacion = m.h.Promediocalificacion,
                                                 Idhotel = m.h.Idhotel,
                                                 Nombre = m.h.Nombre,
                                                 Precionoche = m.h.Precionoche,
                                                 PrecioNocheDoble = m.h.PrecioNocheDoble,
                                                 PrecioNochePremium = m.h.PrecioNochePremium,
                                                 Imagen = m.h.Imagen,
                                                 Municipio = m.hm.Nombre,
                                                 Zona = m.hz.Nombre,
                                                 NumMaxPersonas = _context.habitacion.Where(x => x.Numpersonas == num && x.Idhotel == m.h.Idhotel).Count() == 0 ? 0 : 1,

                                             }).Where(x => num > 0 ? x.NumMaxPersonas > 0 : x.NumMaxPersonas == 0).ToList();
                    if (consulta == null)
                    {
                        return elementos;
                    }

                    if (consulta.calificacion != null)
                    {
                        if (consulta.calificacion.Equals("--Seleccionar--"))
                        {
                            elementos = elementos.Where(x => (x.Promediocalificacion <= 5) || (x.Promediocalificacion == null)).ToList();//&& (x.Promediocalificacion == null)
                        }
                        else
                        {
                            elementos = elementos.Where(x => x.Promediocalificacion == (int.Parse(consulta.calificacion))).ToList();
                        }

                    }

                    if (consulta.nombrehotel != null)
                    {
                        elementos = elementos.Where(x => x.Nombre.ToUpper().Equals(consulta.nombrehotel.ToUpper())).ToList();
                    }
                    if (consulta.preciomin != null && consulta.preciomax != null)
                    {
                        if (consulta.tipo != null)
                        {
                            if (consulta.tipo.Equals("Basica"))
                            {
                                elementos = elementos.Where(x => (x.Precionoche <= consulta.preciomax && x.Precionoche >= consulta.preciomin)).ToList();
                            }
                            if (consulta.tipo.Equals("Doble"))
                            {
                                elementos = elementos.Where(x => (x.PrecioNocheDoble <= consulta.preciomax && x.PrecioNocheDoble >= consulta.preciomin)).ToList();
                            }
                            if (consulta.tipo.Equals("Premium"))
                            {
                                elementos = elementos.Where(x => (x.PrecioNochePremium <= consulta.preciomax && x.PrecioNochePremium >= consulta.preciomin)).ToList();
                            }

                        }
                        else if (consulta.tipo == null)
                        {
                            elementos = elementos.Where(x => x.Precionoche != null && x.Precionoche != null).ToList();
                        }
                    }
                    else
                    {
                        if (consulta.preciomax != null && consulta.preciomin == null)
                        {
                            elementos = elementos.Where(x => x.Precionoche <= consulta.preciomax).ToList();
                        }
                        if (consulta.preciomin != null && consulta.preciomax == null)
                        {
                            elementos = elementos.Where(x => x.Precionoche >= consulta.preciomin).ToList();
                        }
                    }
                    if (consulta.zona != null && consulta.municipio != null)
                    {
                        elementos = elementos.Where(x => (x.Municipio.Equals(consulta.municipio)) && (x.Zona.Equals(consulta.zona))).ToList();
                    }
                    else
                    {
                        if (consulta.municipio != null && consulta.zona == null)
                        {
                            elementos = elementos.Where(x => x.Municipio.Equals(consulta.municipio)).ToList();
                        }
                        else
                        if (consulta.zona != null && consulta.municipio == null)
                        {
                            elementos = elementos.Where(x => x.Zona.Equals(consulta.zona)).ToList();
                        }
                    }

                    return elementos;
                
            }
        }
        //select info hotel panel hotel
        public async Task<UHotel> infohotel(UHotel hotelE)
        {
            return await _context.hotel.Where(x => x.Idhotel == hotelE.Idhotel).FirstOrDefaultAsync();
        }
        //select zona
        public UHotelZona zona(UHotel hotelE)
        {
            return _context.hotelzona.Where(x => x.Idzona.Equals(hotelE.Idzona)).FirstOrDefault();
        }
        //select municipio
        public UHotelMunicipio municipio(UHotel hotelE)
        {
            return _context.hotelmunicipio.Where(x => x.Idmunicipio.Equals(hotelE.Idmunicipio)).FirstOrDefault();
        }

        //obtener mis hoteles
        //Select 
        public List<UHotel> obtenerhoteles(URegistro session)
        {
            return _context.hotel.Where(x => x.Idusuario.Equals(session.Id)).OrderBy(x => x.Idhotel).ToList<UHotel>();
        }

        //eliminar hotel
        public void deleteHotel(UHotel id)
        {
            UHotel mihotel = _context.hotel.Where(x => x.Idhotel == id.Idhotel).First();
            List<UHabitacion> mihabitacion = _context.habitacion.Where(x => x.Idhotel == id.Idhotel).ToList();
            _context.habitacion.RemoveRange(mihabitacion);
            _context.hotel.Remove(mihotel);
            _context.SaveChanges();
        }

        //Agregar habitación en el hotel
        public void actualizarhabiatacion(UHabitacion idE)
        {
            UHotel datoanterior = _context.hotel.Where(x => x.Idhotel == idE.Idhotel).First();
            var idanterior = datoanterior.Numhabitacion;
            datoanterior.Numhabitacion = idanterior + 1;
            var entry = _context.Entry(datoanterior);
            entry.State = EntityState.Modified;
            _context.SaveChanges(); 
        }

        //actualizar calificacion
        public void actualizarcalificacion(UHotel hotelE)
        {
            UHotel datoanterior = _context.hotel.Where(x => x.Idhotel == hotelE.Idhotel).First();
            datoanterior.Promediocalificacion = hotelE.Promediocalificacion;
            var entry = _context.Entry(datoanterior);
            entry.State = EntityState.Modified;
            _context.SaveChanges();   
        }
    }
}
