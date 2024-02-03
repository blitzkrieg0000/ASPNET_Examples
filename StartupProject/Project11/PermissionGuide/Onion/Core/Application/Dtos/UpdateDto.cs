using Application.Interfaces.Dto;

namespace Application.Dtos;


public class UpdateDto : Dto, IUpdateDto {
    public string Secret { get; set; } = "";
    public bool Active { get; set; }
}
