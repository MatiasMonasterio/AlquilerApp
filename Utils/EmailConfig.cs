using System.Net.Mail;
using System.Net;

namespace AlquilerApp
{
    public static class EmailConfig
    {
        public static string smtpHost { get; set; }
        public static int Port { get; set; }
        public static string MailFrom { get; set; }
        public static string Password { get; set; }

        public static void EmailGenerator( string MailTo, string Subject, string Tample )
        {
            MailMessage oMailMessage = new MailMessage( 
                MailFrom, 
                MailTo, 
                Subject, 
                Tample
            );

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com"){
                EnableSsl = true,
                UseDefaultCredentials = false,
                Port = Port,
                Credentials = new NetworkCredential( MailFrom, Password )
            };

            oSmtpClient.Send( oMailMessage );
            oSmtpClient.Dispose();
        }

        public static void FeeEmit( string MailTo )
        {
            string Subject = "Factura disponible";
            string Template = "Factura emitida";

            EmailGenerator( MailTo, Subject, Template );
        }

        public static void FeeOverdue( string RenterEmail )
        {
            string Subject = "Factura Vencida";
            string Template = "<p>La facutra se encuentra <strong>vencida</strong></p>";

            EmailGenerator( RenterEmail, Subject, Template);
        }

        public static void SendPaymentTicket( string RenterEmail )
        {
            string Subject = "Comprobante de pago";
            string Template = "Prueba";

            EmailGenerator( RenterEmail, Subject, Template);
        }
    }
}