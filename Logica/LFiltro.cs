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

        public UFiltro filtro_general(string preciomin, string preciomax, string maxpersonas, string DateAntesDe, string DateDespuesDe, string Calificacion, string Zona, string Municipio, string Tipo)
        {
            UFiltro busqueda = new UFiltro();
            busqueda = this.verificar_vacios(preciomin, preciomax, maxpersonas, DateAntesDe, DateDespuesDe, Calificacion, Zona, Municipio, Tipo);

            return busqueda;
        }

        public UFiltro verificar_vacios(string preciomin, string preciomax, string maxpersonas, string DateAntesDe, string DateDespuesDe, string Calificacion, string Zona, string Municipio, string Tipo)
        {
            UFiltro filtro = new UFiltro();

            if (preciomin == "")
            {
                filtro.preciomin = null;
            }
            else if(preciomin != "")
            {
                filtro.preciomin = int.Parse(preciomin);
            }
            if (preciomax == "")
            {
                filtro.preciomax = null;
            }else if (preciomax != "")
            {
                filtro.preciomax = int.Parse(preciomax);
            }
            if (maxpersonas == "")
            {
                filtro.numpersonas = null;
            }else if (maxpersonas != "")
            {
                filtro.numpersonas = int.Parse(maxpersonas);
            }
            if (DateAntesDe == "")
            {
                filtro.fecha_antesde = null;
            }else if (DateAntesDe != "")
            {
                if (DateTime.Parse(DateAntesDe) < DateTime.Parse(DateDespuesDe))
                {
                    filtro.mensaje = "La fecha Antes de, debe ser mayor de   " + DateTime.Parse(DateDespuesDe).ToString("dd-MM-yyyy");
                }
                else
                {
                    filtro.mensaje = " ";
                    filtro.fecha_antesde = DateTime.Parse(DateAntesDe);
                }
            }
            if (DateDespuesDe == "")
            {
                filtro.fecha_despuesde = null;
            }else if (DateDespuesDe != "")
            {
                if (DateTime.Parse(DateDespuesDe) < DateTime.Now)
                {
                    filtro.mensaje = "La fecha especificada debe ser después de     " + DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    filtro.mensaje = " ";
                    filtro.fecha_despuesde = DateTime.Parse(DateDespuesDe);
                }
            }

            if (Zona.Equals("--Seleccione--"))
            {
                filtro.zona = null;
            }else if (Zona != "--Seleccione--")
            {
                filtro.zona = Zona;
            }
            if (Municipio.Equals("--Seleccione--"))
            {
                filtro.municipio = null;
            }else if (Municipio != "--Seleccione--")
            {
                filtro.municipio = Municipio;
            }
            if (Calificacion.Equals("--Seleccionar--"))
            {
                filtro.calificacion = null;
            }else if (Calificacion != "--Seleccione--")
            {
                filtro.calificacion = Calificacion;
            }
            if (Tipo.Equals("--Seleccionar--"))
            {
                filtro.tipo = null;
            }else if (Tipo != "--Seleccione--")
            {
                filtro.tipo = Tipo;
            }

            return filtro;
        }

        
    }
}
