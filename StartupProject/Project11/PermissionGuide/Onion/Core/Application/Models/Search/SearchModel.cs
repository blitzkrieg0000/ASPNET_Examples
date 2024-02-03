namespace Application.Models.Search;

public class SearchModel {
    private string Search { get; set; } = "";
    public string Query {
        get => Search;
        set => Search = value != null ? (value.Length > 50 ? value[..50] : value) : "";
    }
}
