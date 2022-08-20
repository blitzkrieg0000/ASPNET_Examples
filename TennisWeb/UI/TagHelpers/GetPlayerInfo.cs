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
            var player = await _playerService.GetById(PlayerId);
            var html = "";
            html = player.Data.Name;
            output.Content.SetHtmlContent(html);

        }

    }
}