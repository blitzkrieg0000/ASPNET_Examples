using Application.Dtos;
using X.PagedList;

namespace Application.Models.Paginator;


public class PaginationTableOptions {
    public IPagedList<Dto>? Model { get; set; }
    public string[]? SelectedHeaderNames { get; set; }
    public Dictionary<string, string>? CustomHeaderNames { get; set; }
    public Dictionary<string, Func<object, string>>? Filters { get; set; }
    public string[] Actions { get; set; } = { "Detail", "Remove", "Update" };

    public Dictionary<string, string> HTML = new()
    {
        { "Approve", "<span class='badge badge-success'>✓</span>"},
        { "Deny", "<span class='badge badge-danger'>x</span>"},
    };


    public PaginationTableOptions(IPagedList<Dto> model) {
        Model = model;
    }

    public string ReduceContent(object str) {
        var val = (string)str;
        return val.Length > 20 ? val[..20] : val;
    }

}
