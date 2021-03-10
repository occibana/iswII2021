using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilitarios;
using Logica;

public partial class Vew_Membresias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LMembresias logica = new LMembresias();
        UMembresias datos = new UMembresias();
        datos = logica.pageLoad((URegistro)Session["usuario"]);

        TB_Numerotarjeta.Enabled = datos.NumeroTarjeta;
        TB_Codigoseguridad.Enabled = datos.CodigoSeguridad;
        TB_Nombrepropietario.Enabled = datos.NombrePropietario;
        TB_Direccionpropietario.Enabled = datos.DireccionPropietario;
        TB_cedulapropietario.Enabled = datos.CedulaPropietario;
        TB_Usuario.Enabled = datos.Usuario;
        TB_Contrasena.Enabled = datos.Contrasena;
        B_comprar.Enabled = datos.Comprar;

        L_Actualizar_Comprar.Text = datos.Actualizar_Comprar;
        L_Mensajecompra.Text = datos.Mensajecompra;
        L_Costo.Text = datos.Costo;
        L_vencimiento.Text = datos.Vencimiento;
        /*
        try
        {
            
            if (((URegistro)Session["usuario"]).Idestado == 1) //1 Es con menbresia, 0 sin membresia
            {
                TB_Numerotarjeta.Enabled = false;
                TB_Codigoseguridad.Enabled = false;
                TB_Nombrepropietario.Enabled = false;
                TB_Direccionpropietario.Enabled = false;
                TB_cedulapropietario.Enabled = false;
                TB_Usuario.Enabled = false;
                TB_Contrasena.Enabled = false;
                B_comprar.Enabled = false;

            
                L_Actualizar_Comprar.Text = "Actualizar membresía";
                L_Mensajecompra.Text = "El costo de actualización es de: ";
                L_Costo.Text = "50.000 ";
                URegistro usuario = new URegistro();
                usuario.Id = ((URegistro)Session["usuario"]).Id;
                Membresia fechavencimiento = new DAOSeguridad().fechavencimiento(usuario);
                L_vencimiento.Text = (fechavencimiento.Fecha_vencimiento).ToString();
            }
            else
            {
                L_Actualizar_Comprar.Text = "Comprar Membresia";
                L_Mensajecompra.Text = "El costo de compra es de: ";
                L_Costo.Text = "150.000 ";
                L_vencimiento.Text = (DateTime.Now).ToString();
            }
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
        */
    }

    protected void B_comprar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        UMembresia datoscompra = new UMembresia();
        datoscompra.Cedulapropietario = TB_cedulapropietario.Text;
        datoscompra.Codigoseguridad = TB_Codigoseguridad.Text;
        datoscompra.Direccionpropietario = TB_Direccionpropietario.Text;
        datoscompra.Nombrepropietario = TB_Nombrepropietario.Text;
        datoscompra.Numerotarjeta =TB_Numerotarjeta.Text;
        datoscompra.Fecha_compra = DateTime.Now;
        datoscompra.Fecha_vencimiento = DateTime.Now.AddYears(1);
        URegistro usuario = new URegistro();
        usuario.Usuario = TB_Usuario.Text;
        usuario.Contrasena = TB_Contrasena.Text;
        usuario.Id = ((URegistro)Session["usuario"]).Id;
        usuario.Correo = ((URegistro)Session["usuario"]).Correo;

        LMembresias logica = new LMembresias();
        UMembresias datos = new UMembresias(); 

        datos = logica.comprar(datoscompra,usuario, (URegistro)Session["usuario"]);

        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('"+ datos.Error+ "');</script>");
        L_error.Text = datos.Error;
        /*
        ClientScriptManager cm = this.ClientScript;
        Membresia datoscompra = new Membresia();
        datoscompra.Cedulapropietario = encriptar(TB_cedulapropietario.Text);
        datoscompra.Codigoseguridad = encriptar(TB_Codigoseguridad.Text);
        datoscompra.Direccionpropietario = TB_Direccionpropietario.Text;
        datoscompra.Nombrepropietario = TB_Nombrepropietario.Text;
        datoscompra.Numerotarjeta = encriptar(TB_Numerotarjeta.Text);
        datoscompra.Fecha_compra = DateTime.Now;
        datoscompra.Fecha_vencimiento = DateTime.Now.AddYears(1);
        URegistro usuario = new URegistro();
        usuario.Usuario = TB_Usuario.Text;
        usuario.Contrasena = TB_Contrasena.Text;
        usuario.Id = ((URegistro)Session["usuario"]).Id;
        usuario.Correo = ((URegistro)Session["usuario"]).Correo;
        try
        {
            if ((((URegistro)Session["usuario"]).Usuario).Equals(usuario.Usuario))
            {
                var verificacion = new DAOLogin().verificar(usuario);
                if (verificacion == null)
                {
                    L_error.Text = "Verifique que su usuario y su contraseña sean los correctos";
                }
                else
                {
                    datoscompra.Idusuario = ((URegistro)Session["usuario"]).Id;
                    try
                    {
                        new DAOSeguridad().insertarCompra(datoscompra);
                        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Compra realizada con exito.');</script>");
                        L_error.Text = "Compra realizada con exito";
                        usuario.Idestado = 1;
                        new DAOSeguridad().actualizarmembresia(usuario);
                        new Mail().mailconfirmarcompra(usuario);
                    }
                    catch
                    {
                        L_error.Text = "Error al realizar la compra, verifique sus datos";
                    }
                }
            }
            else
            {
                L_error.Text = "Verifique que su usuario sea el correcto";
            }
            
        }
        catch
        {
            Session.Remove("usuario");
            Response.Redirect("index.aspx");
        }
        */

    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx");
    }
}