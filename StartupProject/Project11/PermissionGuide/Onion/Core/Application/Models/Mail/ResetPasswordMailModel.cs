namespace Application.Models.Mail;


public class ResetPasswordMailModel {
    public string ResetPasswordLink { get; set; }

    public ResetPasswordMailModel(string resetPasswordLink = "") {
        ResetPasswordLink = resetPasswordLink.ToString();
    }

}