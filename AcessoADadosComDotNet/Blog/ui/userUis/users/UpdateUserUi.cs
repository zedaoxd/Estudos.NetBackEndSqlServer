using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.users
{
    public static class UpdateUserUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Atualizar Usuário-----");
            Console.WriteLine("---------------------------");

            var user = new User();
            Console.WriteLine("Id: ");
            user.Id = int.Parse(Console.ReadLine());

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

            Update(user);
            Console.ReadKey();
            Program.Load();
        }

        private static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar a Usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}