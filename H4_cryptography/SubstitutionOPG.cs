using H4_cryptography.Substitution;
using System;

namespace H4_cryptography
{
    class SubstitutionOPG
    {
        public static string[] SubEncryption(string value)
        {
            string[] result = new string[2];
            result[0] = Encrypter.Encrypt(value);
            result[1] = Decrypter.Decrypt(result[0]);
            return result;
        }
    }
}
