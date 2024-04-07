using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Logica
{
	public class planCrud
	{
		Excel.Application app = new Excel.Application();
		Workbook pasta;
		Worksheet plan;

		public static string excelPath = @"C:\Users\Monica\Documents\TesteDadosCsv\TabelaClientes.xlsx";
		public static string csvPath = @"C:\Users\Monica\Documents\TesteDadosCsv\clientes.csv";
		public static string planilha = "Planilha1";
		public static int firstLine = 3;
		public static int actualLine = 3;

		public List<string> CarregarPlanilha()
		{
			// {id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado} => Ordem dos dados no CSV, 
			try
			{
				List<string> dadosPlanilha = new List<string>();

				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets[planilha];

				var primeiraCelula = plan.Cells[firstLine, 1].Value;

				if (primeiraCelula != null)
				{
					dadosPlanilha.Add(plan.Cells[actualLine, 1].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 2].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 3].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 4].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 5].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 6].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 7].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 8].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 9].Value.ToString());
					dadosPlanilha.Add(plan.Cells[actualLine, 10].Value.ToString());
				}
				else
				{
					throw new Exception("Sem dados na planilha");
				}

				return dadosPlanilha;
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método CarregarPlanilha.\r\nErro: {ex.Message}");
			}
			finally
			{
				pasta.Save();
				pasta.Close(true);
				app.Quit();
			}
		}
	}
}
