using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace correo
{
    class Program
    {
        static void Main(string[] args)
        {
          
            try
            {
                MailMessage mail = new MailMessage();
                //quien envia el correo
                mail.From = new MailAddress("andyrobersjavierreyes@gmail.com");
                // a quien le esta enviando
                mail.To.Add("andyrobersjavierreyes@gmail.com");
                //Asunto
                mail.Subject = "Prueba";
                //Cuerpo del mensaje
                mail.Body = "Hola esta es una prueba desde C#";
                //si el cuerpo del mensaje va a llevar html

                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                 smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("yourgmail@gmail.com", "Yourpassword"); // ***use valid credentials***
            smtp.Port = 587;


                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
