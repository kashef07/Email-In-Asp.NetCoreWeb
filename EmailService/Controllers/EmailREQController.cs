using EmailService.Repository;
using Microsoft.AspNetCore.Mvc;
using EmailService.Model;
using System.Net.Mail;
using System.Net;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("controller")]
    public class EmailREQController : Controller
    {
        private readonly IEmailRepository _emailRepository;

        public EmailREQController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllEmail()
        {
            var email = await _emailRepository.GetAll();
            return Ok(email);
        }

        [HttpPost]
        public  Task AddEmail(EC em)
        {
            EmailRES email = new EmailRES();
            email.ToEmail = em.ToEmail;
            email.Subject = em.Subject;
            email.Body = em.Body;
            _emailRepository.Add(email);
            //var emm = await _emailRepository.Add();
            string username = "from-Email";
            string password = "from-Email password";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(username);
            mailMessage.To.Add(new MailAddress(em.ToEmail));
            mailMessage.Body = em.Body;
            mailMessage.IsBodyHtml = true; //to make message body as html  
            mailMessage.Subject = em.Subject;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            SendEmail(username, password, mailMessage);



            return Task.CompletedTask;
        
    }

        private static void SendEmail(string username, string password, MailMessage mailMessage)
        {
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.office365.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(username, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mailMessage);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSingleEmail(int id)
        {
            var email = await _emailRepository.GetBy(id);
            if (email == null)
            {
                return null;
            }

            return Ok (email);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            var email = await _emailRepository.Delete(id);
            if(email == null)
            {
                return null;
            }

            return Ok(email);
        }
    }
}
