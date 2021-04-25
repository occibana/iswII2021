using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LPanelHotel
    {
        public async Task<UHotel> informacion_del_hotel(UHotel hotel)
        {
            
            hotel = await new DAOhotel().infohotel(hotel);
            hotel.Zona = (new DAOhotel().zona(hotel)).Nombre;
            hotel.Municipio = (new DAOhotel().municipio(hotel)).Nombre;
            return hotel;
        }

        public UHabitacion informacion_de_habitacion(UHabitacion habitacioninfo)
        {
            habitacioninfo = new DAOHabitacion().infoHabitacion(habitacioninfo.Id);
           
            return habitacioninfo;
        }
    }
}
