using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.users
{
    public static class DeleteUserUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("----Deletar um usuário-----");
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
                var repository = new Repository<User>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluido com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel deletar a Usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}