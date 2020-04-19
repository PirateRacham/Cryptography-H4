using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

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
                4, Login
                5, Symmetrical encryption/decryption
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
                    case '4':
                        Login();
                        break;
                    case '5':
                        SymmetricalCrypt();
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
                HashingOPG.CheckIntegrity(value, result, previous);
            }

            Console.WriteLine("\nValue to be hashed:   " + result.NonHashedValue);
            Console.WriteLine("Hashed value:         " + result.HashedValue);
            Console.WriteLine("Hashed value in Hex:  " + result.HashedValueHex);
            if (x <=3)
            {
                Console.WriteLine("Hash time elapsed:    " + result.MilisecondsHash);
            }
            if (x >= 4)
            {
                Console.WriteLine("Hmac time elapsed:    " + result.Milisecondshmac);
                Console.WriteLine("HMAC key:             " + Convert.ToBase64String(result.HMACKey));
            }
            if (x == 5)
            {
                if (result.SafeIntegrity)
                {
                    WriteInMiddleOfScreen("strings match!!", ConsoleColor.Green);
                }
                else
                {
                    WriteInMiddleOfScreen("Strings dont match!!", ConsoleColor.Red);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            previous = result;
        }
        static void Login()
        {
            byte go = 0;
            while (go != 5)
            {
                go++;
                Console.WriteLine("\nPlease input username and password");
                Console.Write("\nUsername: ");
                string username = Console.ReadLine();
                
                string salt = H4_cryptography.Login.Login.GetUserSalt(username);

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.WriteLine("Trying to log in with user");
                Console.WriteLine("Username: " + username);
                Console.WriteLine("Password: " + password);
                Console.WriteLine("Salt:     " + salt);

                H4_cryptography.Login.User Dbuser = H4_cryptography.Login.Login.GetUser(username, password, salt);

                Console.WriteLine("\nFound user");
                Console.WriteLine("Username: " + Dbuser.Username);
                Console.WriteLine("Password: " + Dbuser.Password);
                Console.WriteLine("Salt:     " + Dbuser.Salt);

                if (Dbuser.success)
                {
                    WriteInMiddleOfScreen("SUCCESS", ConsoleColor.Green);
                    break;
                }
                else
                {
                    WriteInMiddleOfScreen("DENIED", ConsoleColor.Red);
                }
            }
            if (go == 6)
            {
                Console.WriteLine("you have tried too many times please try again");
            }
            Console.ReadKey();
        }
        static void SymmetricalCrypt()
        {

        }

        /// <summary>
        /// Wite text in middle of console window, with colour
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        static void WriteInMiddleOfScreen(string text, ConsoleColor color)
        {
            //save previous cursor position
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            //set cursor to middle of screen with space for text to be written
            Console.CursorLeft = (Console.WindowWidth - text.Length) / 2;
            Console.CursorTop = (Console.WindowHeight / 2) - 1;
            //write text with colour
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            //set cursor back at previous position
            Console.CursorTop = top;
            Console.CursorLeft = left;
        }
    }
}
