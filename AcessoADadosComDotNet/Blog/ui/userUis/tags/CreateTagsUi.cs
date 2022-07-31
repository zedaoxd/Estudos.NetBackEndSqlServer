using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis
{
    public static class CreateTagsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("--------Nova Tags----------");
            Console.WriteLine("---------------------------");

            var tag = new Tag();
            Console.WriteLine("Nome: ");
            tag.Name = Console.ReadLine();
            Console.WriteLine("Slug: ");
            tag.Slug = Console.ReadLine();

            Create(tag);
            Console.ReadKey();
            Program.Load();
        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}