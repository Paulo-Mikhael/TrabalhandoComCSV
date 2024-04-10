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
		public static string excelPath = @"C:\Users\Monica\Documents\TesteDadosCsv\TabelaClientes2.xlsx";
		public static string planilha = "Planilha1";

		public static int firstLine = 3;
		public static int lastLine;
		public static int actualLine = 3;
		public static int firstColumn = 1;

		public static int linhaCorte;

		public void NumeroCorte()
		{
			int corte = 0;

			for (int i = firstLine; i != 1 ; i--)
			{
				corte++;
			}

			linhaCorte = corte;
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

				pasta.Save();

				return dadosPlanilha;
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método CarregarPlanilha.\r\nErro: {ex.Message}");
			}
			finally
			{
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

				pasta.Save();
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método AtualizaPlanilha.\r\nErro: {ex.Message}");
			}
			finally
			{
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

				Excel.Range usedRange = plan.UsedRange;

				foreach (Excel.Range cell in usedRange)
				{
					if (cell.Value != null)
					{
						var value = cell.Value;

						if (cell.Value.GetType() == typeof(double))
						{
							cell.ClearContents();
						}
						else if (value != "ID" && value != "CPF" && value != "NOME" && value != "SEXO" &&
							value != "ENDERECO" && value != "NUMERO" && value != "BAIRRO" &&
							value != "CEP" && value != "MUNICIPIO" && value != "ESTADO")
						{
							cell.ClearContents();
						}
					}
				}

				pasta.Save();
			}
			catch (Exception ex)
			{
				throw new Exception($"Erro no método LimparPlanilha.\r\nErro: {ex.Message}");
			}
			finally
			{
				pasta.Close(true);
				app.Quit();
			}
		}

		private void CriarPlanilha(string filePath)
		{
			Excel.Application app = new Excel.Application();
			Workbook workbook = app.Workbooks.Add();
			Worksheet worksheet = workbook.Worksheets[1];
			workbook.SaveAs(filePath);
			workbook.Close();
			app.Quit();
		}
	}
}
