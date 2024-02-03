using Application.Interfaces.Service.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.Storage.Local;


public class LocalStorage : Storage, ILocalStorage {
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger<LocalStorage> _logger;

    public LocalStorage(IWebHostEnvironment webHostEnvironment, ILogger<LocalStorage> logger) {
        _webHostEnvironment = webHostEnvironment;
        _logger = logger;
    }


    public async Task DeleteAsync(string fullName) {
        try {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fullName);
            File.Delete(path);
        } catch {
            _logger.LogError($"Dosya silme başarısız : {fullName}");
        }
    }


    public async Task DeleteAsync(string path, string fileName) {
        var fullPath = string.Empty;
        try {
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", $"{path}/{fileName}");
            File.Delete(fullPath);
        } catch {
            _logger.LogError($"Dosya silme başarısız : {fullPath}");
        }
    }


    public List<string> GetFiles(string path) {
        DirectoryInfo directory = new(path);
        return directory.GetFiles().Select(f => f.Name).ToList();
    }


    public bool HasFile(string path, string fileName) {
        return File.Exists($"{path}/{fileName}");
    }


    private async Task<bool> CopyFileAsync(string path, IFormFile file) {
        try {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            _logger.LogInformation($"Dosya yüklendi : {path}");
            return true;

        } catch {
            _logger.LogError($"Dosya yükleme başarısız : {path}");
            throw new Exception("Dosya yüklenirken hata oluştu.");
        }
    }


    public async Task<List<(string fileName, string savedPathName)>> UploadAsync(IFormFileCollection files, string path = "data/upload") {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        List<(string fileName, string path)> datas = new();
        foreach (IFormFile file in files) {
            string fileNewName = await FileRenameAsync(uploadPath, file.FileName, HasFile);

            await CopyFileAsync($"{uploadPath}/{fileNewName}", file);
            datas.Add((fileNewName, $"{path}/{fileNewName}"));
        }

        return datas;
    }


}
