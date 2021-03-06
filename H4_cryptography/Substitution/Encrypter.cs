﻿using System;
using System.Collections.Generic;
using System.Text;

namespace H4_cryptography.Substitution
{
    class Encrypter
    {
        private static char[] arr1 = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                    'u', 'v', 'w', 'x', 'y', 'z' };
        private static char[] arr2 = new char[26] {'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
                                    'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                                    'h', 'i', 'j', 'k', 'l', 'm' };

        public static string Encrypt(string value)
        {
            string cryptet = "";
            foreach (Char item in value)
            {
                cryptet = cryptet + arr2.GetValue(Array.IndexOf(arr1, item)).ToString();
            };

            return cryptet;
        }
    }
}
