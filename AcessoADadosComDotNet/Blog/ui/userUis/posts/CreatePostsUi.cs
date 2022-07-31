using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.posts
{
    public static class CreatePostsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------Novo Post---------");
            Console.WriteLine("---------------------------");

            var post = new Post();
            Console.WriteLine("Nome: ");
            post.Title = Console.ReadLine();

            Console.WriteLine("Summary: ");
            post.Summary = Console.ReadLine();

            Console.WriteLine("Body: ");
            post.Body = Console.ReadLine();

            Console.WriteLine("Slug: ");
            post.Slug = Console.ReadLine();

            post.CreateDate = DateTime.Now;
            post.LastUpdateDate = DateTime.Now;

            Console.WriteLine("CategoryId: ");
            post.CategoryId = int.Parse(Console.ReadLine());

            Console.WriteLine("AuthorId: ");
            post.AuthorId = int.Parse(Console.ReadLine());

            Create(post);
            Console.ReadKey();
            Program.Load();
        }

        private static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.connection);
                repository.Create(post);
                Console.WriteLine("Post criado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel criar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}