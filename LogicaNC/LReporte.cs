using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using DataNC;

namespace LogicaNC
{
    public class LReporte
    {
        private readonly Mapeo _context;

        public LReporte(Mapeo context)
        {
            _context = context;
        }

        public List<UAcceso> registrosAcceso(int idusuarion)
        {
            List<UAcceso> listaMisHoteles = new DAOSeguridad(_context).RegistrosAcceso(idusuarion);
            return listaMisHoteles;
        }

        public List<UHotel> listaMisHoteles(URegistro session)
        {
            List<UHotel> listaMisHoteles = new DAOhotel(_context).obtenerhoteles(session);
            return listaMisHoteles;
        }

        public List<UReserva> listaMisReservas(URegistro usuario)
        {
            List<UReserva> listaMisHoteles = new DAOReserva(_context).mostrarmisreservas(usuario);
            return listaMisHoteles;
        }
    }
}
