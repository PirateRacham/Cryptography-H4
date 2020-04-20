using System.Security.Cryptography;
using System.Text;

namespace H4_cryptography.Symmetrical
{
    abstract class SymmetricEncryptor : IEncryptionAlgorithm
    {
        public string Name { get; }

        public byte[] IV => Algorithm.IV;

        public byte[] Key => Algorithm.Key;
        protected SymmetricAlgorithm Algorithm {  get;  set; }
        public SymmetricEncryptor(string name, SymmetricAlgorithm algorithm)
        {
            this.Name = name;
            Algorithm = algorithm;
            GenKeys();
        }
        public byte[] Decrypt(byte[] text)
        {
            return Transformer.Convert(text, Algorithm.CreateDecryptor());
        }

        public byte[] Encrypt(byte[] text)
        {
            return Transformer.Convert(text, Algorithm.CreateEncryptor());
        }

        private void GenKeys()
        {
            Algorithm.GenerateKey();
            Algorithm.GenerateIV();
        }

        public void SetIV(byte[] value)
        {
            Algorithm.IV = value;
        }

        public void SetKey(byte[] value)
        {
            Algorithm.Key = value;
        }
    }
}
