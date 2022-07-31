﻿using System;
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

            ReadUsers(connection);

            connection.Close();


            //GetUser(1);

            // var user = new User()
            // {
            //     Id = 2,
            //     Bio = "Students style",
            //     Email = "student@gmail.com",
            //     Image = "https://",
            //     Name = "Student",
            //     PasswordHash = "HASH",
            //     Slug = "student-time"
            // };
            //CreateUser(user);

            //UpdateUser(user);

            //DeleteUser(user);
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void GetUser(int id)
        {
            using (var conection = new SqlConnection(StringConnection.Connection))
            {
                var user = conection.Get<User>(id);
                Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser(User user)
        {
            using (var conection = new SqlConnection(StringConnection.Connection))
            {
                conection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso");
            }
        }

        public static void UpdateUser(User user)
        {
            using (var conection = new SqlConnection(StringConnection.Connection))
            {
                conection.Update<User>(user);
                Console.WriteLine("Cadastro atualizado com sucesso");
            }
        }

        public static void DeleteUser(User user)
        {
            using (var conection = new SqlConnection(StringConnection.Connection))
            {
                conection.Delete<User>(user);
                Console.WriteLine("Usuário excluido com sucesso");
            }
        }
    }
}
