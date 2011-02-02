using System.Security.Cryptography;
using System.Text;

namespace CoolCode.Fx
{
    public class PasswordHash
    {
        private readonly string _salt;
        private readonly string _password;

        private string _value;

        public PasswordHash(string salt, string password)
        {
            _salt = salt;
            _password = password;
        }

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(_value))
                {
                    ComputeValue();
                }
                return _value;
            }
        }

        private void ComputeValue()
        {
            var toHash = _salt + _password;
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(toHash);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            _value = sb.ToString();
        }
    }
}