namespace Application.Interfaces.Service.Sms;


public interface ITwilioSMSService {
    Task SendSmsAsync(string toNumber, string message);
    Task<string> SendOTPSms(string toNumber);
    Task<bool> VerifyOTPSms(string phoneNumber, string verificationCode);
}
