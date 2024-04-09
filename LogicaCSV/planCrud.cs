using System.ComponentModel;
using System.Globalization;
using CsvHelper;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.NetworkInformation;

namespace Logica
{
	public class planCrud
	{
		Excel.Application app = new Excel.Application();
		Workbook pasta;
		Worksheet plan;
		csvCrud csvCrud = new csvCrud();

		static string csvPath = csvCrud.csvPath;
		public static string excelPath = @"C:\Users\Monica\Documents\TesteDadosCsv\TabelaClientes1.xlsx";
		public static string planilha = "Planilha1";

		public static int firstLine = 3;
		public static int lastLine;
		public static int actualLine = 3;
		public static int firstColumn = 4;

		public static int linhaCorte;
		public static int colunaCorte;

		public void NumeroCorte()
		{
			int corte = 0;

			for (int i = firstLine; i != 1 ; i--)
			{
				corte++;
			}

			linhaCorte = corte;

			corte = 0;

			for (int i = firstColumn; i != 1 ; i--)
			{
				corte++;
			}

			colunaCorte = corte;
		}

		public List<string> CarregarPlanilha()
		{
			try
			{
				List<string> dadosPlanilha = new List<string>();

				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets[planilha];

				var primeiraCelula = plan.Cells[firstLine, firstColumn].Value;

				if (primeiraCelula != null)
				{
					for (int i = firstColumn; i < firstColumn + 10; i++)
					{
						dadosPlanilha.Add(plan.Cells[actualLine, i].Value.ToString());
					}
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

		public void CarregarCsvPlanilha()
		{
			try
			{
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

				LimparPlanilha();

				using (var excelPackage = new ExcelPackage(new FileInfo(excelPath)))
				{
					using (var reader = new StreamReader(csvPath))
					using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
					{
						csv.Read();
						int row = firstLine;

						using (var worksheet = excelPackage.Workbook.Worksheets[planilha])
						{
							while (csv.Read())
							{
								var id = csv.GetField<int>(0);
								var cpf = csv.GetField<string>(1);
								var nome = csv.GetField<string>(2);
								var genero = csv.GetField<string>(3);
								var endereco = csv.GetField<string>(4);
								var telefone = csv.GetField<string>(5);
								var bairro = csv.GetField<string>(6);
								var cep = csv.GetField<string>(7);
								var cidade = csv.GetField<string>(8);
								var estado = csv.GetField<string>(9);

								worksheet.Cells[row, firstColumn].Value = id;
								worksheet.Cells[row, firstColumn + 1].Value = cpf;
								worksheet.Cells[row, firstColumn + 2].Value = nome;
								worksheet.Cells[row, firstColumn + 3].Value = genero;
								worksheet.Cells[row, firstColumn + 4].Value = endereco;
								worksheet.Cells[row, firstColumn + 5].Value = telefone;
								worksheet.Cells[row, firstColumn + 6].Value = bairro;
								worksheet.Cells[row, firstColumn + 7].Value = cep;
								worksheet.Cells[row, firstColumn + 8].Value = cidade;
								worksheet.Cells[row, firstColumn + 9].Value = estado;

								row++;
							}

							excelPackage.Save();
						}

						lastLine = row - 1;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método CarregarDadosCsvPlanilha.\r\nErro: {ex.Message}");
			}
		}

		public void AtualizaPlanilha(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string municipio, string estado)
		{
			try
			{
				// {id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado} => Ordem dos dados na Planilha
				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets[planilha];

				plan.Cells[actualLine, firstColumn].Value = id;
				plan.Cells[actualLine, firstColumn + 1].Value = cpf;
				plan.Cells[actualLine, firstColumn + 2].Value = nome;
				plan.Cells[actualLine, firstColumn + 3].Value = sexo;
				plan.Cells[actualLine, firstColumn + 4].Value = endereco;
				plan.Cells[actualLine, firstColumn + 5].Value = numero;
				plan.Cells[actualLine, firstColumn + 6].Value = bairro;
				plan.Cells[actualLine, firstColumn + 7].Value = cep;
				plan.Cells[actualLine, firstColumn + 8].Value = municipio;
				plan.Cells[actualLine, firstColumn + 9].Value = estado;
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método AtualizaPlanilha.\r\nErro: {ex.Message}");
			}
			finally
			{
				pasta.Save();
				pasta.Close(true);
				app.Quit();
			}
		}

		public void LimparPlanilha()
		{
			try
			{
				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets[planilha];

				var primeiraCelula = plan.Cells[firstLine, 1].Value;

				if (primeiraCelula != null)
				{
					for (int i = firstLine; i < lastLine + 1; i++)
					{
						plan.Cells[i, firstColumn].Value = "";
						plan.Cells[i, firstColumn + 1].Value = "";
						plan.Cells[i, firstColumn + 2].Value = "";
						plan.Cells[i, firstColumn + 3].Value = "";
						plan.Cells[i, firstColumn + 4].Value = "";
						plan.Cells[i, firstColumn + 5].Value = "";
						plan.Cells[i, firstColumn + 6].Value = "";
						plan.Cells[i, firstColumn + 7].Value = "";
						plan.Cells[i, firstColumn + 8].Value = "";
						plan.Cells[i, firstColumn + 9].Value = "";
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método LimparPlanilha.\r\nErro: {ex.Message}");
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
