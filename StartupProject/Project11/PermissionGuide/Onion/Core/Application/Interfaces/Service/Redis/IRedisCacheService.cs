namespace Application.Interfaces.Service.Redis;


public interface IRedisCacheService {
    /**
        <summary>
            Key ile veriyi al.
        </summary>
        <typeparam name="T"></typeparam>
        <param name="key"></param>
        <returns></returns>
    */
    Task<T> GetDataAsync<T>(string key);
    /**
        <summary>
            Key=Value şeklinde veri ekle ve Expire süresi belirle.
        </summary>
        <typeparam name="T"></typeparam>
        <param name="key"></param>
        <param name="value"></param>
        <param name="expirationTime"></param>
        <returns></returns>
   */
    Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime);
    /**
        <summary>
            Key ile veriyi kaldır.
        </summary>
        <param name="key"></param>
        <returns></returns>
    */
    Task<object> RemoveDataAsync(string key);


    Task<bool> RemoveBulkDataAsync(string wildcard);

}
