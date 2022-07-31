using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.tags
{
    public static class UpdateTagsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("------Atualizar Tags-------");
            Console.WriteLine("---------------------------");

            var tag = new Tag();
            Console.WriteLine("Id: ");
            tag.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome: ");
            tag.Name = Console.ReadLine();
            Console.WriteLine("Slug: ");
            tag.Slug = Console.ReadLine();

            Update(tag);
            Console.ReadKey();
            Program.Load();
        }

        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}