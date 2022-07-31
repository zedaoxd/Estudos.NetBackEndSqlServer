using System;
using Blog.models;
using Blog.repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(StringConnection.Connection);
            connection.Open();

            //ReadUsers(connection);
            //ReadRoles(connection);
            var repository = new UserRepository(connection);

            var user = new User(){
                Name = "teste",
                Email = "teste",
                PasswordHash = "teste",
                Bio = "teste",
                Image = "teste",
                Slug = "teste"
            };

            repository.Delete(4);

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.Get();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }
    }
}
