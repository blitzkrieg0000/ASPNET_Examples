using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers {

    [HtmlTargetElement("getPlayerInfo")]
    public class GetPlayerInfo : TagHelper {

        public long PlayerId { get; set; }

        private readonly IPlayerService _playerService;
        public GetPlayerInfo(IPlayerService playerService) {
            _playerService = playerService;
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            var response = await _playerService.GetById(PlayerId);
            var html = "";
            html = response.Data.Name;
            output.Content.SetHtmlContent(html);

        }

    }
}