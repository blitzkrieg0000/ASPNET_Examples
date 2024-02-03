namespace Application.Consts;


public readonly struct UploadContentDefaults {
    public static readonly string[] AllowedContentTypes = new[] { "image/png", "image/jpeg", "image/bmp", "image/svg+xml", "image/jpg" };
    public static readonly string AllowedContentMessage = "Eklenen dosya 7MB dan küçük JPG, JPEG, PNG, SVG formatında olmalıdır.";
}
