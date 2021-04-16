using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Utilitarios;
using Data;
using System.Web.UI;
using Utilitarios.Entrada;

namespace Logica
{
    public class LMembresias
    {
        public UMembresias pageLoad(URegistro session)
        {
            UMembresias datos = new UMembresias();
            if (session.Idestado == 1) //1 Es con menbresia, 0 sin membresia
            {
                datos.NumeroTarjeta = false;
                datos.CodigoSeguridad = false;
                datos.NombrePropietario = false;
                datos.DireccionPropietario = false;
                datos.CedulaPropietario = false;
                datos.Usuario = false;
                datos.Contrasena = false;
                datos.Comprar = false;

                datos.Actualizar_Comprar = "Actualizar membresía";
                datos.Mensajecompra = "El costo de actualización es de: ";
                datos.Costo = "50.000 ";
                URegistro usuario = new URegistro();
                usuario.Id = session.Id;
                UMembresia fechavencimiento = new DAOSeguridad().fechavencimiento(usuario);
                datos.Vencimiento = (fechavencimiento.Fecha_vencimiento).ToString();
            }
            else
            {
                datos.NumeroTarjeta = true;
                datos.CodigoSeguridad = true;
                datos.NombrePropietario = true;
                datos.DireccionPropietario = true;
                datos.CedulaPropietario = true;
                datos.Usuario = true;
                datos.Contrasena = true;
                datos.Comprar = true;

                datos.Actualizar_Comprar = "Comprar Membresia";
                datos.Mensajecompra = "El costo de compra es de: ";
                datos.Costo = "150.000 ";
                datos.Vencimiento = (DateTime.Now).ToString();
            }

            return datos;
        }

        public UMembresias comprar(UMembresia datoscompra, URegistro usuario, URegistro session)
        {
            UMembresias datos = new UMembresias();
            datoscompra.Cedulapropietario = encriptar(datoscompra.Cedulapropietario);
            datoscompra.Codigoseguridad = encriptar(datoscompra.Codigoseguridad);
            datoscompra.Numerotarjeta = encriptar(datoscompra.Numerotarjeta);

            if ((session.Usuario).Equals(usuario.Usuario))
            {
                var verificacion = new DAOLogin().verificarLogincompra(usuario);
                if (verificacion == null)
                {
                    datos.Error = "Verifique que su usuario y su contraseña sean los correctos";
                    datos.Url = "#";
                }
                else
                {
                    datoscompra.Idusuario = session.Id;
                    try
                    {

                        new DAOSeguridad().insertarCompra(datoscompra);
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Compra realizada con exito.');</script>");
                        datos.Error = "Compra realizada con exito";
                        usuario.Idestado = 1;
                        datos.Sesion = "usuario";
                        datos.Url = "Login.aspx";
                        new DAOSeguridad().actualizarmembresia(usuario);
                        new Mail().mailconfirmarcompra(usuario);
                    }
                    catch
                    {
                        datos.Error = "Error al realizar la compra, verifique sus datos";
                        datos.Url = "#";
                    }
                }
            }
            else
            {
                datos.Error = "Verifique que su usuario sea el correcto";
                datos.Url = "#";
            }

            return datos;
        }

        //encripta numero tarjeta
        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
            {
                output.Append(hashedBytes[i].ToString("x2").ToLower());
            }
            return output.ToString();
        }
    }
}
