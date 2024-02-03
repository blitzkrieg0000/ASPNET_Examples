using Application.Enums;

namespace Application.Dtos.Configurations;


public class Action {
    public string Identifier { get; set; }
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }
}
