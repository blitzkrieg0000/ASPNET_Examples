using Application.Interfaces.Service.Storage;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.Storage;


public class StorageService : IStorageService {
    public string StorageName { get => _storage.GetType().Name; }

    readonly IStorage _storage; // Local

    public StorageService(IStorage storage) {
        _storage = storage;
    }

    public async Task DeleteAsync(string fullName) {
        await _storage.DeleteAsync(fullName);
    }


    public async Task DeleteAsync(string savedPathName, string fileName) {
        await _storage.DeleteAsync(savedPathName, fileName);
    }


    public List<string> GetFiles(string savedPathName) {
        return _storage.GetFiles(savedPathName);
    }


    public bool HasFile(string savedPathName, string fileName) {
        return _storage.HasFile(savedPathName, fileName);
    }


    public Task<List<(string fileName, string savedPathName)>> UploadAsync(IFormFileCollection files, string savedPathName = "data/upload") {
        return _storage.UploadAsync(files, savedPathName);
    }


}
