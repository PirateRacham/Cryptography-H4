using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace H4_cryptography.Login
{
    static class Login
    {
        private static Dal dal { get; set; }
        static Login()
        {
            dal = new Dal();
        }
        public static User GetUser(string username, string password, string salt)
        {
            User user = new User();

            user.Username = username;
            user.Password = password;
            user = MultiHash(user);
            User dbuser = dal.GetUser(user);
            if (dbuser != null)
            {
                user.success = UserIsUser(user, dbuser);
            }
            return user;
        }

        private static User MultiHash(User user)
        {
            if (string.IsNullOrEmpty(user.Salt))
            {
                byte[] salt = new byte[12];
                RandomNumberGenerator.Create().GetBytes(salt);
                user.Salt = Convert.ToBase64String(salt);

            }

            using (Rfc2898DeriveBytes hashgenerator = new Rfc2898DeriveBytes(user.Password, Encoding.ASCII.GetBytes(user.Salt)))
            {
                hashgenerator.IterationCount = 20;
                user.Password = Convert.ToBase64String(hashgenerator.GetBytes(64));
            }
            return user;

        }

        private static bool UserIsUser(User user, User user2)
        {
            if (user.Password.Equals(user2.Password) && user.Username.Equals(user2.Username))
            {
                if (CompareByteArray(Encoding.ASCII.GetBytes(user2.Password), Encoding.ASCII.GetBytes(user.Password)))
                {
                    return CompareByteArray(Encoding.ASCII.GetBytes(user2.Salt), Encoding.ASCII.GetBytes(user.Salt));
                }
            }
            return false;
        }

        public static string GetUserSalt(string username)
        {
            return dal.GetUserSalt(username);
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
