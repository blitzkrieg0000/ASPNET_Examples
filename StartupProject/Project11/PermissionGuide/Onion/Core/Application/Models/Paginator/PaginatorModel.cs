using Humanizer;

namespace Application.Models.Paginator;


public class PaginatorModel {
    private int skip = 0;
    public int Range { get; set; } = 12;
    public int Page { get; set; } = 1;

    public int Skip {
        get => (Page - 1) * Range;
        set => skip = value;
    }
}
