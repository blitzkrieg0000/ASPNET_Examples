using System.Security.Cryptography;
using System.Text;
using Application.Exceptions;

namespace Application.Extensions;


public static class CryptoExtension {
    public static string EncryptString(this string value, string key = "u$Q2k9jIXGK2HasuJJDMnQTx6w&k82Kv") {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create()) {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
            using (StreamWriter streamWriter = new(cryptoStream)) {
                streamWriter.Write(value);
            }

            array = memoryStream.ToArray();
        }

        return Convert.ToBase64String(array);
    }


    public static string DecryptString(this string value, string key = "u$Q2k9jIXGK2HasuJJDMnQTx6w&k82Kv") {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(value);

        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = iv;
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream memoryStream = new(buffer);
        using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new(cryptoStream);
        return streamReader.ReadToEnd();
    }


    public static string EncryptGuid(this Guid value, string key = "u$Q2k9jIXGK2HasuJJDMnQTx6w&k82Kv") {
        return EncryptString(value.ToString(), key).UrlEncode();
    }


    public static Guid DecryptGuid(this string value, string key = "u$Q2k9jIXGK2HasuJJDMnQTx6w&k82Kv") {
        try {
            var string_id = DecryptString(value.UrlDecode(), key);
            return Guid.Parse(string_id);
        } catch (System.Exception) {

            throw new GuidDecryptionException();
        }

    }

}

