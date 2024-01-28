using System.IO;
using System.Security.Cryptography;
using System.Text;
 
namespace Adesso.Dapr.Crypt.Service
{
public class EncryptionService
{
    private readonly byte[] _encryptionKey;
 
    public EncryptionService(string encryptionKey)
    {
        _encryptionKey = Encoding.UTF8.GetBytes(encryptionKey);
    }
 
    public string Encrypt(string plainText)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = _encryptionKey;
            aes.GenerateIV();
            var iv = aes.IV;
            using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
            using (var ms = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cryptoStream))
                {
                    sw.Write(plainText);
                }
                var encryptedBytes = ms.ToArray();
                return Convert.ToBase64String(iv) + ":" + Convert.ToBase64String(encryptedBytes);
            }
        }
    }
 
    public string Decrypt(string cipherText)
    {
        var parts = cipherText.Split(':');
        var iv = Convert.FromBase64String(parts[0]);
        var encryptedBytes = Convert.FromBase64String(parts[1]);
 
        using (var aes = Aes.Create())
        {
            aes.Key = _encryptionKey;
            aes.IV = iv;
            using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
            using (var ms = new MemoryStream(encryptedBytes))
            using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sr = new StreamReader(cryptoStream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
}