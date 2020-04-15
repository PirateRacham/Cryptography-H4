using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;

namespace H4_cryptography
{
    class HashingOPG
    {
        private static Stopwatch watch;
        public static Hashoperation Hash(string value, int hashtype, Hashoperation result)
        {
            result.NonHashedValue = value;
            switch (hashtype)
            {
                case 1:
                    return hash1(value, result);
                case 2:
                    return hash256(value, result);
                case 3:
                    return hash512(value, result);
                case 4:
                    return HMAC(value, result);
                default:
                    return null;
            }
        }
        public static Hashoperation CheckIntegrity(string value, Hashoperation result, Hashoperation first)
        {
            result = HMAC(value, result, first.HMACKey);
            result.SafeIntegrity = CompareByteArray(first.HashedValueAsByte, result.HashedValueAsByte);
            return result;
        }
        private static Hashoperation hash1(string value, Hashoperation result)
        {
            watch = Stopwatch.StartNew();
            using (var sha1 = SHA1.Create())
            {
                byte[] hashedvalue = sha1.ComputeHash(Encoding.ASCII.GetBytes(value));
                result.HashedValue = Encoding.ASCII.GetString(hashedvalue);
                result.HashedValueHex = BitConverter.ToString(hashedvalue).Replace("-", string.Empty);
                result.HashedValueAsByte = hashedvalue;
            }
            watch.Stop();
            result.MilisecondsHash = watch.ElapsedMilliseconds;
            return result;
        }
        private static Hashoperation hash256(string value, Hashoperation result)
        {
            watch = Stopwatch.StartNew();
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedvalue = sha256.ComputeHash(Encoding.ASCII.GetBytes(value));
                result.HashedValue = Encoding.ASCII.GetString(hashedvalue);
                result.HashedValueHex = BitConverter.ToString(hashedvalue).Replace("-", string.Empty);
                result.HashedValueAsByte = hashedvalue;
            }
            watch.Stop();
            result.MilisecondsHash = watch.ElapsedMilliseconds;
            return result;
        }
        private static Hashoperation hash512(string value, Hashoperation result)
        {
            watch = Stopwatch.StartNew();
            using (var sha512 = SHA1.Create())
            {
                byte[] hashedvalue = sha512.ComputeHash(Encoding.ASCII.GetBytes(value));
                result.HashedValue = Encoding.ASCII.GetString(hashedvalue);
                result.HashedValueHex = BitConverter.ToString(hashedvalue).Replace("-", string.Empty);
                result.HashedValueAsByte = hashedvalue;
            }
            watch.Stop();
            result.MilisecondsHash = watch.ElapsedMilliseconds;
            return result;
        }

        private static Hashoperation HMAC(string value, Hashoperation result)
        {
            watch = Stopwatch.StartNew();
            using (HMAC hmac = new HMACSHA512())
            {
                
                byte[] hashedvalue = hmac.ComputeHash(Encoding.ASCII.GetBytes(value));
                result.HashedValue = Encoding.ASCII.GetString(hashedvalue);
                result.HashedValueHex = BitConverter.ToString(hashedvalue).Replace("-", string.Empty);
                result.HashedValueAsByte = hashedvalue;
                result.HMACKey = hmac.Key;
            }
            watch.Stop();
            result.Milisecondshmac = watch.ElapsedMilliseconds;
            return result;
        }
        private static Hashoperation HMAC(string value, Hashoperation result, byte[] key)
        {
            watch = Stopwatch.StartNew();
            using (HMAC hmac = new HMACSHA512())
            {
                hmac.Key = key;
                byte[] hashedvalue = hmac.ComputeHash(Encoding.ASCII.GetBytes(value));
                result.HashedValue = Encoding.ASCII.GetString(hashedvalue);
                result.HashedValueHex = BitConverter.ToString(hashedvalue).Replace("-", string.Empty);
                result.HashedValueAsByte = hashedvalue;
                result.HMACKey = hmac.Key;
            }
            watch.Stop();
            result.Milisecondshmac = watch.ElapsedMilliseconds;
            return result;
        }
        
        private static bool CompareByteArray(byte[] first, byte[] second)
        {
            for (int i = 0; i < first.Length - 1; i++)
                if (first[i] != second[i])
                    return false;
            return true;
        }

    }
}
