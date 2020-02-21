using System;
using System.IO;
using ChainExplorer.Reader;
using ChainExplorer.Script.StackCalculator;
using NUnit.Framework;
using Secp256k1Net;

namespace ChainExplorerTests
{
    public class Secp256K1HelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("")]
        public void should_validate_script()
        {
            var hexReader = new HexReader();
            var calculator = new Calculator();
            
            var pubkey = "76a9145e4ff47ceb3a51cdf7ddd80afc4acc5a692dac2d88ac";

            var scriptkey =
                "483045022074f35af390c41ef1f5395d11f6041cf55a6d7dab0acdac8ee746c1f2de7a43b3022100b3dc3d916b557d378268a856b8f9a98b9afaf45442f5c9d726fce343de835a58012102c34538fc933799d972f55752d318c0328ca2bacccd5c7482119ea9da2df70a2f";

            var hexScript = scriptkey + pubkey;

            var scriptFinal = hexReader.ToByteArray(hexScript);

            var res = calculator.Compute(scriptFinal);

        }

        [Test]
        [Ignore("")]
        public void should_construct_transaction()
        {
            // arrange
            var trx =
                "010000000001010000000000000000000000000000000000000000000000000000000000000000ffffffff5f038b5c0904e614245e2f706f6f6c696e2e636f6d2ffabe6d6d29ad483008e6afa933b7248433f8dccc7fe02301022e4a3271eaf3bd3210f3160100000000000000c10db97992756fa5c7fb1a07acf5a834104995aa2f008ab8000000000000ffffffff04e25f2b4b000000001976a914e0ad60c897901128662623c500a4a6079e99cd3e88ac0000000000000000266a24b9e11b6dcffd93e719c6cbccf1b271ba8e2920c2a3a9fa8b1aabca5fef2a7fc282ce898f0000000000000000266a24aa21a9eda8657fc67746fd56ac874234c52b766fb63ab9b090d5281a5c602d3dfd9ddef900000000000000002b6a2952534b424c4f434b3ac2e0675c8a11c2290b5e471ed155dde2048c83d2e00b4304ca5a7c21001f3b3e012000000000000000000000000000000000000000000000000000000000000000002fa1d41e";
            
            var trxbytes = new HexReader().ToByteArray(trx);
            var loggedBinaryReader = new LoggedBinaryReader(new MemoryStream(trxbytes));
            
            // act
            var realTransaction = new BitcoinReader(new HexReader()).ReadTransaction( loggedBinaryReader);
            
            // assert
            
        }


        [Test]
        [Ignore("")]
        public void should_verify_pizza_transaction_ec()
        {
            
            var hexReader = new HexReader();
            var secp256K1 = new Secp256k1();

            
            // https://bitcoin.stackexchange.com/questions/32305/how-does-the-ecdsa-verification-algorithm-work-during-transaction
            var digest = "692678553d1b85ccf87d4d4443095f276cdf600f2bb7dd44f6effbd7458fd4c2";
            
            var signature =
                "30450221009908144ca6539e09512b9295c8a27050d478fbb96f8addbc3d075544dc41328702201aa528be2b907d316d2da068dd9eb1e23243d97e444d59290d2fddf25269ee0e01";
            
            var pubkey =
                "042e930f39ba62c6534ee98ed20ca98959d34aa9e057cda01cfd422c6bab3667b76426529382c23f42b9b08d7832d4fee1d6b437a8526e59667ce9c4e9dcebcabb";
            


            var bData = hexReader.ToByteArray(digest);
            var bSignature = hexReader.ToByteArray(signature);
            var bPubKey = hexReader.ToByteArray(pubkey);
            

            
            var res = secp256K1.Verify(bSignature.AsSpan(), bData.AsSpan(), bPubKey);

            
        }
        
        [Test]
        [Ignore("")]
        public void should_verify_signature()
        {
            var hexReader = new HexReader();
            var secp256K1 = new Secp256k1();
                
            // https://www.blockchain.com/btc/tx/9f3eca62d13c2e7bf104a8539f5768674d551ecc140f3bb9bdaf3f07d6d3f6de
            // 15RpkAiu17FiYJmMiTJBvEwNQQdgEr1KvK
            // 1HvRorjpF5wyY7To5QhgJDzB3C9nEPcMo1 
            var data = "9f3eca62d13c2e7bf104a8539f5768674d551ecc140f3bb9bdaf3f07d6d3f6de";
            
            var signature =
                "3046022100a7a1bfc118676e8dc1779a6c6dfaece6435ca20e8e2fcf4399300cc930c791e00221009a88d6a51b763fa748254fc487710998c9572bc2f01be06d1a7532c8e38a4c1901";
            
            var pubkey = "03a5cc256133f721c66201b54f18f08053b6fc62f3dfc84c43a3a2d1c87afbe30c";
            
            var bData = hexReader.ToByteArray(data);
            var bSignature = hexReader.ToByteArray(signature);
            var bPubKey = hexReader.ToByteArray(pubkey);

            var output = new Span<byte>(new byte[66]);
            
            var normalize = secp256K1.PublicKeyParse(output, bPubKey);
            
            var res = secp256K1.Verify(bSignature.AsSpan(), bData.AsSpan(), output);
            
            Console.WriteLine(res);
        
        }
    }
}