using Frends.Tasks.Attributes;
using System.ComponentModel;
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
        [DefaultDisplayType(DisplayType.Text)]
        public string InputString { get; set; }
    }

    /// <summary>
    /// Enum for choosing HashAlgorithm type
    /// </summary>
#pragma warning disable
    public enum Function { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 }
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
            var result = new Result();
            var hash = HashAlgorithm.Create("System.Security.Cryptography." + options.HashFunction);
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(input.InputString));

            var sBuilder = new StringBuilder();
            bytes.ToList().ForEach(b => sBuilder.Append(b.ToString("x2")));
            result.Hash = sBuilder.ToString();
            return result;
        }
    }
}
