using EmailService.Model;

namespace EmailService.Repository
{
    public interface IEmailRepository
    {
        Task<IEnumerable<EmailRES>> GetAll();
        Task<EmailRES> Add(EmailRES emailRES);
        Task<EmailRES> GetBy(int id);
        Task<EmailRES> Delete(int id);
    }
}
