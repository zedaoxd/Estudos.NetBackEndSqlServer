using System;
using Blog.models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadUsers();
        }

        public static void ReadUsers()
        {
            using (var conection = new SqlConnection(StringConnection.Connection))
            {
                var users = conection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}
