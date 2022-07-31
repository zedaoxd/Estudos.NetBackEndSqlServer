using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.users
{
    public static class CreateUserUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-------Novo Usuário--------");
            Console.WriteLine("---------------------------");

            var user = new User();
            Console.WriteLine("Nome: ");
            user.Name = Console.ReadLine();

            Console.WriteLine("Email: ");
            user.Email = Console.ReadLine();

            Console.WriteLine("Password: ");
            user.PasswordHash = Console.ReadLine();

            Console.WriteLine("Bio: ");
            user.Bio = Console.ReadLine();

            Console.WriteLine("Link da imagem: ");
            user.Image = Console.ReadLine();

            Console.WriteLine("Slug: ");
            user.Slug = Console.ReadLine();

            Create(user);
            Console.ReadKey();
            Program.Load();
        }

        private static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}