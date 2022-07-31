using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.categories
{
    public static class DeleteCategoryUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Deletar Categoria-----");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Id: ");
            var id = int.Parse(Console.ReadLine());

            Delete(id);
            Console.ReadKey();
            Program.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("Categoia excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluír a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}