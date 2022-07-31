using System;


namespace Blog.ui.userUis
{
    public static class MenuTagUi
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("------Gestão de Tags-------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] Listar tags");
            Console.WriteLine("[2] Cadastrar tags");
            Console.WriteLine("[3] Atualizar tags");
            Console.WriteLine("[4] Excluir tags");
            Console.WriteLine("\n\n");

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListTagsUi.Load();
                        break;
                    case 2:
                        CreateTagsUi.Load();
                        break;
                    case 3:
                        UpdateTagsUi.Load();
                        break;
                    case 4:
                        DeleteTagsUi.Load();
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