namespace Common.ResponseObjects;


public class Response<T> : Response, IResponse<T> {
    public IDictionary<string, dynamic> MetaData { get; set; } = null!;
    public T Data { get; set; } = default!;
    public List<CustomValidationError> ValidationErrors { get; set; } = default!;

    public Response(ResponseType responseType) : base(responseType) {
    }

    public Response(ResponseType responseType, string message) : base(responseType, message) {
    }

    public Response(ResponseType responseType, T data) : this(responseType) {
        Data = data;
    }

    public Response(ResponseType responseType, T data, string message) : this(responseType, message) {
        Data = data;
    }

    public Response(ResponseType responseType, T data, IDictionary<string, dynamic> metaData) : this(responseType, data) {
        MetaData = metaData;
    }

    public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : this(responseType, data) {
        ValidationErrors = errors;
    }

    public Response(ResponseType responseType, T data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : this(responseType, data, metaData) {
        ValidationErrors = errors;
    }

}
