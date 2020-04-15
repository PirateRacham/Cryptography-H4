using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;

namespace H4_cryptography
{
    class TimeRandomOPG
    {
        Random random;
        RandomNumberGenerator cryptoran;
        static byte[] buffer = new byte[4];
        static Stopwatch stopwatch;
        int itteration;
        public long randomTime;
        public long randomNumberGeneratorTime;
        public TimeRandomOPG(Random random, RandomNumberGenerator cryptoran, int itteration)
        {
            this.random = random;
            this.cryptoran = cryptoran;
            this.itteration = itteration;
            TimeRandom();
        }
        void TimeRandom()
        {
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < itteration; i++)
            {
                int r = Random();
                int t = r + 1; 
            }
            stopwatch.Stop();
            randomTime = stopwatch.ElapsedMilliseconds;
            //Console.WriteLine("8000 runs of system.random took: " + stopwatch.ElapsedMilliseconds); // 1000 + " seconds");
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < itteration; i++)
            {
                int r = CryptoRandom();
                int t = r + 1; 
            }
            stopwatch.Stop();
            randomNumberGeneratorTime = stopwatch.ElapsedMilliseconds;
            
        }

        int Random()
        {
            return random.Next();
        }

        int CryptoRandom()
        {
            cryptoran.GetBytes(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

    }
}
