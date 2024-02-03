using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.Auth;
using Application.Dtos.User;
using Application.Enums;
using Application.Features.CQRS.Commands.Auth.SignUp;
using Application.Features.CQRS.Commands.User.RemoveUser;
using Application.Features.CQRS.Commands.User.UpdateUser;
using Application.Features.CQRS.Queries.User.RangeListUser;
using Application.Features.CQRS.Queries.User.UpdateUser;
using Application.Models.Paginator;
using Application.Models.Search;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Admin;


[Authorize(Policy = RoleGroupDefaults.AdminGroup)]
[AutoValidateAntiforgeryToken]
public class UserController : Controller {
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) {
        _mediator = mediator;
    }


    public IActionResult Index() {
        return View();
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.User,
        ActionType = ActionType.Reading,
        Definition = "Kullanıcı Sayfası Görüntüleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.User.List
    )]
    public async Task<IActionResult> List(PaginatorModel paginatorModel, SearchModel search) {
        var request = new RangeListUserRequest(paginatorModel);

        // Search Filter
        if (ModelState.IsValid && !string.IsNullOrEmpty(search.Query)) {
            ViewData["Search"] = search.Query;
            request.Filter = x =>
                x.Username.Contains(search.Query)
                || x.Email.Contains(search.Query)
                || x.Name.Contains(search.Query)
                || x.Id.ToString().Contains(search.Query);
        }

        var response = await _mediator.Send(request);
        return this.ResponseView(response);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.User,
        ActionType = ActionType.Writing,
        Definition = "Kullanıcı Oluşturma Yetkisi",
        Identifier = EndpointDefaults.Identifier.User.Create
    )]
    public IActionResult Create() {
        return View(new UserSignUpDto());
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.User,
        ActionType = ActionType.Writing,
        Definition = "Kullanıcı Oluşturma Yetkisi",
        Identifier = EndpointDefaults.Identifier.User.Create
    )]
    public async Task<IActionResult> Create(UserSignUpDto userSignUpDto) {
        if (ModelState.IsValid) {
            var response = await _mediator.Send(new SignUpRequest(userSignUpDto));
            return this.ResponseRedirectToActionForValidation(response, "List", "User", userSignUpDto);
        }
        return View(userSignUpDto);
    }


    [HttpGet]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.User,
        ActionType = ActionType.Deleting,
        Definition = "Kullanıcı Silme Yetkisi",
        Identifier = EndpointDefaults.Identifier.User.Delete
    )]
    public async Task<IActionResult> Remove(RemoveUserCommandRequest removeUserCommandRequest) {
        var response = await _mediator.Send(removeUserCommandRequest);
        return this.ResponseRedirectToAction(response, "List");
    }


    // [HttpGet]
    // public IActionResult RemovePermanently(Guid id) {

    //     return RedirectToAction("User/List");
    // }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.User,
        ActionType = ActionType.Updating,
        Definition = "Kullanıcı Güncelleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.User.Update
    )]
    public async Task<IActionResult> Update(UpdateUserQueryRequest updateUserQueryRequest) {
        var response = await _mediator.Send(updateUserQueryRequest);
        return this.ResponseView(response);
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.User,
        ActionType = ActionType.Updating,
        Definition = "Kullanıcı Güncelleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.User.Update
    )]
    public async Task<IActionResult> Update(UserUpdateDto userUpdateDto) {
        if (ModelState.IsValid) {
            var response = await _mediator.Send(new UpdateUserCommandRequest(userUpdateDto));
            ViewData["Secret"] = userUpdateDto.Secret;
            return this.ResponseRedirectToActionForValidation(response, "List", userUpdateDto);
        }

        ViewData["Secret"] = userUpdateDto.Secret;
        return View(userUpdateDto);
    }

}
