using System.Text;
using Application.Interfaces.Service.Hash;
using Org.BouncyCastle.Crypto.Digests;

namespace Infrastructure.Services.Hash;


public class HashService : IHashService {

    public string GetHashSha3_512(string text) {
        var hashAlgorithm = new Sha3Digest(512);
        try {
            byte[] input = Encoding.UTF8.GetBytes(text);
            hashAlgorithm.BlockUpdate(input, 0, input.Length);
            byte[] result = new byte[64]; // 512 / 8 = 64
            hashAlgorithm.DoFinal(result, 0);
            string hashString = BitConverter.ToString(result);
            return hashString.Replace("-", "").ToLowerInvariant();
        } catch (System.Exception) {
            return "";
        }
    }
}
