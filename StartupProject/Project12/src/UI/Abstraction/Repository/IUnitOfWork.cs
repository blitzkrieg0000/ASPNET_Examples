namespace UI.Abstraction.Repository;


public interface IUnitOfWork : IAsyncDisposable {

    Task BeginTransactionAsync();

    Task<bool> CommitAsync(bool state = true);

}