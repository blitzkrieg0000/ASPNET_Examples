using UI.Dto.User;

namespace UI.Model.User;

public class UserViewModel {
    public UserDto UserDto { get; set; }
    public List<string>? Roles { get; set; }
    public string? Image { get; set; }
}
