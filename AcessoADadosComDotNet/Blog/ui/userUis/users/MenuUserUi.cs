using System;

namespace Blog.ui.userUis.users
{
    public static class MenuUserUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Gestão de usuário-----");
            Console.WriteLine("---------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] Listar usuários");
            Console.WriteLine("[2] Cadastrar usuário");
            Console.WriteLine("[3] Atualizar usuário");
            Console.WriteLine("[4] Excluir usuário");
            Console.WriteLine("\n\n");

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListUserUi.Load();
                        break;
                    case 2:
                        CreateUserUi.Load();
                        break;
                    case 3:
                        UpdateUserUi.Load();
                        break;
                    case 4:
                        DeleteUserUi.Load();
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
    }
}