using System;
using System.Security.Cryptography;
using System.Text;

namespace H4_cryptography
{
    class Program
    {
        static Random random = new Random();

        static RandomNumberGenerator cryptoRan = RandomNumberGenerator.Create();
        static Hashoperation previous = new Hashoperation();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
                1, Benchmark System.Random and RandomNumberGenerator
                2, Substitution crytography
                3, Hash
                ");
                 ConsoleKeyInfo x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        RandomBenchmark();
                        break;
                    case '2':
                        SubstitutionCrypto();
                        break;
                    case '3':
                        Hash();
                        break;
                    default:
                        Console.WriteLine("Error: Please try again");
                        break;
                }
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
        }

        static void RandomBenchmark()
        {
            Console.WriteLine("Random Benchmark");
            Console.Write("Input number of itterations: ");
            string itteration = Console.ReadLine();
            TimeRandomOPG timeRandom = new TimeRandomOPG(random, cryptoRan, Int32.Parse(itteration));
            Console.WriteLine(itteration + " runs of system.random took: " + timeRandom.randomTime + " milliseconds");
            Console.WriteLine(itteration + " runs of RandomNumberGenerator took: " + timeRandom.randomNumberGeneratorTime + " milliseconds");
        }

        static void SubstitutionCrypto()
        {
            Console.WriteLine("Substitution Cryptography");
            Console.WriteLine("Input text to be encryptet");
            string[] t = SubstitutionOPG.SubEncryption(Console.ReadLine());
            Console.WriteLine("Encryptet text: " + t[0]);
            Console.WriteLine("Decryptet text: " + t[1]);
            
        }
        static void Hash()
        {
            Console.Clear();
            // To use check integrity you have to first HASH someting with HMAC which you can then check against with check integrity
            Console.WriteLine(@" Hashing
                1, sha1
                2, sha256
                3, sha512
                4, HMAC
                5, check integrity
                ");
            int x = Int32.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine("\nInput value to be hashed");
            Hashoperation result = new Hashoperation();
            string value = Console.ReadLine();
            if (x != 5)
            {
                HashingOPG.Hash(value, x, result);
            }
            else
            {
                Console.WriteLine("previous nonhash" + previous.NonHashedValue);
                HashingOPG.CheckIntegrity(value, result, previous);
            }

            Console.WriteLine("\nValue to be hashed: " + result.NonHashedValue);
            Console.WriteLine("Hashed value: " + result.HashedValue);
            Console.WriteLine("Hashed value in Hex: " + result.HashedValueHex);
            if (x >=3)
            {
                Console.WriteLine("Hash time elapsed: " + result.MilisecondsHash);
            }
            if (x <= 4)
            {
                Console.WriteLine("Hmac time elapsed: " + result.Milisecondshmac);
                Console.WriteLine("Total time used: " + (result.Milisecondshmac + result.MilisecondsHash));
                Console.WriteLine("HMAC key: " + Encoding.ASCII.GetString(result.HMACKey));
            }
            if (x == 5)
            {
                if (result.SafeIntegrity)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("strings match!!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Strings dont match!!");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            previous = result;
        }

    }
}
