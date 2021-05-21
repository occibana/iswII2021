using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataNC;
using LogicaNC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace ApiServiciosNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilNCController : ControllerBase
    {
        private readonly Mapeo _context;

        public PerfilNCController(Mapeo context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        [Route("api/perfilNC/postCargarDatosPerfil")]
        public UPerfil postCargarDatosPerfil(URegistro dato)
        {
            return new LPerfil(_context).cargardatos(dato);
        }

        [HttpPut]
        [Route("api/perfilNC/putActualizarContrasena")]
        public async Task<ActionResult> putActualizarContrasena([FromBody] JObject contrasena)
        {
            URegistro registro = new URegistro();
            //registro.Id = int.Parse(contrasena["Id"].ToString());
            registro.Usuario = contrasena["usuario"].ToString();
            registro.Correo = contrasena["Correo"].ToString();
            string contraAct = contrasena["contrasenaAct"].ToString();
            string contraNueva = contrasena["contrasenaNueva"].ToString();

            UActualizarContrasena actualizarContra = await new LActualizarContrasena(_context).actualizarContrasena(registro, contraAct, contraNueva);
            var datos = actualizarContra;
            return Ok(datos);
        }

        [HttpPost]
        [Route("api/perfilNC/postCerrarSesion")]
        public string postCerrarSesion([FromBody] JObject datoUsuario)
        {
            URegistro datos = new URegistro();
            datos.Usuario = datoUsuario["usuario"].ToString();
            return new LPerfil(_context).cerrarsession(datos);
        }

        [HttpPost]
        [Route("api/perfilNC/postActualizarDatos")]
        public async Task<UActualizarDatos> postActualizarDatos([FromBody] JObject datoUsuario)
        {
            URegistro datosRegistro = new URegistro();
            URegistro datosSession = new URegistro();
            datosRegistro.Nombre = datoUsuario["NombreRegistro"].ToString();
            datosRegistro.Apellido = datoUsuario["ApellidoRegistro"].ToString();
            datosRegistro.Usuario = datoUsuario["UsuarioRegistro"].ToString();
            datosRegistro.Telefono = datoUsuario["TelefonoRegistro"].ToString();
            datosRegistro.Correo = datoUsuario["CorreoRegistro"].ToString();
            datosSession.Nombre = datoUsuario["NombreSession"].ToString();
            datosSession.Apellido = datoUsuario["ApellidoSession"].ToString();
            datosSession.Usuario = datoUsuario["UsuarioSession"].ToString();
            datosSession.Telefono = datoUsuario["TelefonoSession"].ToString();
            datosSession.Correo = datoUsuario["CorreoSession"].ToString();
            datosSession.Correo = datoUsuario["UsuarioIdSession"].ToString();
            return await new LActualizarDatos(_context).actualizarDatos(datosRegistro, datosSession);
        }

        [HttpPost]
        [Route("api/perfilNC/postAgregarhabitacion")]
        public async Task<UHabitacion> postAgregarhabitacion([FromBody] JObject datoUsuario)
        {
            UHabitacion habitacion = new UHabitacion();
            habitacion.Tipo = datoUsuario["TipoHabitacion"].ToString();
            habitacion.Idhotel = int.Parse(datoUsuario["IdHotel"].ToString());
            int idTipo = int.Parse(datoUsuario["usuario"].ToString());
            return await new LHabitacion(_context).agregarHabitacion(idTipo, habitacion);
        }

        [HttpPost]
        [Route("api/perfilNC/postComprarMembresias")]
        public async Task<UMembresias> postComprarMembresias([FromBody] JObject dato)
        {
            UMembresia datoscompra = new UMembresia();
            URegistro usuario = new URegistro();
            URegistro usuarioSession = new URegistro();

            datoscompra.Cedulapropietario = dato["Cedula"].ToString();
            datoscompra.Codigoseguridad = dato["CodigoDeSeguridad"].ToString();
            datoscompra.Direccionpropietario = dato["DireccionPropietario"].ToString();
            datoscompra.Nombrepropietario = dato["NombreDelPropietario"].ToString();
            datoscompra.Numerotarjeta = dato["NumeroTarjeta"].ToString();
            datoscompra.Fecha_compra = DateTime.Now;
            datoscompra.Fecha_vencimiento = DateTime.Now.AddYears(1);
            usuario.Usuario = dato["Usuario"].ToString();
            usuario.Contrasena = dato["Contrasena"].ToString();
            usuario.Id = int.Parse(dato["Id"].ToString());
            usuario.Correo = dato["Correo"].ToString();

            usuarioSession.Usuario = dato["UsuarioSession"].ToString();
            usuarioSession.Id = int.Parse(dato["IdUsuarioSession"].ToString());

            return await new LMembresias(_context).comprar(datoscompra, usuario, usuarioSession);
        }

        [HttpPost]
        [Route("api/perfilNC/postSubirFoto")]
        public UPerfil postSubirFoto([FromBody] JObject foto)
        {
            UPerfil perfil = new UPerfil();
            URegistro usuario = new URegistro();

            JToken imagenPerfil = foto["imagen"];
            List<byte> listadebytes = new List<byte>();
            foreach (JToken bite in imagenPerfil)
            {
                listadebytes.Add(byte.Parse(bite.ToString()));
            }
            byte[] fotoPerfil = listadebytes.ToArray();

            usuario.Usuario = foto["usuario"].ToString();
            perfil = new LPerfil(_context).cargardatos(usuario);
            usuario.Id = perfil.Datos.Id;
            string nombreArchivo = usuario.Usuario + "Perfil";

            //string imagen = HttpContext.Current.Server.MapPath("~\\Vew\\imgusuarios\\") + nombreArchivo;
            string ext = foto["extension"].ToString();
            string direccion = "~\\Vew\\imgusuarios\\" + nombreArchivo + ext;
            string imagenEliminar = perfil.Datos.Fotoperfil;
            imagenEliminar = ""; // HttpContext.Current.Server.MapPath(imagenEliminar);

            return new LPerfil(_context).subirFoto(fotoPerfil, usuario, direccion, ext, imagenEliminar);
        }

    }
}