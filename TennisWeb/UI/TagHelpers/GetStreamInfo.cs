using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace UI.TagHelpers {
    
    [HtmlTargetElement("getStreamInfo")]
    public class GetStreamInfo : TagHelper{

        public long StreamId { get; set; }

        private readonly IStreamService _streamService;

        public GetStreamInfo(IStreamService streamService) {
            _streamService = streamService;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            var response = await _streamService.GetById(StreamId);
            var html = "";
            html = response.Data.Name;
            output.Content.SetHtmlContent(html);
        }

    }
}