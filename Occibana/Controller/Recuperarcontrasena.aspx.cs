using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vew_Recuperarcontrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        /*
        Registro recuperar = new Registro();
        recuperar.Correo = TB_CorreoRecuperarcontrasena.Text;
        recuperar.Usuario = TB_UsuarioRecuperarcontrasena.Text;

        recuperar = new DAOLogin().verificarusuarioparatoken(recuperar);
        
        if (recuperar.Usuario == null)
        {
            L_Error_noregistro.Text = "Usuario no se encuentra reistrado";
        }else if (recuperar.Correo == null)
        {
            L_Error_noregistro.Text = "Verifique si su correo electronico fue con el que se registro";
        }
        else if ((recuperar.Usuario != null) && (recuperar.Correo != null))
        {
            Token validartoken = new DAOSeguridad().getTokenusuario(recuperar.Id);

            if (validartoken != null)
            {
                L_Error_noregistro.Text = "Ya existe una recuperacion de contraseña activa, porfavor espere a que pueda realizar una den uevo";
            }
            else
            {
                Token token = new Token();
                token.Fecha_inicio = DateTime.Now;
                token.Fecha_caducidad = DateTime.Now.AddHours(1);
                token.User_id = recuperar.Id;

                token.Tokengenerado = encriptar(JsonConvert.SerializeObject(token));//convierte en cadena JSON clase Token obj token
                new DAOSeguridad().insertartoken(token);
                Mailrecuperarcontrasena mail = new Mailrecuperarcontrasena();
                string linkacceso = "Su link de acceso es: " + "http://localhost:57403/Vew/Reactivarcuenta.aspx?" + token.Tokengenerado;
                mail.enviarmail(recuperar.Correo, token.Tokengenerado, linkacceso);
                L_Error_noregistro.Text = "Verifique su correo electónico para continuar con la recuperacion de contraseña";
            }
            
        }
        
        
        */

    }

    private string encriptar(string input)
    {
        SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = provider.ComputeHash(inputBytes);
        StringBuilder output = new StringBuilder();

        for (int i=0; i<hashedBytes.Length; i++)
        {
            output.Append(hashedBytes[i].ToString("x2").ToLower());
        }
        return output.ToString();
    }
}