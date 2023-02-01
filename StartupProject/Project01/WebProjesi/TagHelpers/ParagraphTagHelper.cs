using Microsoft.AspNetCore.Razor.TagHelpers;


namespace WebProjesi.TagHelpers {

    [HtmlTargetElement("paragraph")]
    public class ParagraphTagHelper: TagHelper {

        public string ShortDescription { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.Content.SetHtmlContent($"<b> NEW TAG HELPER {ShortDescription} </b>");
            base.Process(context, output);
        }
        

    }
}