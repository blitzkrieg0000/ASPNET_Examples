using Application.Interfaces.Service.Redis;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Infrastructure.Services.Redis;


public class RedisCacheService : IRedisCacheService {
    /*
      ?  Newtonsoft.Json ile serialize/deserialize işlemi yapılıyor. 
      ?  Ancak daha fazla hız kazancı gerekirse System.Text.Json kütüphanesi kullanılacak.
      ?  Her iki kütüphanenin de avantajları ve dezavantajları var.
    */
    private readonly IDatabase _db;
    private readonly IConnectionMultiplexer _redis;
    private readonly ILogger<RedisCacheService> _logger;

    public RedisCacheService(IConnectionMultiplexer redis, ILogger<RedisCacheService> logger) {
        _redis = redis;
        _db = redis.GetDatabase();
        _logger = logger;
    }

    private bool IsAlive => _redis.IsConnected;

    public async Task<T> GetDataAsync<T>(string key) {
        if (IsAlive) {
            try {
                var value = await _db.StringGetAsync(key);
                if (!string.IsNullOrEmpty(value)) {
                    return JsonConvert.DeserializeObject<T>(value);
                }
            } catch {
                _logger.LogError($"Redis'ten veri okunurken hata oluştu: key={key}");
            }
        }
        return default;
    }


    public async Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime) {
        if (IsAlive) {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            try {
                return await _db.StringSetAsync(key, JsonConvert.SerializeObject(value), expiryTime);
            } catch {
                _logger.LogError($"Redis'e veri yazılırken hata oluştu: key={key}");
            }
        }
        return false;
    }


    public async Task<object> RemoveDataAsync(string key) {


        if (IsAlive) {
            bool _isKeyExist = await _db.KeyExistsAsync(key);
            if (_isKeyExist == true) {
                return await _db.KeyDeleteAsync(key);
            }
        }
        return false;
    }


    public async Task<bool> RemoveBulkDataAsync(string wildcard) {
        try {
            foreach (var ep in _redis.GetEndPoints()) {
                var server = _redis.GetServer(ep);
                var keys = server.KeysAsync(pattern: wildcard);
                await foreach (var key in keys) {
                    await _db.KeyDeleteAsync(key);
                }
            }
        } catch {
            return false;
        }
        return true;
    }

}

