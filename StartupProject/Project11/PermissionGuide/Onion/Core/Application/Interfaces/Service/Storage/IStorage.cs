using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Service.Storage;


public interface IStorage {

    Task<List<(string fileName, string savedPathName)>> UploadAsync(IFormFileCollection files, string savedPathName = "data/upload");

    Task DeleteAsync(string fullName);

    Task DeleteAsync(string savedPathName, string fileName);

    List<string> GetFiles(string savedPathName);

    bool HasFile(string savedPathName, string fileName);

}
