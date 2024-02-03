namespace Application.Exceptions;


public class GuidDecryptionException : Exception {

    public GuidDecryptionException() : base("Cipher, Guid'e çevrilemedi.") {
    }

    public GuidDecryptionException(string? message) : base(message) {
    }

    public GuidDecryptionException(string? message, Exception? innerException) : base(message, innerException) {
    }

}
