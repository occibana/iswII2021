using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

using Utilitarios;

/// <summary>
/// Descripción breve de Mail
/// </summary>
/// 

namespace Utilitarios
{
    public class Mail
    {
        public void enviarmail(URegistro MailE)
        {
            //mail
            MailMessage mail = new MailMessage();
            SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("occibana@gmail.com", "Registro exitoso");//correo que envia, diplay name 
            SmtpSever.Host = "smtp.gmail.com";//servidor gmail
            mail.Subject = "Registro exitoso";//asunto
            mail.Body = "Su registro ha sido exitoso, porfavor recuerde que:\nUsuario: " + MailE.Usuario +
                "\nContraseña: " + MailE.Contrasena;
            mail.To.Add(MailE.Correo);//destino del correo
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //Configuracion del SMTP
            SmtpSever.Port = 587;
            SmtpSever.Credentials = new System.Net.NetworkCredential("occibana@gmail.com", "occibana123");//correo origen, contra*
            SmtpSever.EnableSsl = true;
            SmtpSever.Send(mail);//eviar
                                 //mail
        }

        public void mailactualizarcontrasena(URegistro MailE)
        {
            //mail
            MailMessage mail = new MailMessage();
            SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("occibana@gmail.com", "Actualizacion exitosa");//correo que envia, diplay name 
            SmtpSever.Host = "smtp.gmail.com";//servidor gmail
            mail.Subject = "Actualizacion contraseña";//asunto
            mail.Body = "Su actualizacion ha sido exitosa";
            mail.To.Add(MailE.Correo);//destino del correo
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //Configuracion del SMTP
            SmtpSever.Port = 587;
            SmtpSever.Credentials = new System.Net.NetworkCredential("occibana@gmail.com", "occibana123");//correo origen, contra*
            SmtpSever.EnableSsl = true;
            SmtpSever.Send(mail);//eviar
                                 //mail
        }

        public void mailconfirmarcompra(URegistro MailE)
        {
            //mail
            MailMessage mail = new MailMessage();
            SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("occibana@gmail.com", "Compra exitosa");//correo que envia, diplay name 
            SmtpSever.Host = "smtp.gmail.com";//servidor gmail
            mail.Subject = "Compra finalizada";//asunto
            mail.Body = "Su compra de membresia ha sido exitosa señor/a" + MailE.Nombre;
            mail.To.Add(MailE.Correo);//destino del correo
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //Configuracion del SMTP
            SmtpSever.Port = 587;
            SmtpSever.Credentials = new System.Net.NetworkCredential("occibana@gmail.com", "occibana123");//correo origen, contra*
            SmtpSever.EnableSsl = true;
            SmtpSever.Send(mail);//eviar
                                 //mail
        }

        /*public void mailconfirmarreserva(Reserva MailE)
        {
            //mail
            MailMessage mail = new MailMessage();
            SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("occibana@gmail.com", "Reserva exitosa");//correo que envia, diplay name 
            SmtpSever.Host = "smtp.gmail.com";//servidor gmail
            mail.Subject = "Compra finalizada";//asunto
            mail.Body = "Su reserva ha sido exitosa señor/a ";
            mail.To.Add(MailE.Correo);//destino del correo
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //Configuracion del SMTP
            SmtpSever.Port = 587;
            SmtpSever.Credentials = new System.Net.NetworkCredential("occibana@gmail.com", "occibana123");//correo origen, contra*
            SmtpSever.EnableSsl = true;
            SmtpSever.Send(mail);//eviar
                                 //mail
        }*/
    }
}

