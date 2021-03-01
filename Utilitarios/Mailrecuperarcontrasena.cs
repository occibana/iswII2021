using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Descripción breve de Mailrecuperarcontrasena
/// </summary>
/// 
namespace Utilitarios
{
    public class Mailrecuperarcontrasena
    {
        public void enviarmail(string correodestino, string usertoken, string linkacceso)
        {
            //mail
            MailMessage mail = new MailMessage();
            SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("occibana@gmail.com", "Recuperacion contrasena");//correo que envia, diplay name 
            SmtpSever.Host = "smtp.gmail.com";//servidor gmail
            mail.Subject = "Recupere su contraseña";//asunto
            mail.Body = "Su contraseña ha sido aprobada para recuperacion, utilice este link para recuperar su contraseña ahoramismo.\n" +
                "Cuenta con una (1) hora para hacer valida la recuperacion.\n" + linkacceso;
            mail.To.Add(correodestino);//destino del correo
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //Configuracion del SMTP
            SmtpSever.Port = 587;
            SmtpSever.Credentials = new System.Net.NetworkCredential("occibana@gmail.com", "proyectoisw2");//correo origen, contra*
            SmtpSever.EnableSsl = true;
            SmtpSever.Send(mail);//eviar
                                 //mail
        }
    }
}
