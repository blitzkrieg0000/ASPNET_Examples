using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers {

    [HtmlTargetElement("getAosTypeInfo")]
    public class GetAosTypeInfo : TagHelper {

        public long AosTypeId { get; set; }

        private readonly IAosTypeService _aosTypeService;
        public GetAosTypeInfo(IAosTypeService aosTypeService) {
            _aosTypeService = aosTypeService;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            var response = await _aosTypeService.GetById(AosTypeId);
            var html = "";
            html = response.Data.Name;
            output.Content.SetHtmlContent(html);
        }
    }
}