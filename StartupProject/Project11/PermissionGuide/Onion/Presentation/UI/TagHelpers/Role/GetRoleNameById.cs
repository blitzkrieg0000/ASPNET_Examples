using Application.Interfaces.Repository.Role;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers.Role;


[HtmlTargetElement("RoleInfo", TagStructure = TagStructure.WithoutEndTag)]
public class RoleInfo : TagHelper {
    public string? Id { get; set; }
    private readonly IRoleQueryRepository _roleQueryRepository;

    public RoleInfo(IRoleQueryRepository roleQueryRepository) {
        _roleQueryRepository = roleQueryRepository;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
        var role = await _roleQueryRepository.GetByIdAsync(Id!);
        string html = $@"'{role.Name}'";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetHtmlContent(html);
    }
}

