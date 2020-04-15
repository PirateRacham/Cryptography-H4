using System;
using System.Collections.Generic;
using System.Text;

namespace H4_cryptography
{
    class Hashoperation
    {
        public long MilisecondsHash { get; set; }
        public long Milisecondshmac { get; set; }
        public byte[] HashedValueAsByte { get; set; }
        public string NonHashedValue { get; set; }
        public string HashedValue { get; set; }
        public bool SafeIntegrity { get; set; }
        public string HashedValueHex { get; set; }
        public byte[] HMACKey { get; set; }
        public Hashoperation()
        {
            SafeIntegrity = false;
        }
    }
}
