using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.models;
using Blog.repositories;

namespace Blog.ui.userUis.roles
{
    public static class UpdateRolesUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Atualizar Perfil------");
            Console.WriteLine("---------------------------");

            var role = new Role();
            Console.WriteLine("Id: ");
            role.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome: ");
            role.Name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            role.Slug = Console.ReadLine();

            Delete(role);
            Console.ReadKey();
            Program.Load();
        }

        private static void Delete(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
                repository.Update(role);
                Console.WriteLine("Perfil atualizado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}