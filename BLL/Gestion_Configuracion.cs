using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Net.Mail;
using System.Configuration;

namespace BLL
{
    public class Gestion_Configuracion
    {
        public int[] obtenerParametrosConfiguracion()
        {
            DAO_ConfigMongo cdal = new DAO_ConfigMongo();
            return cdal.obtenerParametros();
        }

        public int obtenerTiempoBackup()
        {
            DAO_ConfigMongo cdal = new DAO_ConfigMongo();
            return cdal.obtenerTiempoBackup();
        }

        public int obtenerTiempoVideo()
        {
            DAO_ConfigMongo cdal = new DAO_ConfigMongo();
            return cdal.obtenerTiempoVideo();
        }

        public bool actualizarParametros(int[] parametros)
        {
            DAO_ConfigMongo cdal = new DAO_ConfigMongo();
            return cdal.actualizarParametros(parametros);
        }

        public bool realizarBackup()
        {
            return true;
        }

        public static void EnviarMail(string to, string subj, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(to));
            mail.From = new MailAddress(ConfigurationManager.AppSettings["emailfrom"]);
            mail.Subject = subj;
            mail.Body = body;
            mail.IsBodyHtml = false;
            SmtpClient client = new SmtpClient("smtp.live.com", 25);
            using (client)
            {
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["emailfrom"], ConfigurationManager.AppSettings["pwdEmailFrom"]);
                client.EnableSsl = true;
                client.Send(mail);
            }
        }

    }
}
