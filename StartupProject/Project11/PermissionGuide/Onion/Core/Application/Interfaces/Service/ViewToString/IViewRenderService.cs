namespace Application.Interfaces.Service.ViewToString;


public interface IViewRenderService {

    Task<string> RenderToStringAsync(string viewName, object model);
    
}
