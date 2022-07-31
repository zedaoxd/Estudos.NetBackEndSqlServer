using System;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.roles
{
    public static class DeleteRolesUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("------Deletar Perfil-------");
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
                var repository = new Repository<Role>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("Perfil excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluír o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}