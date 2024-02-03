namespace Application.Models.Auth;


public class UpdatePasswordModel {

    public string ResetPasswordToken { get; set; }

    public string NewPassword { get; set; }
    
}
