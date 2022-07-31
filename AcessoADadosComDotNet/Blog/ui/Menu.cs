using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.models;
using Blog.repositories;
using Microsoft.Data.SqlClient;

namespace Blog.ui
{
    public static class Menu
    {
        public static void LoopMenu()
        {
            
            while (true)
            {
                var option = OptionChoice();
                if (option == 0)
                    break;
                
                switch (option)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        CreateRole();
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
               
            }
        }

        private static int OptionChoice()
        {
            Console.Clear();
            Console.WriteLine("+-----------------------+");
            Console.WriteLine("+[1] Cadastrar usuario  +");
            Console.WriteLine("+[2] Cadastrar perfil   +");
            //Console.WriteLine("+[1] Cadastrar usuario  +");
            //Console.WriteLine("+[1] Cadastrar usuario  +");
            Console.WriteLine("+[0] Sair               +");
            Console.WriteLine("+-----------------------+");

            return Convert.ToInt32(Console.ReadLine());
        }

        private static void CreateUser()
        {
            var user = new User();

            Console.Clear();
            Console.WriteLine("+-----Criação de Usuário----+");

            Console.Write("Nome: ");
            user.Name = Console.ReadLine();

            Console.Write("E - mail: ");
            user.Email = Console.ReadLine();

            Console.Write("Password Hash: ");
            user.PasswordHash = Console.ReadLine();

            Console.Write("Bio: ");
            user.Bio = Console.ReadLine();

            Console.Write("Link Image: ");
            user.Image = Console.ReadLine();

            Console.Write("Slug: ");
            user.Slug = Console.ReadLine();

            Console.WriteLine("+--------------------------+");
            
            using(var connection = new SqlConnection(StringConnection.Connection))
            {
                var repository = new Repository<User>(connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado!");
                Thread.Sleep(2000);
            }
        }

        private static void CreateRole()
        {
            var role = new Role();
            Console.Clear();
            Console.WriteLine("+----- Criação de Perfil ----+");

            Console.Write("Nome: ");
            role.Name = Console.ReadLine();

            Console.Write("Slug: ");
            role.Slug = Console.ReadLine();

            Console.WriteLine("+--------------------------+");

            using(var connection = new SqlConnection(StringConnection.Connection))
            {
                var repository = new Repository<Role>(connection);
                repository.Create(role);
                Console.WriteLine("Perfil Criado!");
                Thread.Sleep(2000);
            }
        }
    }
}