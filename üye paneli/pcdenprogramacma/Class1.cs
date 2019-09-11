using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace pcdenprogramacma
{
    class Class1
    {
        public void mail()
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("tokibilisim34@gmail.com", "TokiKayasehir999");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("tokibilisim34@gmail.com", "Ensar");
            mail.To.Add("alici1@mail.com");
            mail.To.Add("alici2@mail.com");
            mail.CC.Add("alici3@mail.com");
            mail.CC.Add("alici4@mail.com");
            mail.Subject = "E-Posta Konusu";
            mail.IsBodyHtml = true;
            mail.Body = "merhaba arkadaslar kanala hos geldiniz";
            sc.Send(mail);
        }
    }
}
