using Application.Interfaces.Dto;

namespace Application.Dtos;


public class CreateDto : Dto, ICreateDto {
    public bool IsPersistent { get; set; }
    public bool Active { get; set; }
}
