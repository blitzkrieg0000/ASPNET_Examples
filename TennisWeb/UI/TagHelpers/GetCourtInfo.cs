using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers {

    [HtmlTargetElement("getCourtInfo")]
    public class GetCourtInfo : TagHelper {

        public long CourtId { get; set; }

        private readonly CourtService _courtService;
        public GetCourtInfo(CourtService courtService) {
            _courtService = courtService;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            var player = await _courtService.GetById(CourtId);
            var html = "";
            html = player.Data.Name;
            output.Content.SetHtmlContent(html);

        }
    }
}