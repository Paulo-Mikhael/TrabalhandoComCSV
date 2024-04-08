using System.ComponentModel;
using System.Globalization;
using CsvHelper;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

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
		public static int actualLine = 3;
		public static int lastLine;

		public List<string> CarregarPlanilha()
		{
			// {id},{cpf},{nome},{sexo},{endereco},{numero},{bairro},{cep},{municipio},{estado} => Ordem dos dados na Planilha
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

		public void CarregarCsvPlanilha()
		{
			try
			{
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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

								worksheet.Cells[row, 1].Value = id;
								worksheet.Cells[row, 2].Value = cpf;
								worksheet.Cells[row, 3].Value = nome;
								worksheet.Cells[row, 4].Value = genero;
								worksheet.Cells[row, 5].Value = endereco;
								worksheet.Cells[row, 6].Value = telefone;
								worksheet.Cells[row, 7].Value = bairro;
								worksheet.Cells[row, 8].Value = cep;
								worksheet.Cells[row, 9].Value = cidade;
								worksheet.Cells[row, 10].Value = estado;

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
			string cep, string estado, string municipio)
		{
			try
			{
				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets[planilha];

				plan.Cells[actualLine, 1].Value = id;
				plan.Cells[actualLine, 2].Value = cpf;
				plan.Cells[actualLine, 3].Value = nome;
				plan.Cells[actualLine, 4].Value = sexo;
				plan.Cells[actualLine, 5].Value = endereco;
				plan.Cells[actualLine, 6].Value = numero;
				plan.Cells[actualLine, 7].Value = bairro;
				plan.Cells[actualLine, 8].Value = cep;
				plan.Cells[actualLine, 9].Value = estado;
				plan.Cells[actualLine, 10].Value = municipio;
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
						plan.Cells[i, 1].Value = "";
						plan.Cells[i, 2].Value = "";
						plan.Cells[i, 3].Value = "";
						plan.Cells[i, 4].Value = "";
						plan.Cells[i, 5].Value = "";
						plan.Cells[i, 6].Value = "";
						plan.Cells[i, 7].Value = "";
						plan.Cells[i, 8].Value = "";
						plan.Cells[i, 9].Value = "";
						plan.Cells[i, 10].Value = "";
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
