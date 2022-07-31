using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis
{
    public static class ListTagsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Listagem de Tags------");
            Console.WriteLine("---------------------------");
            List();
            Console.ReadKey();
            Program.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.connection);
            var tags = repository.Get();

            foreach (var item in tags)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}