using ProyectoPortfolio.Models;
using System.Net.Mail;
using System.Net;

namespace ProyectoPortfolio.Services
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmail : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            try
            {
                var enviarMail = new MailAddress(configuration.GetValue<string>("SMTP_MAIL"));
                var recibirMail = new MailAddress(configuration.GetValue<string>("SMTP_MAIL"));
                var password = configuration.GetValue<string>("SMTP_PASS_MAIL");
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(enviarMail.Address, password),

                };
                using (var mess = new MailMessage(enviarMail, recibirMail)
                {
                    Subject = "Nuevo Mensaje del Portafolio!",
                    Body = $"Tienes un nuevo mensaje de: {contacto.Email}, con nombre: {contacto.Nombre}" +
                    $"Se comunica para: {contacto.Mensaje}"
                })
                {
                    smtp.Send(mess);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
