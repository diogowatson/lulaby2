using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace WebAPIClassLibary;
{
    public class Sendmail
    {
        //global variable
        private string LocationOfFileBody { get; set; }
        private string MailAddress { get; set; }
        private string Subject { get; set; }
        private string Message { get; set; }
    public object Console { get; }

    //public StreamReader reader = File.OpenText("C:/Users/diogo.watson/source/repos/emailApp/emailApp/emailBody.html");

    public static string bodyLocation = "C:/Users/diogo.watson/source/repos/emailApp/emailApp/emailBody.html";

        //contructor that uses an HTML file as body message
        public Sendmail(string mailAddress,
                        string subject
                        )
        {
            try
            {

                MailAddress = mailAddress;
                Subject = subject;
            }
            catch (Exception e)
            {
                

            }

        }


        public Sendmail(string message,
                        string mailAddress,
                        string subject
                        )
        {
            try
            {
                Message = Message;
                MailAddress = mailAddress;
                Subject = subject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }
        //this function take 3 parameters
        //param 1 -> an Streamreader Object that points to HTML of the email body
        //ex:StreamReader reader = File.OpenText("C:/Users/diogo.watson/source/repos/emailApp/emailApp/emailBody.html");
        //param 2 teh email address to send the email
        //param 3 the subject of the email

        public void SendWithHTMLBody()
        {
            StreamReader reader = File.OpenText("C:/Users/diogo.watson/source/repos/web-api-version01/web-api-version01Resources/emailBody.html");
            string message = reader.ReadToEnd();
            MailMessage mail = new MailMessage("adastra.credit.project@gmail.com", MailAddress);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;//important
            client.Credentials = new NetworkCredential("adastra.credit.project@gmail.com", "Adastra10");
            mail.IsBodyHtml = true;
            LinkedResource emailImage = new LinkedResource("adastra2.png");

            mail.Subject = Subject;
            mail.Body = message;

            if (message == null)
            {
                Console.WriteLine("Null");
            }
            else
            {
                Console.WriteLine(message);
            }


            try
            {
                client.Send(mail);
            }
            catch (Exception e) { Console.WriteLine(e); }
            Console.Read();
        }


        //this function take 3 parameters
        //param 1 -> an message string
        //param 2 teh email address to send the email
        //param 3 the subject of the email
        public void SendMessage()
        {

            MailMessage mail = new MailMessage("adastra.credit.project@gmail.com", MailAddress);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            // client.Host = "";
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;//important
            client.Credentials = new NetworkCredential("adastra.credit.project@gmail.com", "Adastra10");
            mail.IsBodyHtml = true;
            mail.Subject = Subject;
            mail.Body = Message;

            try
            {
                client.Send(mail);
            }
            catch (Exception e) { Console.WriteLine(e); }
            Console.Read();
        }
    }
}