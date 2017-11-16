using FRENDS.Community.GenerateHash;
using NUnit.Framework;
using System.Threading;

namespace FRENDS.Community.GenerateHash.Tests
{
    [TestFixture]
    class HashTests
    {
        Input input = new Input();
        Options options = new Options();
        Result result = new Result();

        [SetUp]
        public void Setup()
        {
            input.InputString = "foobar";
        }

        [Test]
        public void Hashes_SHA1()
        {
            options.HashFunction = Function.SHA1;
            result = Hash.GenerateHash(input, options, CancellationToken.None);
            Assert.AreEqual("8843d7f92416211de9ebb963ff4ce28125932878", result.Hash);
        }
        
        [Test]
        public void Hashes_SHA256()
        {
            options.HashFunction = Function.SHA256;
            result = Hash.GenerateHash(input, options, CancellationToken.None);
            Assert.AreEqual("c3ab8ff13720e8ad9047dd39466b3c8974e592c2fa383d4a3960714caef0c4f2", result.Hash);

        }
        [Test]
        public void Hashes_SHA384()
        {
            options.HashFunction = Function.SHA384;
            result = Hash.GenerateHash(input, options, CancellationToken.None);
            Assert.AreEqual("3c9c30d9f665e74d515c842960d4a451c83a0125fd3de7392d7b37231af10c72ea58aedfcdf89a5765bf902af93ecf06", result.Hash);
        }

        [Test]
        public void Hashes_SHA512()
        {
            options.HashFunction = Function.SHA512;
            result = Hash.GenerateHash(input, options, CancellationToken.None);
            Assert.AreEqual("0a50261ebd1a390fed2bf326f2673c145582a6342d523204973d0219337f81616a8069b012587cf5635f6925f1b56c360230c19b273500ee013e030601bf2425", result.Hash);
        }

        [Test]
        public void Hashes_MD5()
        {
            options.HashFunction = Function.MD5;
            result = Hash.GenerateHash(input, options, CancellationToken.None);
            Assert.AreEqual("3858f62230ac3c915f300c664312c63f", result.Hash);
        }

        [Test]
        public void Hashes_RipeMD160()
        {
            options.HashFunction = Function.RIPEMD160;
            result = Hash.GenerateHash(input, options, CancellationToken.None);
            Assert.AreEqual("a06e327ea7388c18e4740e350ed4e60f2e04fc41", result.Hash);
        }
    }
}
