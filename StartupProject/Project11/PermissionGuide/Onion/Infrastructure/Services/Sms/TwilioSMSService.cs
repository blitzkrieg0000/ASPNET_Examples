using Application.Interfaces.Service.Sms;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace Infrastructure.Services.Sms;


public class TwilioSMSService : ITwilioSMSService {
    // KEY GEREKLİ
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string PathServiceSid { get; set; }
    private readonly IConfiguration _configuration;

    public TwilioSMSService(IConfiguration configuration) {
        _configuration = configuration;
        AccountSid = _configuration["Sms:Twilio:AccountSid"];
        AuthToken = _configuration["Sms:Twilio:AuthToken"];
        PathServiceSid = _configuration["Sms:Twilio:PathServiceSid"];
    }

    public async Task SendSmsAsync(string toNumber, string message) {
        try {
            TwilioClient.Init(AccountSid, AuthToken);

            var messageOptions = new CreateMessageOptions(
            new PhoneNumber("+905375544546")) {
                From = new PhoneNumber("+13392318418"),
                Body = message
            };

            var results = await MessageResource.CreateAsync(messageOptions);
            Console.WriteLine(results.Status);
        } catch (Exception e) {
            System.Console.WriteLine(e);
        }
    }


    public async Task<string> SendOTPSms(string toNumber) {
        try {
            TwilioClient.Init(AccountSid, AuthToken);

            var verification = await VerificationResource.CreateAsync(
                to: toNumber,
                channel: "sms",
                pathServiceSid: PathServiceSid
            );
            if (verification.Status == TwilioResponse.Pending) {
                Console.WriteLine(verification.Sid);
            }
            return "";
        } catch (Exception e) {
            System.Console.WriteLine(e);
            return "";
        }
    }


    public async Task<bool> VerifyOTPSms(string phoneNumber, string verificationCode) {
        try {
            var verification = await VerificationCheckResource.CreateAsync(
                to: phoneNumber,
                code: verificationCode,
                pathServiceSid: PathServiceSid
            );
            return verification.Status == TwilioResponse.Approved;
        } catch (Exception e) {
            System.Console.WriteLine(e);
            return false;
        }

    }
}


public static class TwilioResponse {
    public static string Approved { get; set; } = "approved";
    public static string Pending { get; set; } = "pending";
}