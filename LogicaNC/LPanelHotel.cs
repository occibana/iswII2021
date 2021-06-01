using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using DataNC;

namespace LogicaNC
{
    public class LPanelHotel
    {
        private readonly Mapeo _context;

        public LPanelHotel(Mapeo context)
        {
            _context = context;
        }

        public async Task<UHotel> informacion_del_hotel(UHotel hotel)
        {
            
            hotel = await new DAOhotel(_context).infohotel(hotel);
            hotel.Zona = (new DAOhotel(_context).zona(hotel)).Nombre;
            hotel.Municipio = (new DAOhotel(_context).municipio(hotel)).Nombre;
            return hotel;
        }

        public UHabitacion informacion_de_habitacion(UHabitacion habitacioninfo)
        {
            habitacioninfo = new DAOHabitacion(_context).infoHabitacion(habitacioninfo.Id);
           
            return habitacioninfo;
        }
    }
}
