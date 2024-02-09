using UI.Abstraction.Dto;

namespace UI.Dto;


public class FixDto : Dto, IFixDto {
    public DateTime CreatedTime { get; set; }
    public DateTime ModifiedTime { get; set; }
    public DateTime DeletedTime { get; set; }
    public bool IsPersistent { get; set; }
    public bool Active { get; set; }
}
