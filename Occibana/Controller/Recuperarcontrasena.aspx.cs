using Newtonsoft.Json;
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

public partial class Vew_Recuperarcontrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void B_redireccionarlogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void B_recuperarContrasena_Click(object sender, EventArgs e)
    {
        URegistro recuperar = new URegistro();
        recuperar.Correo = TB_CorreoRecuperarcontrasena.Text;
        recuperar.Usuario = TB_UsuarioRecuperarcontrasena.Text;

        string msj = new LRecuperarcontrasena().enviar_token(recuperar);
        L_Error_noregistro.Text = msj;

    }
}