using Application.Dtos.User;

namespace Application.Models.User;


public class UserViewModel {
    public UserDto UserDto { get; set; }
    public List<string>? Roles { get; set; }
    public string? Image { get; set; }
}
