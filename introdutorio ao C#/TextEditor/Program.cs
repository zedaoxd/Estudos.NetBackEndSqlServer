internal class Program
{
	private static void Main(string[] args)
	{
		Menu();
	}
	
	private static void Menu()
	{
		Console.Clear();
		Console.WriteLine("O que você deseja fazer?");
		Console.WriteLine("1 - Abrir arquivo");
		Console.WriteLine("2 - Criar novo arquivo");
		Console.WriteLine("0 - Sair");
		short option = short.Parse(Console.ReadLine());
		
		switch (option)
		{
			case 0:
				System.Environment.Exit(0);
				break;
			case 1:
				OpemFile();
				break;
			case 2:
				EditFile();
				break;
			default:
				Menu();
				break;
		}
	}
		
	private static void OpemFile() 
	{
		Console.Clear();
		Console.WriteLine("Qual o caminho do arquivo: ");
		var path = Console.ReadLine();
		using (var file = new StreamReader(path))
		{
			var text = file.ReadToEnd();
			Console.WriteLine(text);
		}
		
		Console.ReadLine();
		Menu();
	}
	
	private static void EditFile()
	{
		Console.Clear();
		Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
		Console.WriteLine("---------------------------------------");
		var text = "";
		
		do
			text += Console.ReadLine() + Environment.NewLine;
		while (Console.ReadKey().Key != ConsoleKey.Escape);

		Save(text);
	}
	
	private static void Save(string text)
	{
		Console.Clear();
		Console.WriteLine("Qual caminho para salvar o arquivo: ");
		var path = Console.ReadLine();
		
		using (var file = new StreamWriter(path))
			file.Write(text);
		
		Console.WriteLine($"Arquivo salvo: {path} com sucesso!");
		Thread.Sleep(2500);
		Menu();
	}
}