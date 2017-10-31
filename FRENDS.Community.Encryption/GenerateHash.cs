using Frends.Tasks.Attributes;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace FRENDS.Community.Encryption
{
    /// <summary>
    /// Input class
    /// </summary>
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

    /// <summary>
    /// Options class
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Generates input string to chosen HashAlgorithm type.
        /// </summary>
        [DefaultValue(Function.MD5)]
        public Function HashFunction { get; set; }
    }

    /// <summary>
    /// Result class
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Returns HashResult string
        /// </summary>
        public string Hash { get; set; }
    }

    /// <summary>
    /// Hash class
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Generates input string to chosen HashAlgorithm type.
        /// </summary>
        /// <param name="input">input string</param>
        /// <param name="options">Options for choosing HashAlgorithm type</param>
        /// <param name="cToken">Cancellation token checks if process cancellation has been requested</param>
        /// <returns>String</returns>
        public static Result GenerateHash(Input input, Options options, CancellationToken cToken)
        {
            cToken.ThrowIfCancellationRequested();

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
