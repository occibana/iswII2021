using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Data;
using Utilitarios;

namespace Logica
{
    public class LAgregarServicioHotel
    {

        public UHotel insertHotel(byte[] imagenPrincipal, byte[] imagenSecundaria, byte[] imagenSecundaria2,
            string direccion1, string direccion2, string direccion3, string dir1, string dir2, string dir3, UHotel datosHotel)
        {
            UHotel hotel = new UHotel();
            hotel.Nombre = datosHotel.Nombre;
            hotel.Municipio = datosHotel.Municipio;
            hotel.Idmunicipio = datosHotel.Idmunicipio;
            hotel.Numhabitacion = datosHotel.Numhabitacion;
            hotel.Precionoche = datosHotel.Precionoche;
            hotel.PrecioNocheDoble = datosHotel.PrecioNocheDoble;
            hotel.PrecioNochePremium = datosHotel.PrecioNochePremium;
            hotel.Descripcion = datosHotel.Descripcion;
            hotel.Condicion = datosHotel.Condicion;
            hotel.Checkin = datosHotel.Checkin;
            hotel.Checkout = datosHotel.Checkout;
            hotel.Usuarioencargado = datosHotel.Usuarioencargado;
            hotel.Idusuario = datosHotel.Idusuario;
            hotel.Idzona = datosHotel.Idzona;
            hotel.Condicionesbioseguridad = datosHotel.Condicionesbioseguridad;
            hotel.Direccion = datosHotel.Direccion;

            if (imagenPrincipal != null)
            {
                string ext = dir1.ToLower();//obtiene la extencion del archivo

                // int tam = imagenPrincipal.PostedFile.ContentLength;
                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg"))  //&& (tam < 1048576)
                {
                    string direc1 = HttpContext.Current.Server.MapPath(direccion1);
                    FileStream fileStream = new FileStream(direc1, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(imagenPrincipal, 0, imagenPrincipal.Length);//mapea y guarda el archivo en la direccion
                    fileStream.Close();
                    hotel.Mensaje = "*Imagen aceptada";
                    hotel.Imagen = direccion1;

                    if (imagenSecundaria != null) //secundaria1
                    {

                        string exts = dir2.ToLower();
                        //int tams = imagenSecundaria.PostedFile.ContentLength;
                        if ((exts == ".jpg" || exts == ".png" || exts == ".jpeg")) //&& (tams < 1048576)
                        {
                            string direc2 = HttpContext.Current.Server.MapPath(direccion2);
                            fileStream = new FileStream(direc2, FileMode.Create, FileAccess.ReadWrite);
                            fileStream.Write(imagenPrincipal, 0, imagenPrincipal.Length);
                            fileStream.Close();
                            //imagenSecundaria.SaveAs(dir2);
                            hotel.Mensaje2 = "*Imagen Aceptada";
                            hotel.Imagen_secundaria = direccion2;
                        }
                        else
                        {
                            hotel.Mensaje2 = "*Imagen no esta en formato correcto o es muy pesada.";
                        }
                    }
                    else
                    {
                        hotel.Mensaje2 = "";
                        hotel.Imagen_secundaria = null;
                    }

                    if (imagenSecundaria2 != null) //secundaria2
                    {

                        string extt = dir3.ToLower();
                        // int tamt = imagenSecundaria2.PostedFile.ContentLength;
                        if ((extt == ".jpg" || extt == ".png" || extt == ".jpeg")) // && (tamt < 1048576)
                        {
                            string direc3 = HttpContext.Current.Server.MapPath(direccion3);
                            fileStream = new FileStream(direc3, FileMode.Create, FileAccess.ReadWrite);
                            fileStream.Write(imagenPrincipal, 0, imagenPrincipal.Length);
                            fileStream.Close();

                            hotel.Mensaje3 = "*Imagen Aceptada";
                            hotel.Imagen_secundaria2 = direccion3;
                        }
                        else
                        {
                            hotel.Mensaje3 = "*Imagen no esta en formato correcto o es muy pesada.";
                        }
                    }
                    else
                    {
                        hotel.Mensaje3 = "";
                        hotel.Imagen_secundaria2 = null;
                    }
                    new DAOhotel().insertHotel(hotel);

                }
                else
                {
                    hotel.Mensaje = "*Imagen no esta en formato correcto o es muy pesada.";
                }
            }
            else
            {
                hotel.Mensaje = "*Seleccione una imagen";
            }


            return hotel;
        }
    }
}
