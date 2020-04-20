namespace H4_cryptography.Symmetrical
{
    class Des : SymmetricEncryptor
    {
        public Des() : base ("DES", System.Security.Cryptography.DES.Create())
        { }
    }
}
