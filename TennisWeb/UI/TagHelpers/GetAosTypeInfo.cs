using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers {
    
    [HtmlTargetElement("getAosTypeInfo")]
    public class GetAosTypeInfo : TagHelper {

        public long AosTypeId { get; set; }

        private readonly AosTypeService _aosTypeService;
        public GetAosTypeInfo(AosTypeService aosTypeService) {
            _aosTypeService = aosTypeService;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            var player = await _aosTypeService.GetById(AosTypeId);
            var html = "";
            html = player.Data.Name;
            output.Content.SetHtmlContent(html);

        }
    }
}