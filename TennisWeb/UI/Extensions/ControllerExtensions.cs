using Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace UI.Extensions {
    public static class ControllerExtensions {

        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName) {

            controller.TempData["ResponseMessage"] = response.Message;
            if (response.ResponseType == ResponseType.NotFound) {
                return controller.NotFound();
            }

            if (response.ResponseType == ResponseType.ValidationError) {
                if (response.ValidationErrors != null) {
                    foreach (var error in response.ValidationErrors) {
                        controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName) {
            controller.TempData["ResponseMessage"] = response.Message;

            if (response.ResponseType == ResponseType.NotFound) {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName, object x) {
            controller.TempData["ResponseMessage"] = response.Message;

            if (response.ResponseType == ResponseType.NotFound) {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName, x);
        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response) {
            controller.TempData["ResponseMessage"] = response.Message;

            if (response.ResponseType == ResponseType.NotFound) {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }

        

    }
}