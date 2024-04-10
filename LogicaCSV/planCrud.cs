using System.Globalization;
using CsvHelper;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Logica
{
	public class planCrud
	{
		Excel.Application app = new Excel.Application();
		Workbook pasta;
		Worksheet plan;

		public static string excelPath;
		public static string planilha = "Planilha1";

		public static int planFirstLine = 3;
		public static int planLastLine;
		public static int planActualLine = 3;
		public static int firstColumn = 1;

		public static int linhaCorte;

		public void NumeroCorte()
		{
			int corte = 0;

			for (int i = planFirstLine; i != 1 ; i--)
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

				var primeiraCelula = plan.Cells[planFirstLine, firstColumn].Value;

				if (primeiraCelula != null)
				{
					for (int i = firstColumn; i < firstColumn + 10; i++)
					{
						dadosPlanilha.Add(plan.Cells[planActualLine, i].Value.ToString());
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
					using (var reader = new StreamReader(csvCrud.csvPath))
					using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
					{
						csv.Read();
						int row = planFirstLine;

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

						planLastLine = row - 1;
						planActualLine = planFirstLine;
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

				plan.Cells[planActualLine, firstColumn].Value = id;
				plan.Cells[planActualLine, firstColumn + 1].Value = cpf;
				plan.Cells[planActualLine, firstColumn + 2].Value = nome;
				plan.Cells[planActualLine, firstColumn + 3].Value = sexo;
				plan.Cells[planActualLine, firstColumn + 4].Value = endereco;
				plan.Cells[planActualLine, firstColumn + 5].Value = numero;
				plan.Cells[planActualLine, firstColumn + 6].Value = bairro;
				plan.Cells[planActualLine, firstColumn + 7].Value = cep;
				plan.Cells[planActualLine, firstColumn + 8].Value = municipio;
				plan.Cells[planActualLine, firstColumn + 9].Value = estado;

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

		public void CriarArquivoXlsx(string filePath)
		{
			try
			{
				using (File.Create(filePath)) { };
				excelPath = filePath;
				AdicionaPlanilha("Planilha1");
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método CriarArquivoXlsx. \r\nErro: {ex.Message}");
			}
		}

		public void AdicionaPlanilha(string plan)
		{
			try
			{
				using (ExcelPackage package = new ExcelPackage(new FileInfo(excelPath)))
				{
					package.Workbook.Worksheets.Add(plan);
					package.Save();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método AdicionaPlanilha. \r\nErro: {ex.Message}");
			}
		}

		public bool VerificaNomePlanilha(string plan)
		{
			try
			{
				using (ExcelPackage package = new ExcelPackage(new FileInfo(excelPath)))
				{
					foreach (var worksheet in package.Workbook.Worksheets)
					{
						if (plan == worksheet.Name)
						{
							return true;
						}
					}
				}

				return false;
			}
			catch (Exception ex)
			{
				throw new Exception($"Ocorreu um erro no método VerificaNomePlanilha. \r\nErro: {ex.Message}");
			}
		}
	}
}
