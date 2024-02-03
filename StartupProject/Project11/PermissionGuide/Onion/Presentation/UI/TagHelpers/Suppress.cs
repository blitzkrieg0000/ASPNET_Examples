using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers;


[HtmlTargetElement(Attributes = nameof(Suppress))]
public class SuppressTagHelper : TagHelper {

    public bool Suppress { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output) {
        if (Suppress) {
            output.SuppressOutput();    // Gelen html değeri kapatılır.
        }
    }

}

