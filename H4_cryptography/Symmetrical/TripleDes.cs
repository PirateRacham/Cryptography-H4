namespace H4_cryptography.Symmetrical
{
    class TripleDes : SymmetricEncryptor
    {
        public TripleDes() : base("3DES", System.Security.Cryptography.TripleDES.Create())
        { }
    }
}