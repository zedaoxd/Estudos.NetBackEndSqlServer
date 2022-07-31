using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.posts
{
    public static class UpdatePostUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-------Atualizar Post------");
            Console.WriteLine("---------------------------");

            var post = new Post();
            Console.WriteLine("Id: ");
            post.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Title: ");
            post.Title = Console.ReadLine();

            Console.WriteLine("Summary: ");
            post.Summary = Console.ReadLine();

            Console.WriteLine("Body: ");
            post.Body = Console.ReadLine();

            Console.WriteLine("Slug: ");
            post.Slug = Console.ReadLine();

            post.LastUpdateDate = DateTime.Now;

            Update(post);
            Console.ReadKey();
            Program.Load();
        }

        private static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.connection);
                repository.Update(post);
                Console.WriteLine("Post atualizado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possivel atualizar o post {post.LastUpdateDate:dd/MM/yyyy}");
                Console.WriteLine(ex.Message);
            }
        }
    }
}