using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.posts
{
    public static class DeletePostUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("------Deletar um post------");
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
                var repository = new Repository<Post>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("Post excluido com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel deletar a Post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}