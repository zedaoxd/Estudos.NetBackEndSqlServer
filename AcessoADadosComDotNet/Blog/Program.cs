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
            var user = new User(){
                Email = "test@test.com",
                Bio = "bio",
                Image = "image",
                Name = "Name",
                PasswordHash = "hash",
                Slug = "slug"
            };

            var connection = new SqlConnection(StringConnection.Connection);
            connection.Open();

            ReadUsers(connection);
            CreateUser(connection, user);
            // ReadRoles(connection);
            // ReadTags(connection);

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
    }
}
