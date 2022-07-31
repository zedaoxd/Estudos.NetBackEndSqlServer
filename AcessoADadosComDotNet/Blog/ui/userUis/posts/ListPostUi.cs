using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.posts
{
    public static class ListPostUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Listagem de Post------");
            Console.WriteLine("---------------------------");
            List();
            Console.ReadKey();
            Program.Load();
        }

        private static void List()
        {
            var repository = new Repository<Post>(Database.connection);
            var posts = repository.Get();

            foreach (var item in posts)
            {
                Console.WriteLine($"{item.Id} - {item.Title} ({item.Slug})");
            }
        }
    }
}