using UI.Abstraction.Dto;

namespace UI.Dto;


public class UpdateDto : Dto, IUpdateDto {
    public string Secret { get; set; } = "";
    public bool Active { get; set; }
}
