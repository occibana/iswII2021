using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Data;

namespace Logica
{
    public class LReporte
    {
        public List<UAcceso> registrosAcceso(int idusuarion)
        {
            List<UAcceso> listaMisHoteles = new DAOSeguridad().RegistrosAcceso(idusuarion);
            return listaMisHoteles;
        }

        public List<UHotel> listaMisHoteles(string usuario)
        {
            List<UHotel> listaMisHoteles = new DAOhotel().obtenerhoteles(usuario);
            return listaMisHoteles;
        }

        public List<UReserva> listaMisHoteles(URegistro usuario)
        {
            List<UReserva> listaMisHoteles = new DAOReserva().mostrarmisreservas(usuario);
            return listaMisHoteles;
        }
    }
}
