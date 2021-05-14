using System;
using System.Threading.Tasks;

using Utilitarios;
using DataNC;

namespace LogicaNC
{
    public class LActualizarDatos
    {

        private readonly Mapeo _context;

        public LActualizarDatos(Mapeo context)
        {
            _context = context;
        }

        public UActualizarDatos pageLoad(URegistro sessionE)
        {
            UActualizarDatos datos = new UActualizarDatos();

            if (sessionE == null)
            {
                datos.URL1 = "Login.aspx";
            }
            else
            {
                datos.Actusuario = sessionE.Nombre;
                datos.Actnombre = sessionE.Nombre;
                datos.Actapellido = sessionE.Apellido;
                datos.Actcorreo = sessionE.Correo;
                datos.Acttelefono = sessionE.Telefono;
                datos.Actusuario0 = sessionE.Usuario;       
            }
            return datos;
        }

        public async Task<UActualizarDatos> actualizarDatos(URegistro datosRegistro, URegistro datosSession)
        {
            UActualizarDatos datos = new UActualizarDatos();
            datos.Actnombre = datosRegistro.Nombre;
            datos.Actapellido = datosRegistro.Apellido;
            datos.Actusuario = datosRegistro.Usuario;
            datos.Acttelefono = datosRegistro.Telefono;
            datos.Actcorreo = datosRegistro.Correo;
            URegistro actRegistro = await new DAOLogin(_context).verificaruser(datosRegistro);
            if ((actRegistro != null) && (actRegistro.Usuario != String.Empty))//si tb tiene algo
            {
                datos.Mensaje = "Utiliza otro usuario, este ya existe o esta registrado";
            }
            else if ((actRegistro != null) && (actRegistro.Correo != String.Empty))//si tb tiene algo
            {
                datos.Mensaje = "Utiliza otro correo, este ya existe o esta registrado";
            }
            else
            {
                if (datosRegistro.Usuario == String.Empty)
                {
                    datos.Actusuario = datosSession.Usuario;
                }
                if (datosRegistro.Nombre == String.Empty)
                {
                    datos.Actnombre = datosSession.Nombre;
                }
                if (datosRegistro.Apellido == String.Empty)
                {
                    datos.Actapellido = datosSession.Apellido;
                }
                if (datosRegistro.Telefono == String.Empty)
                {
                    datos.Acttelefono = datosSession.Telefono;
                }
                if (datosRegistro.Correo == String.Empty)
                {
                    datos.Actcorreo = datosSession.Correo;
                }
                URegistro reg = new URegistro();
                reg.Nombre = datos.Actnombre;
                reg.Apellido = datos.Actapellido;
                reg.Usuario = datos.Actusuario;
                reg.Telefono = datos.Acttelefono;
                reg.Correo = datos.Actcorreo;
                reg.Id = datosSession.Id;
                new DAOLogin(_context).actualizarperfil(reg);

                datosSession.Nombre = reg.Nombre;
                datosSession.Apellido = reg.Apellido;
                datosSession.Usuario = reg.Usuario;
                datosSession.Telefono = reg.Telefono;
                datosSession.Correo = reg.Correo;
                datos.Mensaje = "Datos actualizados correctamente";
            }
            return datos;
        }

        
    }
}
