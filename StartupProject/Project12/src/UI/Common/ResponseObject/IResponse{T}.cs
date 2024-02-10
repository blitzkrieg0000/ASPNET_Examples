namespace UI.Common.ResponseObject;


public interface IResponse<T> : IResponse {
    IDictionary<string, dynamic> MetaData { get; set; }
    T Data { get; set; }
    List<CustomValidationError> ValidationErrors { get; set; }
}
