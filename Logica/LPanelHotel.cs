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
        public UHotel informacion_del_hotel(UHotel hotel)
        {
            hotel = new DAOhotel().infohotel(hotel);
            return hotel;
        }

        public UHabitacion informacion_de_habitacion(UHabitacion habitacioninfo)
        {
            habitacioninfo = new DAOHabitacion().infoHabitacion(habitacioninfo.Id);
            return habitacioninfo;
        }
    }
}
