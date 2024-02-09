using UI.Abstraction.Dto;

namespace UI.Dto;


public class CreateDto : Dto, ICreateDto {
    public bool IsPersistent { get; set; }
    public bool Active { get; set; }
}
