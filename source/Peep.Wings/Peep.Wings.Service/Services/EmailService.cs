using System.Net;
using System.Net.Mail;

namespace Peep.Wings.Service.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    private readonly SmtpClient _client;

    public EmailService(IConfiguration config)
    {
        this._config = config;

        _client = new SmtpClient(_config["Email:Host"], int.Parse(_config["Email:Port"]))
        {
            Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]),
            EnableSsl = true
        };
    }

    public Task SendEmailAsync(string to, string subject, string body, bool isHTML = true)
    {
        var email = new MailMessage(_config["Email:Username"], to, subject, body)
        {
            IsBodyHtml = isHTML
        };
        _client.SendAsync(email, null);
        return Task.CompletedTask;
    }
}

