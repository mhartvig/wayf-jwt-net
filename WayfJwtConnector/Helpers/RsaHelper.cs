using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace WayfJwtConnector.Helpers
{
    internal sealed class RsaHelper
    {
        public static RsaSecurityKey IssuerSigningKey(string publicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            var keyBytes = Convert.FromBase64String(publicKey);
            var asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
            var rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            var rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };

            rsa.ImportParameters(rsaParameters);
            var key = new RsaSecurityKey(rsa);
            return key;
        }

    }
}
