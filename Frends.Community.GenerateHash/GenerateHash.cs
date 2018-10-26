using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FRENDS.Community.GenerateHash
{
    public class Input
    {
        /// <summary>
        /// Input string to be hashed.
        /// </summary>
        [DefaultValue(@"foobar")]
        [DisplayFormat(DataFormatString = "Text")]
        public string InputString { get; set; }

        [DefaultValue("")]
        [UIHint(nameof(Function), "", Function.HMACSHA256)]
        [PasswordPropertyText]
        public string HashKey { get; set; }
    }

    /// <summary>
    /// Enum for choosing HashAlgorithm type
    /// </summary>
#pragma warning disable
    public enum Function { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512, HMACSHA256, HMACSHA512 }
#pragma warning restore


    public class Options
    {
        /// <summary>
        /// Generates input string to chosen HashAlgorithm type.
        /// </summary>
        [DefaultValue(Function.MD5)]
        public Function HashFunction { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// Returns HashResult string
        /// </summary>
        public string Hash { get; set; }
    }

    public class Hash
    {
        /// <summary>
        /// Calculates hash from input using selected algorithm.
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="options">Options for choosing HashAlgorithm type</param>
        /// <returns>Object {string Hash}</returns>
        public static Result GenerateHash(Input input, Options options)
        {
            HashAlgorithm hash;
            var result = new Result();
            byte[] bytes;

            if (options.HashFunction == Function.HMACSHA256 || options.HashFunction == Function.HMACSHA512)
            {
                var p = KeyedHashAlgorithm.Create("System.Security.Cryptography." + options.HashFunction);
                p.Key = Encoding.UTF8.GetBytes(input.HashKey);
                hash = p as HashAlgorithm;
            }
            else
            {
                hash = HashAlgorithm.Create("System.Security.Cryptography." + options.HashFunction);
            }

            bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(input.InputString));

            var sBuilder = new StringBuilder();
            bytes.ToList().ForEach(b => sBuilder.Append(b.ToString("x2")));
            result.Hash = sBuilder.ToString();
            return result;
        }
    }
}
