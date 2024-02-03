using System.Net;
using System.Net.Mail;
using Application.Interfaces.Service.Mail;
using Application.Interfaces.Service.ViewToString;
using Application.Models.Mail;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Mail;


public class MailService : IMailService {
    readonly IConfiguration _configuration;
    private readonly IViewRenderService _viewRenderService;
    public MailService(IConfiguration configuration, IViewRenderService viewRenderService) {
        _configuration = configuration;
        _viewRenderService = viewRenderService;
    }


    public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true) {
        await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
    }


    public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true) {
        MailMessage mail = new();
        mail.IsBodyHtml = isBodyHtml;
        foreach (var to in tos) {
            mail.To.Add(to);
        }

        mail.Subject = subject;
        mail.Body = body;
        //Todo <API Application Name>
        mail.From = new(_configuration["Mail:Username"], _configuration["Project:ApplicationName"], System.Text.Encoding.UTF8);
        SmtpClient smtp = new();
        smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.Host = _configuration["Mail:Host"];
        await smtp.SendMailAsync(mail);
    }

    public async Task SendResetPasswordMailAsync(string to, string resetPasswordJWT) {
        var resetPasswordLink = $"{_configuration["Host:Domain"]}/Auth/UpdatePassword?token={resetPasswordJWT}";
        var mailString = await _viewRenderService.RenderToStringAsync("Mail/ResetPassword", new ResetPasswordMailModel(resetPasswordLink));
        await SendMailAsync(to, "Şifre Yenileme Talebi", mailString);
    }


}
