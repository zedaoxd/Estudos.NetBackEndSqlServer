using System;


namespace Blog.ui.userUis.roles
{
    public static class MenuRolesUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-----Gestão de Perfis------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] Listar perfis");
            Console.WriteLine("[2] Cadastrar perfil");
            Console.WriteLine("[3] Atualizar perfil");
            Console.WriteLine("[4] Excluir perfil");
            Console.WriteLine("\n\n");

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListRolesUi.Load();
                        break;
                    case 2:
                        CreateRolesUi.Load();
                        break;
                    case 3:
                        UpdateRolesUi.Load();
                        break;
                    case 4:
                        DeleteRolesUi.Load();
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