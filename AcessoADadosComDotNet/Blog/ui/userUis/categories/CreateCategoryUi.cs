using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.categories
{
    public static class CreateCategoryUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("------Nova Categoria-------");
            Console.WriteLine("---------------------------");

            var category = new Category();
            Console.WriteLine("Nome: ");
            category.Name = Console.ReadLine();
            Console.WriteLine("Slug: ");
            category.Slug = Console.ReadLine();

            Create(category);
            Console.ReadKey();
            Program.Load();
        }

        private static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Create(category);
                Console.WriteLine("Categoria cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}