#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace FRENDS.Community.GenerateHash
{
    /// <summary>
    /// Required parameters
    /// </summary>
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



    /// <summary>
    /// Additional options
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
    /// Return value
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Returns HashResult string
        /// </summary>
        public string Hash { get; set; }
    }
}
