using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.users
{
    public static class ListUserUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("---Listagem de Usuários----");
            Console.WriteLine("---------------------------");
            List();
            Console.ReadKey();
            Program.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.connection);
            var users = repository.Get();

            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}