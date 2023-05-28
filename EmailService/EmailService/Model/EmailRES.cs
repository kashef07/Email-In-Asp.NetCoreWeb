using System.ComponentModel.DataAnnotations;

namespace EmailService.Model
{
    public class EmailRES
    {
        [Key]
        public int Id { get; set; }
        public string? Source { get; set; }
        public string? Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToEmail { get; set; }
        public string? ccEmail { get; set; }
        public string? bccEmail { get; set; }
        public string? FromEmail { get; set; }
        public string? CreatedBy { get; set; }
        public string? ClientIP { get; set; }


    }
}
