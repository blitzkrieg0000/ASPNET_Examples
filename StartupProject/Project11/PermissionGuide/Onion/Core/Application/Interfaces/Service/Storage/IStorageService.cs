namespace Application.Interfaces.Service.Storage;


public interface IStorageService : IStorage {
    
    public string? StorageName { get; }

}

