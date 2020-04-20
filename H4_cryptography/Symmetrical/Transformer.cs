using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace H4_cryptography.Symmetrical
{
    class Transformer
    {
        internal static byte[] Convert(byte[] value, ICryptoTransform ct)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                {
                    cs.Write(value, 0, value.Length);
                }
                return ms.ToArray();
            }
        }
    }
}
