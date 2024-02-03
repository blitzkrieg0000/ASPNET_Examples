namespace Application.Interfaces;


public interface IUnitOfWork : IAsyncDisposable {

    Task BeginTransactionAsync();

    Task<bool> CommitAsync(bool state = true);

}