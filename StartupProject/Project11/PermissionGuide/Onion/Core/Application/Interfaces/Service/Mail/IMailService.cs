namespace Application.Interfaces.Service.Mail;


public interface IMailService {

    Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);

    Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);

    Task SendResetPasswordMailAsync(string to, string resetPasswordJWT);

}
