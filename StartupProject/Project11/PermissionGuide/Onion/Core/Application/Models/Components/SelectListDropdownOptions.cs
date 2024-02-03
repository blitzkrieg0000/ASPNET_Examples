using Application.Dtos;

namespace Application.Models.Components;


public class SelectListDropdownOptions {
    public IEnumerable<Dto>? Dto { get; set; }
    public string? ValueField { get; set; } = "Id";
    public string? NameField { get; set; } = "Name";
    public Guid? SelectedId { get; set; }
    public string? SelectListName { get; set; }
}