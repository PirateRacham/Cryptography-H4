using System;
using System.Collections.Generic;
using System.Text;

namespace H4_cryptography.Symmetrical
{
    interface IEncryptionAlgorithm
    {
        public string Name { get;}
        public byte[] IV { get; }
        public byte[] Key { get; }
        byte[] Encrypt(byte[] text);
        byte[] Decrypt(byte[] text);
        void SetKey(byte[] value);
        void SetIV(byte[] value);
    }
}
