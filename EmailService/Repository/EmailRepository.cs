using EmailService.Data;
using EmailService.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDB _applicationDB;

        public EmailRepository(ApplicationDB applicationDB)
        {
            _applicationDB = applicationDB;
        }

        public async Task<EmailRES> Add(EmailRES emailRES)
        {
            await _applicationDB.AddAsync(emailRES);
            await _applicationDB.SaveChangesAsync();
            return emailRES;
        }

        public async Task<EmailRES> Delete(int id)
        {
            var existingemail = await _applicationDB.EmailResponse.FindAsync(id);
            if(existingemail == null)
            {
                return null;
            }

            _applicationDB.EmailResponse.Remove(existingemail); 
            await _applicationDB.SaveChangesAsync();
            return existingemail;
        }

        public async Task<IEnumerable<EmailRES>> GetAll()
        {
            return await _applicationDB.EmailResponse.ToListAsync();
        }

        public async Task<EmailRES> GetBy(int id)
        {
            var email = _applicationDB.EmailResponse.FirstOrDefaultAsync(x => x.Id == id);
            return await email;
        }
    }
}
