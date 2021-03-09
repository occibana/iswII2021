using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Utilitarios;

namespace Logica
{
    public class LAgregarServicioHotel
    {
        public UHotel insertHotel(UHotel servicioHotel)
        {
            UHotel sHotel = new UHotel();
            sHotel.Nombre = "Prueba";
            new DAOhotel().insertHotel(sHotel);
            return sHotel;
        }
    }
}
