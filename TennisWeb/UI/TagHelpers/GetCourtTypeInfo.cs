using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers {
	
	[HtmlTargetElement("getCourtTypeInfo")]
	public class GetCourtTypeInfo : TagHelper {

		public long? CourtTypeId { get; set; }

		private readonly ICourtTypeService _courtService;
		public GetCourtTypeInfo(ICourtTypeService courtService) {
			_courtService = courtService;
		}

		public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
			var response = await _courtService.GetById(CourtTypeId);
			var html = "";
			html = response.Data.Name;
			output.Content.SetHtmlContent(html);

		}

	}
}