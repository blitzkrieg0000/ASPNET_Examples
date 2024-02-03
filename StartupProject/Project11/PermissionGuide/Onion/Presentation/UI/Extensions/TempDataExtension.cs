using System.Text.Json;
using Application.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace UI.Extensions;


public static class TempDataExtensions {
    public static void PutModel<T>(this ITempDataDictionary tempData, string key, T value) where T : class {
        tempData[key] = JsonSerializer.Serialize(value).EncryptString();
        tempData.Keep(key);
    }


    public static T GetModel<T>(this ITempDataDictionary tempData, string key) where T : class {
        object? o = tempData.Peek(key);
        tempData.Keep(key);
        return o == null ? null : JsonSerializer.Deserialize<T>(((string)o).DecryptString());
    }


    public static void KeepModel<T>(this ITempDataDictionary tempData, string key, ref T value) where T : class {
        value ??= GetModel<T>(tempData, key);
        PutModel(tempData, key, value);
    }

}