using System.Net;
using Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace UI.Extensions;


public static class ControllerApiExtensions {

    public static IActionResult ResponseResult(this ControllerBase controller, Response response, IActionResult _actionResult) {

        if (response.ResponseType == ResponseType.NotFound) {
            return controller.NotFound(response);
        }

        if (response.ResponseType == ResponseType.Error) {
            return controller.BadRequest();
        }

        if (response.ResponseType == ResponseType.ValidationError) {
            return controller.BadRequest();
        }

        return _actionResult;
    }


    public static IActionResult ResponseOkResult(this ControllerBase controller, Response response) {
        return ResponseResult(controller, response, controller.Ok(response));
    }


    public static IActionResult ResponseOkResult<T>(this ControllerBase controller, Response<T> response) {
        return ResponseResult(controller, response, controller.Ok(response));
    }


    public static IActionResult ResponseCreatedResult(this ControllerBase controller, Response response) {
        return ResponseResult(controller, response, controller.Created("", response));
    }


    public static IActionResult ResponseCreatedResult<T>(this ControllerBase controller, Response<T> response) {
        return ResponseResult(controller, response, controller.Created("", response));
    }

}