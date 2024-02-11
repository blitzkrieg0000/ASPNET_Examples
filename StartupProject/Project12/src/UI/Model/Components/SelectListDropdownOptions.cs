using U=UI.Dto;

namespace UI.Models.Components;


public class SelectListDropdownOptions {
    public IEnumerable<U::Dto>? Dto { get; set; }
    public string? ValueField { get; set; } = "Id";
    public string? NameField { get; set; } = "Name";
    public Guid? SelectedId { get; set; }
    public string? SelectListName { get; set; }
}