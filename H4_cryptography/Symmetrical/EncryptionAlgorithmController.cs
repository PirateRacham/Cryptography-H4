using System;
using System.Text;

namespace H4_cryptography.Symmetrical
{
    class EncryptionAlgorithmController
    {
        private IEncryptionAlgorithm Algorithm { get; set; }
        public byte[] Key { get => Algorithm?.Key ?? new byte[2]; }
        public byte[] Iv { get => Algorithm?.IV ?? new byte[2]; }
        public string algoname { get => Algorithm?.Name ?? " "; }

        public string Encrypt(string text)
        {
            return Convert.ToBase64String(Algorithm.Encrypt(Encoding.ASCII.GetBytes(text)));
        }
        public string Decrypt(string text)
        {
            return Encoding.ASCII.GetString(Algorithm.Decrypt(Convert.FromBase64String(text)));
        }
        public void SetKey(string key)
        {
            Algorithm.SetKey(Encoding.ASCII.GetBytes(key));
        }
        public void SetIV(string IV)
        {
            Algorithm.SetKey(Encoding.ASCII.GetBytes(IV));
        }
        public void ChooseAlgorithm(int algorithm)
        {
            switch (algorithm)
            {
                case 1:
                    this.Algorithm = new Des();
                    break;
                case 2:
                    this.Algorithm = new TripleDes();
                    break;
                case 3:
                    this.Algorithm = new Aes();
                    break;
                default:
                    break;
            }
        }

    }
}
