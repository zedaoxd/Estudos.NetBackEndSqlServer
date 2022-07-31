using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.roles
{
    public static class CreateRolesUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-------Novo Perfil---------");
            Console.WriteLine("---------------------------");

            var role = new Role();
            Console.WriteLine("Nome: ");
            role.Name = Console.ReadLine();
            Console.WriteLine("Slug: ");
            role.Slug = Console.ReadLine();

            Create(role);
            Console.ReadKey();
            Program.Load();
        }

        private static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
                repository.Create(role);
                Console.WriteLine("Perfil cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}