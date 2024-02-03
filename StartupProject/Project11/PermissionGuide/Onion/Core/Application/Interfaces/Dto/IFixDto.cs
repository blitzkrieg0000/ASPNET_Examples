namespace Application.Interfaces.Dto;


public interface IFixDto {

    DateTime CreatedTime { get; set; }

    DateTime ModifiedTime { get; set; }

    DateTime DeletedTime { get; set; }

    bool IsPersistent { get; set; }

    bool Active { get; set; }
}
