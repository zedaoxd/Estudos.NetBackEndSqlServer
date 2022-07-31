using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis
{
    public static class DeleteTagsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Deletar uma Tag-------");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());

            Delete(id);
            Console.ReadKey();
            Program.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("Tag excluida com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel deletar a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}