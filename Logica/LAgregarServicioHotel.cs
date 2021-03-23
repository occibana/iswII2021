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
            string direccion1, string direccion2, string direccion3,string dir1,string dir2, string dir3, UHotel datosHotel)
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

            if (imagenPrincipal.HasFile)
            {
                string ext = System.IO.Path.GetExtension(imagenPrincipal.FileName);//obtiene la extencion del archivo
                ext = ext.ToLower();
                int tam = imagenPrincipal.PostedFile.ContentLength;
                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg") && (tam < 1048576))
                {
                    imagenPrincipal.SaveAs(dir1);
                    //hotel.Mensaje = "*Imagen Aceptada";
                    hotel.Mensaje = null;
                    hotel.Imagen = direccion1;

                    if (imagenSecundaria.HasFile) //secundaria1
                    {
                        string exts = System.IO.Path.GetExtension(imagenSecundaria.FileName);//obtiene la extencion del archivo
                        exts = exts.ToLower();
                        int tams = imagenSecundaria.PostedFile.ContentLength;
                        if ((exts == ".jpg" || exts == ".png" || exts == ".jpeg") && (tams < 1048576))
                        {
                            imagenSecundaria.SaveAs(dir2);
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

                    if (imagenSecundaria2.HasFile) //secundaria2
                    {
                        string extt = System.IO.Path.GetExtension(imagenSecundaria2.FileName);//obtiene la extencion del archivo
                        extt = extt.ToLower();
                        int tamt = imagenSecundaria2.PostedFile.ContentLength;
                        if ((extt == ".jpg" || extt == ".png" || extt == ".jpeg") && (tamt < 1048576))
                        {
                            imagenSecundaria2.SaveAs(dir3);
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
