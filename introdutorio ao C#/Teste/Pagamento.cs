using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
	public class Pagamento : IDisposable
	{	
		public static event Action? AoFinalizarPagamento;
		
		public Pagamento()
		{
			AoFinalizarPagamento += EmitirNotaFiscal;
		}
		
		public void Dispose()
		{
			AoFinalizarPagamento -= EmitirNotaFiscal;
		}
		
		public void FinalizarPagamento()
		{
			AoFinalizarPagamento?.Invoke();
		}
		
		private void EmitirNotaFiscal()
		{
			Console.WriteLine("Emitindo nota fiscal");
		}

	}
}