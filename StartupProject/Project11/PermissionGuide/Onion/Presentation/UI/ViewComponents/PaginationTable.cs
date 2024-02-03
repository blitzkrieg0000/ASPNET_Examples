using Application.Models.Paginator;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace UI.ViewComponents;


public class PaginationTable : ViewComponent {
    private string? HeaderHtml { get; set; }
    private List<string>? ContentHtml { get; set; } = new();
    private string[]? DefaultProperties { get; set; }


    private void SetModelProperties(PaginationTableOptions opts) {
        // Model'deki property isimlerini çıkart
        var query = opts.Model.FirstOrDefault().GetType().GetProperties().Select(p => p.Name);
        if (opts.SelectedHeaderNames != null) {
            query = query.Where(name => opts.SelectedHeaderNames.Contains(name));
        }
        DefaultProperties = query.ToArray();
    }


    private void SetHeaderHtml(PaginationTableOptions opts) {
        var customProperties = (string[])DefaultProperties.Clone();
        
        // Tabloda görünecek property isimlerini yeni verilen değerler ile değiştir. 
        if (opts.CustomHeaderNames != null) {
            foreach (var item in opts.CustomHeaderNames) {
                for (int i = 0; i < customProperties.Length; i++) {
                    if (customProperties[i] == item.Key) {
                        customProperties[i] = item.Value;
                    }
                }
            }
        }

        // Properyleri düz html string olarak ele al
        foreach (var prop in customProperties) {
            HeaderHtml += $"<th>{prop}</th>";
        }

        HeaderHtml ??= "<th>Hiç veri yok.</th>";
        ViewData["HeaderHtml"] = HeaderHtml;
    }


    private void SetContentHtml(PaginationTableOptions opts) {
        var html = "";
        Type type;
        foreach (var item in opts.Model) {
            type = item.GetType();
            if (type != null) {
                html = "";
                foreach (var prop in DefaultProperties) {
                    try {
                        // Her bir Model item'ı içindeki değere, eğer filtre varsa uygula ve düz html stringine çevir.
                        var value = type.GetProperty(prop).GetValue(item, null);
                        if (opts.Filters != null) {
                            var func = opts.Filters.Where(pair => pair.Key == prop).Select(x => x.Value).SingleOrDefault();
                            if (func != null && value != null) {
                                value = func.Invoke(value);
                            }
                        }
                        html += $"<td>{value}</td>";
                    } catch { }
                }
                ContentHtml.Add(html);
            }
        }
        ViewData["ContentHtml"] = ContentHtml.ToArray();
    }


    public IViewComponentResult Invoke(PaginationTableOptions opts) {
        if (opts.Model == null) {
            throw new Exception("Model Null Olamaz.");
        }
        if (opts.Model.Count < 1) {
            ViewData["HeaderHtml"] = "<th>-</th>";
            return View("default", opts.Model);
        }

        SetModelProperties(opts);
        SetHeaderHtml(opts);
        SetContentHtml(opts);
        ViewData["Actions"] = opts.Actions;
        return View("default", opts.Model);
    }

}