using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace H4_cryptography.Login
{
    class Dal
    {
        public User GetUser(User user)
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.Connectionstring);
            try
            {
                conn.Open();
                string cmdText = "SELECT username, password, salt FROM user WHERE username='" + user.Username + "'";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Password = (string)reader[1];
                        user.Salt = (string)reader[2];
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return user;
        }
        public string GetUserSalt(string username)
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.Connectionstring);
            try
            {
                conn.Open();
                string cmdText = "SELECT username, password, salt FROM user WHERE username='" + username + "'";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (string)reader[2];
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return "";
        }
    }
}
