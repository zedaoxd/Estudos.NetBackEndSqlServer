// ======================== IDs ========================================================================================================================================================
// var id = Guid.NewGuid();

// //id = new Guid("191ae414-7c8e-474a-b104-545af1496298");

// Console.WriteLine(id);



// ========================= Datas ======================================================================================================================================================

// var date = DateTime.Now;

// Adiciona ou remove tempo, Formata data ----------------------
// Console.WriteLine(String.Format("{0:dd/MM/yyyy}",date));
// Console.WriteLine($"{date:dd/MM/yyyy}");
// date = date.AddDays(-20);
// Console.WriteLine($"{date:dd/MM/yyyy}");
// Console.WriteLine(String.Format("{0:dd/MM/yyyy}",date));

// Compara datas ---------------------------------------------------
// var date2 = date.AddDays(-3);

// if (date.Date == date2.Date)
// {
// 	Console.WriteLine($"{date.Date:dd/MM/yyyy} é igual de {date2.Date:dd/MM/yyyy}");
// }
// else if (date.Date > date2.Date)
// {
// 	Console.WriteLine($"{date.Date:dd/MM/yyyy} é depois de {date2.Date:dd/MM/yyyy}");
// }
// else 
// {
// 	Console.WriteLine($"{date.Date:dd/MM/yyyy} é antes de {date2.Date:dd/MM/yyyy}");
// }

// Globalização ---------------------------------------------------
// using System.Globalization;

// var ptBR = new CultureInfo("pt-BR"); // pt-BR
// var enUS = new CultureInfo("en-US"); // pt-BR
// var actual = CultureInfo.CurrentCulture; // cultura atual da maquina

// Console.WriteLine(DateTime.Now.ToString("D", enUS));

// Horario global ---------------------------------------------------
// var datetime = DateTime.UtcNow;

// // var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");

// // Console.WriteLine(datetime);
// // Console.WriteLine(datetime.ToLocalTime());
// // Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(datetime, timezoneAustralia));

// var timezones = TimeZoneInfo.GetSystemTimeZones();
// foreach (var timezone in timezones)
// {
// 	Console.WriteLine(timezone.Id);
// 	Console.WriteLine(timezone);
// 	Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(datetime, timezone));
// 	Console.WriteLine("=========================================================");
// }

// Timespan ---------------------------------------------------
// var timeSpan = new TimeSpan();
// Console.WriteLine(timeSpan);

// var timeSpanNanosegundos = new TimeSpan(1);
// Console.WriteLine(timeSpanNanosegundos);

// var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
// Console.WriteLine(timeSpanHoraMinutoSegundo);

// var timeSpanDiaHoraMinutoSegundo = new TimeSpan(14, 5, 12, 8);
// Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

// var timeSpanDiaHoraMinutoSegundoMilissegundo = new TimeSpan(15, 12, 5, 12, 8);
// Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundo);

// Console.WriteLine($"diferença: {timeSpanDiaHoraMinutoSegundo - timeSpanHoraMinutoSegundo}");
// Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundo.Days);
// Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundo.Add(new TimeSpan(1, 0, 0)));

// Funções que geram duvidas ---------------------------------------------------

// saber quantos dias tem 1 mes expecifico
// Console.WriteLine(DateTime.DaysInMonth(2020, 2));

// // é fim de semana ou não?
// var date = DateTime.Now;
// Console.WriteLine(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);

// // é horario de verão?
// Console.WriteLine(date.IsDaylightSavingTime());

// ========================= Moedas ======================================================================================================================================================
// using System.Globalization;

// Console.Clear();

// decimal valor = 0.25M;
// // C => Formata moeda 
// // E04 => Formata notação cientifica
// // N => Fotmata separador de milhar
// // P => Fotmata procentagem
// Console.WriteLine(valor.ToString("G"/*, CultureInfo.CreateSpecificCulture("en-US")*/));
// Console.WriteLine(valor.ToString("C"/*, CultureInfo.CreateSpecificCulture("en-US")*/));
// Console.WriteLine(valor.ToString("E04"/*, CultureInfo.CreateSpecificCulture("en-US")*/));
// Console.WriteLine(valor.ToString("N"/*, CultureInfo.CreateSpecificCulture("en-US")*/));
// Console.WriteLine(valor.ToString("P"/*, CultureInfo.CreateSpecificCulture("en-US")*/));

// ========================= Eventos ======================================================================================================================================================

// delegates -> são ponteiros para fuções (em C# ele é um obj que guarda um ponteiro da função)
// Action -> é um delegate que sempre retorna void 
// Action<parametro, parametro etc...>

// Func -> é um delegate que sempre retorna algo 
// Func<parametro, parametro etc..., retorno>
using Teste;


Pagamento p = new Pagamento();
Entregador entregador = new Entregador();
Estoque estoque = new Estoque();


p.FinalizarPagamento();












