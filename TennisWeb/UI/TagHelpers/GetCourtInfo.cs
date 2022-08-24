using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers {

    [HtmlTargetElement("getCourtInfo")]
    public class GetCourtInfo : TagHelper {

        public long? CourtId { get; set; }

        private readonly ICourtService _courtService;
        public GetCourtInfo(ICourtService courtService) {
            _courtService = courtService;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            var response = await _courtService.GetById(CourtId);
            var html = "";
            html = response.Data.Name;
            output.Content.SetHtmlContent(html);

        }

    }
}