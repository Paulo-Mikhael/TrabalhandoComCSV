using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace TrabalhandoComCSV
{
	public partial class frmPlanilha : Form
	{
		Excel.Application app = new Excel.Application();
		Workbook pasta;
		Worksheet plan;
		string excelPath = @"C:\Users\Monica\Documents\TesteDadosCsv\TabelaClientes1.xlsx";
		string csvPath = @"C:\Users\Monica\Documents\TesteDadosCsv\clientes.csv";
		string planilha = "Planilha1";
		int firstLine = 3;
		int lastLine;
		static int actualLine = 3;

		public frmPlanilha()
		{
			InitializeComponent();
		}

		private void frmPlanilha_Load(object sender, EventArgs e)
		{
			CarregaDadosCsvPlanilha();
			CarregarPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(actualLine - 2);
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			CarregarPlanilha();
		}

		private void CarregarPlanilha()
		{
			try
			{
				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets[planilha];

				var primeiraCelula = plan.Cells[firstLine, 1].Value;

				if (primeiraCelula != null)
				{
					lblStatus.Text = "Status: Carregando dados...";

					tbId.Text = plan.Cells[actualLine, 1].Value.ToString();
					tbNome.Text = plan.Cells[actualLine, 3].Value.ToString();
					mtbCpf.Text = plan.Cells[actualLine, 2].Value.ToString();
					cdSexo.Text = plan.Cells[actualLine, 4].Value.ToString();
					tbEndereco.Text = plan.Cells[actualLine, 5].Value.ToString();
					mtbNumero.Text = plan.Cells[actualLine, 6].Value.ToString();
					tbBairro.Text = plan.Cells[actualLine, 7].Value.ToString();
					mtbCep.Text = plan.Cells[actualLine, 8].Value.ToString();
					tbEstado.Text = plan.Cells[actualLine, 9].Value.ToString();
					tbMunicipio.Text = plan.Cells[actualLine, 10].Value.ToString();

					lblStatus.Text = "Status: Pronto";
				}
				else
				{
					lblStatus.Text = "Status: Sem dados na planilha";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n Possíveis causas: Planilha aberta no excel", "Erro");
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando a planilha de clientes, aguarde...";
			btnSalvar.Enabled = false;
			try
			{
				AtualizaPlanilha(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbEstado.Text, tbMunicipio.Text);
				AtualizaCsv(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbEstado.Text, tbMunicipio.Text);

				lblStatus.Text = "Status: Pronto";
				LimparCadastro();
				btnSalvar.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void frmPlanilha_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				app.Quit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro ao fechar o Excel");
			}
		}

		private void LimparCadastro()
		{
			tbId.Text = "";
			tbNome.Text = "";
			mtbCpf.Text = "";
			cdSexo.Text = "";
			tbEndereco.Text = "";
			mtbNumero.Text = "";
			tbBairro.Text = "";
			mtbCep.Text = "";
			tbEstado.Text = "";
			tbMunicipio.Text = "";
			cdSexo.SelectedIndex = -1;
		}

		private void AtualizaPlanilha(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string estado, string municipio)
		{
			try
			{
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
				pasta.Save();
				pasta.Close(true);

				MessageBox.Show("Planilha salva com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception)
			{
				throw new Exception("Erro no método AtualizaPlanilha");
			}
		}

		private void AtualizaCsv(string id, string cpf, string nome, string sexo, string endereco, string numero, string bairro,
			string cep, string estado, string municipio)
		{
			try
			{
				int linhaParaAtualizar = actualLine - 2;

				string[] linhas = File.ReadAllLines(csvPath);

				if (linhaParaAtualizar >= 0 && linhaParaAtualizar < linhas.Length)
				{
					string[] campos = linhas[linhaParaAtualizar].Split(',');
					campos[0] = id;
					campos[1] = cpf;
					campos[2] = nome;
					campos[3] = sexo;
					campos[4] = endereco;
					campos[5] = numero;
					campos[6] = bairro;
					campos[7] = cep;
					campos[8] = estado;
					campos[9] = municipio;

					linhas[linhaParaAtualizar] = string.Join(",", campos);

					File.WriteAllLines(csvPath, linhas, Encoding.UTF8);

					Console.WriteLine("Linha atualizada com sucesso.");
				}
				else
				{
					Console.WriteLine("A linha especificada não existe no arquivo CSV.");
				}
			}
			catch (Exception)
			{
				throw new Exception("Erro no método AtualizaCsv");
			}
		}

		private void LimparPlanilha()
		{
			using (var excelPackage = new ExcelPackage(new FileInfo(excelPath)))
			{
				var worksheet = excelPackage.Workbook.Worksheets[planilha];

				for (int row = actualLine; row < lastLine + 1; row++)
				{
					worksheet.Cells[row, 1].Value = "";
					worksheet.Cells[row, 2].Value = "";
					worksheet.Cells[row, 3].Value = "";
					worksheet.Cells[row, 4].Value = "";
					worksheet.Cells[row, 5].Value = "";
					worksheet.Cells[row, 6].Value = "";
					worksheet.Cells[row, 7].Value = "";
					worksheet.Cells[row, 8].Value = "";
					worksheet.Cells[row, 9].Value = "";
					worksheet.Cells[row, 10].Value = "";
				}

				excelPackage.Save();
			}
		}

		private void CarregaDadosCsvPlanilha()
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			using (var excelPackage = new ExcelPackage(new FileInfo(excelPath)))
			{
				var worksheet = excelPackage.Workbook.Worksheets[planilha];

				using (var reader = new StreamReader(csvPath))
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					csv.Read();
					int row = actualLine;

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
					MessageBox.Show("Dados do CSV transferidos para a planilha com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

					lastLine = row - 1;
				}

				excelPackage.Save();
			}

		}

		private void btnProximo_Click(object sender, EventArgs e)
		{
			actualLine++;
			lblStatus.Text = "Status: Carregando...";

			if (actualLine <= lastLine)
			{
				CarregarPlanilha();
				lblStatus.Text = "Status: Pronto";
				tbLinha.Text = Convert.ToString(actualLine - 2);
			}
			else if (actualLine > lastLine)
			{
				actualLine--;
				lblStatus.Text = "Status: Sem mais dados";
			}

		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			actualLine--;
			lblStatus.Text = "Status: Carregando...";

			if (actualLine >= firstLine)
			{
				CarregarPlanilha();
				lblStatus.Text = "Status: Pronto";
				tbLinha.Text = Convert.ToString(actualLine - 2);
			}
			else if (actualLine < firstLine)
			{
				actualLine++;
				lblStatus.Text = "Status: Início da tabela";
			}
		}

		private void btnPrimeiro_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando...";
			actualLine = 3;
			CarregarPlanilha();
			lblStatus.Text = "Status: Pronto";
			actualLine = 3;
			tbLinha.Text = Convert.ToString(actualLine - 2);
		}

		private void btnUltimo_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando...";
			actualLine = lastLine;
			CarregarPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(lastLine);
		}

		private void ExcluirCsv()
		{
			try
			{
				int linhaPraExcluir = actualLine - 2;

				string[] linhas = File.ReadAllLines(csvPath);

				if (linhaPraExcluir >= 0 && linhaPraExcluir < linhas.Length)
				{
					var linhasList = new List<string>(linhas);
					linhasList.RemoveAt(linhaPraExcluir);

					File.WriteAllLines(csvPath, linhasList, Encoding.UTF8);

					MessageBox.Show($"Linha {linhaPraExcluir} excluída");

					LimparPlanilha();

					actualLine--;

					CarregaDadosCsvPlanilha();

					LimparCadastro();
				}
			}
			catch (Exception)
			{
				throw new Exception("Erro no método ExcluirCsv");
			}
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			ExcluirCsv();
		}
	}
}
