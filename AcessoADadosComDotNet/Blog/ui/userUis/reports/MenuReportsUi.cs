using System;
using Blog.repositories;

namespace Blog.ui.userUis.reports
{
    public static class MenuReportsUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("---------Relatórios--------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] Listar os usuários separados por perfis");
            // Console.WriteLine("[2] Cadastrar usuário");
            // Console.WriteLine("[3] Atualizar usuário");
            // Console.WriteLine("[4] Excluir usuário");
            Console.WriteLine("\n\n");

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListUserRole();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                    default:
                        Load();
                        break;
                }
            }
            catch
            {
                Program.Load();
            }
        }

        private static void ListUserRole()
        {
            Console.Clear();
            var repository = new UserRepository(Database.connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) 
                    Console.WriteLine($" - {role.Name}");
            }
            Console.ReadKey();
        }
    }
}