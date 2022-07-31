using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.categories
{
    public static class UpdateCategoryUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("----Atualizar Categoria----");
            Console.WriteLine("---------------------------");

            var category = new Category();
            Console.WriteLine("Id: ");
            category.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome: ");
            category.Name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            category.Slug = Console.ReadLine();

            Delete(category);
            Console.ReadKey();
            Program.Load();
        }

        private static void Delete(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}