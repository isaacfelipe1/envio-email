using System;
using System.Net.Mail;
using System.Net;

public class Program
{

    static void Main(string[] args)
    {
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587; 
        bool enableSSL = true;        
        string emailFrom = " Seu e-mail";
        string password = " Sua senha"; 
        string emailTo = " E-mail do destinatário";
        string subject = "Assunto do E-mail";
        string body = " Corpo do E-mail";

        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                try
                {
                    smtp.Send(mail);
                    Console.WriteLine("E-mail enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao enviar e-mail: " + ex.Message);
                }
            }
        }
    }
}