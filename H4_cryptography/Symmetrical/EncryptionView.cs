using System;
using System.Collections.Generic;
using System.Text;

namespace H4_cryptography.Symmetrical
{
    class EncryptionView
    {
        public int ChooseAction(string key, string iv, string algo)
        {
            Console.Clear();
            Console.WriteLine("Key: " + key + "    IV: " + iv + "   Algorithm: " + algo);
            Console.WriteLine(@"
                1, Encrypt
                2, Decrypt
                3, Set Key
                4, Set IV
                5, Choose algorithm
                ");
            return int.Parse(Console.ReadKey().KeyChar.ToString());
        }
        public string Encrypt()
        {
            Console.Write("Please input Text to be encrypted: ");
            return Console.ReadLine();
        }
        public string Decrypt()
        {
            Console.Write("Please input text to be decrypted: ");
            return Console.ReadLine();
        }
        public void EncryptResult(string text, long time)
        {
            Console.WriteLine("Encrypted: " + text);
            Console.WriteLine("time spend in miliseconds: " + time);
            Console.ReadKey();
        }
        public void DecryptResult(string text, long time)
        {
            Console.WriteLine("Decrypted: " + text);
            Console.WriteLine("time spend in miliseconds: " + time);
            Console.ReadKey();
        }
        public int ChooseAlgorithm()
        {
            Console.WriteLine(@"
                1, DES
                2, TripleDes
                3, AES
                ");
            return int.Parse(Console.ReadKey().KeyChar.ToString());
        }
        public String SetKey()
        {
            Console.Write("Please input Key to be used: ");
            return Console.ReadLine();
        }
        public String SetIV()
        {
            Console.Write("Please input IV to be used: ");
            return Console.ReadLine();
        }
    }
}
