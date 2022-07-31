using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.categories
{
    public static class ListCategoriesUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("---Listagem de Categorias--");
            Console.WriteLine("---------------------------");
            List();
            Console.ReadKey();
            Program.Load();
        }

        private static void List()
        {
            var repository = new Repository<Category>(Database.connection);
            var categories = repository.Get();

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}