using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilitarios;
using Data;
using System.Web.UI.WebControls;
using System.IO;

namespace Logica
{
    public class LPerfil
    {
        public UPerfil cargardatos(URegistro datosSession)
        {
            UPerfil perfil = new UPerfil();
            perfil.Datos = new URegistro();
            perfil.Datos.Nombre = datosSession.Nombre;
            perfil.Datos.Correo = datosSession.Correo;

            perfil.Datos.Telefono = datosSession.Telefono;
            perfil.Datos.Usuario = datosSession.Usuario;
            perfil.Datos.Fotoperfil = datosSession.Fotoperfil;
            perfil.Datos.Idestado = datosSession.Idestado;
            perfil.Datos.Id = datosSession.Id; 

            if (perfil.Datos.Fotoperfil == null)
            {
                perfil.Datos.Fotoperfil = "~/Vew/img/perfilvacio.jpg";
            }

            if (perfil.Datos.Idestado == 1) //1 Es con menbresia, 0 sin membresia
            {
                var verificar = new DAOSeguridad().verificarvencimientomembresia(perfil.Datos.Id);
                if (verificar != null)
                {
                    perfil.Datos.Id =datosSession.Id;
                    perfil.Datos.Idestado = 0;
                    new DAOSeguridad().actualizarmembresia(perfil.Datos);
                    perfil.URL1 = "Perfil.aspx";

                    perfil.Mensaje = "Sin Membresia";
                    perfil.B_ComprarMembresia1 = true;
                    perfil.B_ActualizarMembresia1 = false;
                    perfil.B_AgregarHotel1 = false;
                    perfil.B_mishoteles1 = false;
                }
                else
                {
                    perfil.Mensaje = "Con Membresia";
                    perfil.B_ComprarMembresia1 = false;
                    perfil.B_ActualizarMembresia1 = true;
                    perfil.B_AgregarHotel1 = true;
                    perfil.B_mishoteles1 = true;
                }
            }
            else
            {
                perfil.Mensaje = "Sin Membresia";

                perfil.B_ComprarMembresia1 = true;
                perfil.B_ActualizarMembresia1 = false;
                perfil.B_AgregarHotel1 = false;
                perfil.B_mishoteles1 = false;

            }
            return perfil;
        }
        public string cerrarsession(URegistro sessionId)
        {
            new DAOSeguridad().cerrarAcceso(sessionId.Id);
            string url = "Login.aspx";
            return url;
        }

        public UPerfil subirFoto(FileUpload foto, URegistro session, string direccion, string imagen, string imagenEliminar)
        {
            UPerfil datos = new UPerfil();
            if (foto.HasFile)
            {
                string ext = System.IO.Path.GetExtension(foto.FileName);//obtiene la extencion del archivo
                ext = ext.ToLower();//minusculas

                int tam = foto.PostedFile.ContentLength;//obtiene tamano archivo
                                                        //string fotoperfil;

                if ((ext == ".jpg" || ext == ".png" || ext == ".jpeg") && (tam < 1048576))//menor a 1MB en bytes
                {

                    try
                    {
                        //imagen
                        foto.PostedFile.SaveAs(imagen);//mapea y guarda el archivo en la direccion
                    }
                    catch
                    {
                        datos.Mensaje = "*Verifique la imagen y cargue nuevamente";
                    }
                    datos.Mensaje = "*Imagen aceptada";
                    //actualiza foto de perfil
                    URegistro nuevodat = new URegistro();
                    nuevodat.Id = session.Id;
                    nuevodat.Fotoperfil = direccion;
                    new DAOLogin().actualizarfoto(nuevodat);

                    
                    if (File.Exists(imagenEliminar))
                    {
                        File.Delete(imagenEliminar);
                    }

                    session.Fotoperfil = nuevodat.Fotoperfil;
                    datos.Fotoperfil = nuevodat.Fotoperfil;
                    datos.Mensaje = "*Imagen cargada con exito";
                }
                else
                {
                    datos.Mensaje = "*Imagen no esta en formato correcto o es muy pesada";
                }

            }
            else
            {
                datos.Mensaje = "*Selecciona una imagen";
            }

            return datos;
        }
    }
}
