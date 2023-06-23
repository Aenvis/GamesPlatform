using System.Security.Cryptography;
using System.Text;

namespace GamesPlatform.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private const int Pbkdf2IterationsCount = 10000;
        private const int SaltSize = 40;

        public string GetSalt()
        {
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Cannot generate hash from a null or empty value.", nameof(value));
            }
            if (String.IsNullOrEmpty(salt))
            {
                throw new ArgumentException("Cannot use a null or empty salt from hashing value.", nameof(salt));
            }

            var passwordBytes = Encoding.UTF8.GetBytes(value);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var hashAlgorithmName = HashAlgorithmName.SHA1;
            var hashLength = 20;
            var pbkdf2 = Rfc2898DeriveBytes.Pbkdf2(passwordBytes, saltBytes, Pbkdf2IterationsCount, hashAlgorithmName, hashLength);

            return Convert.ToBase64String(pbkdf2);
        }
    }
}
