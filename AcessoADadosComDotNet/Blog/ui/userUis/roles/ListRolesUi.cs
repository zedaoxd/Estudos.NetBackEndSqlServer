using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.roles
{
    public static class ListRolesUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("----Listagem de Perfis-----");
            Console.WriteLine("---------------------------");
            List();
            Console.ReadKey();
            Program.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.connection);
            var roles = repository.Get();

            foreach (var item in roles)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}