namespace UI.Common.ResponseObject;

public interface IResponse {
    string Message { get; set; }
    ResponseType ResponseType { get; set; }

}
