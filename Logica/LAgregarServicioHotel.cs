using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Data;
using Utilitarios;

namespace Logica
{
    public class LAgregarServicioHotel
    {

        public UHotel insertHotel(FileUpload imagenPrincipal, FileUpload imagenSecundaria, FileUpload imagenSecundaria2,
            string direccion1, string direccion2, string direccion3, UHotel datosHotel)
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
            //hotel.Imagen =
            hotel.Usuarioencargado = datosHotel.Usuarioencargado;
            hotel.Idzona = datosHotel.Idzona;
            hotel.Condicionesbioseguridad = datosHotel.Condicionesbioseguridad;
            hotel.Direccion = datosHotel.Direccion;

            if (imagenPrincipal.HasFile)
            {
                string ext = System.IO.Path.GetExtension(imagenPrincipal.FileName);//obtiene la extencion del archivo
                ext = ext.ToLower();
                int tam = imagenPrincipal.PostedFile.ContentLength;
                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg") && (tam < 1048576))
                {
                    imagenPrincipal.SaveAs(direccion1);
                    hotel.Mensaje = "*Imagen Aceptada";
                    hotel.Imagen = direccion1;
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
            if (imagenSecundaria.HasFile) //secundaria1
            {
                string ext = System.IO.Path.GetExtension(imagenSecundaria.FileName);//obtiene la extencion del archivo
                ext = ext.ToLower();
                int tam = imagenSecundaria.PostedFile.ContentLength;
                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg") && (tam < 1048576))
                {
                    imagenSecundaria.SaveAs(direccion2);
                    hotel.Mensaje = "*Imagen Aceptada";
                    hotel.Imagen_secundaria = direccion2;
                }
                else
                {
                    hotel.Mensaje = "*Imagen no esta en formato correcto o es muy pesada.";
                }
            }
            else
            {
                hotel.Imagen_secundaria = null;
            }

            if (imagenSecundaria2.HasFile) //secundaria2
            {
                string ext = System.IO.Path.GetExtension(imagenSecundaria2.FileName);//obtiene la extencion del archivo
                ext = ext.ToLower();
                int tam = imagenSecundaria2.PostedFile.ContentLength;
                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg") && (tam < 1048576))
                {
                    imagenSecundaria2.SaveAs(direccion3);
                    hotel.Mensaje = "*Imagen Aceptada";
                    hotel.Imagen_secundaria2 = direccion3;
                }
                else
                {
                    hotel.Mensaje = "*Imagen no esta en formato correcto o es muy pesada.";
                }
            }
            else
            {
                hotel.Imagen_secundaria2 = null;
            }
            new DAOhotel().insertHotel(hotel);

            return hotel;
        }   
    }
}
