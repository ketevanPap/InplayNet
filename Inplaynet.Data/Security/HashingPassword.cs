using System.Security.Cryptography;
using System.Text;

namespace Inplaynet.Data.Security
{
    public class HashingPassword
    {
        public  void CreatePasswordHash(string password, out byte[] passworHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passworHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordSalt = hmac.Key;
        }
    }
}
