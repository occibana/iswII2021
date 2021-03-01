using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;

namespace Logica
{
    public class LFiltro
    {
        public void filtro_general_inicial()
        {
            UFiltro consulta = new UFiltro();
            consulta.nombrehotel = null;
            new DAOhotel().hotelesregistrados(consulta);
        }

        public string filtro_general_nombre(UFiltro busqueda)
        {
            if (busqueda.nombrehotel == null || busqueda.nombrehotel == String.Empty)
            {
                return null;
                //busqueda.nombrehotel = null;
            }
            else
            {
                
                return (busqueda.nombrehotel).ToUpper();
                //busqueda.nombrehotel = (TB_Busquedageneral.Text).ToUpper();
            }
        }

        public Tuple<UFiltro,string> filtro_general(UFiltro busqueda)
        {
            string precioMin = busqueda.preciomin.ToString();
            string precioMax = busqueda.preciomin.ToString();
            string numPersonas = busqueda.numpersonas.ToString();
            string fechaAntesDe = busqueda.fecha_antesde.ToString();
            string fechaDespuesDe = busqueda.fecha_despuesde.ToString();
            string msj = null;

            if (precioMin == String.Empty)
            {
                busqueda.preciomin = null;
            }
            if (precioMax == String.Empty)
            {
                busqueda.preciomax = null;
            }
            if (precioMin != String.Empty)
            {
                busqueda.preciomin = int.Parse(precioMin);
            }
            if (precioMax != String.Empty)
            {
                busqueda.preciomax = int.Parse(precioMax);
            }
            if (numPersonas == String.Empty)
            {
                busqueda.numpersonas = null;
            }
            if (numPersonas != String.Empty)
            {
                busqueda.numpersonas = int.Parse(numPersonas);
            }
            if (fechaAntesDe != String.Empty)
            {

                if (DateTime.Parse(fechaAntesDe) < DateTime.Parse(fechaDespuesDe))
                {
                    msj = "La fecha Antes de, debe ser mayor de   " + DateTime.Parse(fechaDespuesDe).ToString("dd-MM-yyyy");
                }
                else
                {
                    msj = " ";
                    busqueda.fecha_antesde = DateTime.Parse(fechaAntesDe);
                }

            }
            if (fechaDespuesDe != String.Empty)
            {
                if (DateTime.Parse(fechaDespuesDe) < DateTime.Now)
                {
                    msj = "La fecha especificada debe ser después de     " + DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    msj = " ";
                    busqueda.fecha_despuesde = DateTime.Parse(fechaDespuesDe);
                }
            }
 
            if (busqueda.zona.Equals("--Seleccione--"))
            {
                busqueda.zona = null;
            }
            if (busqueda.municipio.Equals("--Seleccione--"))
            {
                busqueda.municipio = null;
            }
            if (busqueda.calificacion.Equals("--Seleccionar--"))
            {
                busqueda.calificacion = null;
            }
            if (busqueda.tipo.Equals("--Seleccionar--"))
            {
                busqueda.tipo = null;
            }

            return Tuple.Create(busqueda,msj);
            //return busqueda;
        }

        
    }
}
