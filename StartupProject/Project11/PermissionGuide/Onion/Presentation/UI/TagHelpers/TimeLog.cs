using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers;

[HtmlTargetElement("timelog", TagStructure = TagStructure.WithoutEndTag)]
public class TimeLog : TagHelper {
    // UTC Zamanını <p> Etiketi İçine Açıklamayla Bastırır.
    public string? ShortDescription { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
        string html = $"<p> {DateTime.UtcNow} - {ShortDescription} </p>";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(html);
    }


}
