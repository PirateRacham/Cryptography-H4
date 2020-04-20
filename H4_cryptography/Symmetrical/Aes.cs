namespace H4_cryptography.Symmetrical
{
    class Aes : SymmetricEncryptor
    {
        public Aes() : base("AES", System.Security.Cryptography.Aes.Create())
        { }
    }
}