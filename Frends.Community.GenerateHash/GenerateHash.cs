using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable 1591

namespace FRENDS.Community.GenerateHash
{
    public class Hash
    {
        /// <summary>
        /// Calculates hash from input using selected algorithm. See: https://github.com/CommunityHiQ/Frends.Community.GenerateHash
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
