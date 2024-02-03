using Application.Attributes;
using Application.Consts.Auth;
using Application.Enums;
using Common.ResponseObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Admin;


[Authorize(Policy = "AdminGroup")]
public class AdminController : Controller {

    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Admin,
        ActionType = ActionType.Reading,
        Definition = "Admin Sayfası Görüntüleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Admin.Index
    )]
    public IActionResult Index() {
        return View();
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Admin,
        ActionType = ActionType.Reading,
        Definition = "Ayarlar Sayfasını Görüntüleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Admin.Settings
    )]
    public IActionResult Settings() {
        return this.ResponseView(new Response(ResponseType.Success));
    }


}