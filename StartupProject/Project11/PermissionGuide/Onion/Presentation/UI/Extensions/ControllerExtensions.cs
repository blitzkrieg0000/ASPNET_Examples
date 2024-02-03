using Application.Consts;
using Application.Consts.Auth;
using Application.Dtos.Auth;
using Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace UI.Extensions;


public static class ControllerExtensions {
    /* Kullanıcıya View'i controller içinden return ederken, elimizdeki hataları veya Modelleri yönetmek için bir Extension */

    //! Controller Response
    private static IActionResult ResponseView(this Controller controller, IResponse response, IActionResult viewResult) {
        // CHECK RESPONSE MESSAGE
        if (!controller.TempData.ContainsKey("ResponseMessage")) {
            controller.TempData["ResponseMessage"] = response.Message;
        }
        controller.ViewData["ResponseMessage"] = controller.TempData["ResponseMessage"];

        // CHECK RESPONSE TYPE
        if (response.ResponseType == ResponseType.Error) {
            return controller.RedirectToAction("Error", "Home");
        }

        if (response.ResponseType == ResponseType.NotFound) {
            return controller.NotFound();
        }

        if (response.ResponseType == ResponseType.ValidationError || response.ResponseType == ResponseType.NotAllowed) {
            controller.ModelState.AddModelError(Enum.GetName(typeof(ResponseType), response.ResponseType) ?? "", response.Message);
        }

        return viewResult;
    }


    private static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response, IActionResult viewResult) {
        // CHECK RESPONSE MESSAGE
        if (!controller.TempData.ContainsKey("ResponseMessage")) {
            controller.TempData["ResponseMessage"] = response.Message;
        }
        controller.ViewData["ResponseMessage"] = controller.TempData["ResponseMessage"];


        // CHECK METADATA
        if (response.MetaData != null && response.MetaData.ContainsKey("Secret")) {
            controller.ViewData["Secret"] = response.MetaData["Secret"];
        }


        // CHECK RESPONSE CODE
        if (response.ResponseType == ResponseType.Error) {
            return controller.RedirectToAction("Error", "Home");
        }

        if (response.ResponseType == ResponseType.NotFound) {
            return controller.NotFound();
        }

        if (response.ResponseType == ResponseType.ValidationError || response.ResponseType == ResponseType.NotAllowed) {
            controller.ModelState.AddModelError(Enum.GetName(typeof(ResponseType), response.ResponseType) ?? "", response.Message);
            if (response.ValidationErrors != null) {
                foreach (var error in response.ValidationErrors) {
                    if (error.PropertyName != null && error.ErrorMessage != null) {
                        controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
        }

        return viewResult;
    }


    // View
    public static IActionResult ResponseView(this Controller controller, IResponse response) {
        return ResponseView(controller, response, controller.View());
    }

    public static IActionResult ResponseView(this Controller controller, IResponse response, string viewName) {
        return ResponseView(controller, response, controller.View(viewName));
    }

    public static IActionResult ResponseViewWithCustomModel<T>(this Controller controller, IResponse response, T model) {
        return ResponseView(controller, response, controller.View(model));
    }

    public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response) {
        return ResponseView(controller, response, controller.View(response.Data));
    }

    public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response, string viewName) {
        return ResponseView(controller, response, controller.View(viewName, response.Data));
    }

    public static IActionResult ResponseViewWithCustomModel<T, TModel>(this Controller controller, IResponse<T> response, string viewName, TModel model) {
        return ResponseView(controller, response, controller.View(viewName, model));
    }


    // RedirectToAction
    public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName));
    }

    public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName, string controllerName) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName, controllerName));
    }

    public static IActionResult ResponseRedirectToActionWithCustomModel<T>(this Controller controller, IResponse response, string actionName, T model) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName, model));
    }

    public static IActionResult ResponseRedirectToActionWithCustomModel<T>(this Controller controller, IResponse response, string actionName, string controllerName, T model) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName, controllerName, model));
    }

    public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName, response.Data));
    }

    public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName, string controllerName) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName, controllerName, response.Data));
    }

    public static IActionResult ResponseRedirectToActionWithCustomModel<T, TModel>(this Controller controller, IResponse<T> response, string actionName, TModel model) {
        return ResponseView(controller, response, controller.RedirectToAction(actionName, model));
    }


    // Validation (Create - Update)
    /*
      !  Eğer Response Success değilse Create ve Update işlemleri için veriyi kaybetmemek adına tekrar aynı sayfaya yönlendirir.
      !  Eğer Response Success ise İstenilen actiona yönlendirir.
    */
    public static IActionResult ResponseRedirectToActionForValidation<T>(this Controller controller, IResponse response, string actionName, T model) {
        if (response.ResponseType == ResponseType.NotAllowed || response.ResponseType == ResponseType.ValidationError) {
            return ResponseViewWithCustomModel(controller, response, model);
        }
        return ResponseView(controller, response, controller.RedirectToAction(actionName));
    }

    public static IActionResult ResponseRedirectToActionForValidation<T>(this Controller controller, IResponse response, string actionName, string controllerName, T model) {
        if (response.ResponseType == ResponseType.NotAllowed || response.ResponseType == ResponseType.ValidationError) {
            return ResponseViewWithCustomModel(controller, response, model);
        }
        return ResponseView(controller, response, controller.RedirectToAction(actionName, controllerName));
    }

    public static IActionResult ResponseRedirectToActionForValidation<T>(this Controller controller, IResponse<T> response, string actionName) {
        if (response.ResponseType == ResponseType.NotAllowed || response.ResponseType == ResponseType.ValidationError) {
            return ResponseViewWithCustomModel(controller, response, response.Data);
        }
        return ResponseView(controller, response, controller.RedirectToAction(actionName));
    }

    public static IActionResult ResponseRedirectToActionForValidation<T, TModel>(this Controller controller, IResponse<T> response, string actionName, TModel model) {
        if (response.ResponseType == ResponseType.NotAllowed || response.ResponseType == ResponseType.ValidationError) {
            return ResponseViewWithCustomModel(controller, response, model);
        }
        return ResponseView(controller, response, controller.RedirectToAction(actionName));
    }

    public static IActionResult ResponseRedirectToActionForValidation<T, TModel>(this Controller controller, IResponse<T> response, string actionName, string controllerName, TModel model) {
        if (response.ResponseType == ResponseType.NotAllowed || response.ResponseType == ResponseType.ValidationError) {
            return ResponseViewWithCustomModel(controller, response, model);
        }
        return ResponseView(controller, response, controller.RedirectToAction(actionName, controllerName));
    }

    public static IActionResult ResponseRedirectToActionForValidation<T>(this Controller controller, IResponse<T> response, string actionName, string controllerName) {
        if (response.ResponseType == ResponseType.NotAllowed || response.ResponseType == ResponseType.ValidationError) {
            return ResponseViewWithCustomModel(controller, response, response.Data);
        }
        return ResponseView(controller, response, controller.RedirectToAction(actionName, controllerName));
    }


    //! RedirectSignIn
    public static IActionResult SignInView(this Controller controller, IResponse<Page> response) {
        return ResponseRedirectToActionForValidation(controller, response, response.Data.Action, response.Data.Controller, new UserSignInDto());
    }
}