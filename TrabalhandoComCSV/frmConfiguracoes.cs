using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace TrabalhandoComCSV
{
	public partial class frmConfiguracoes : Form
	{
		public frmConfiguracoes()
		{
			InitializeComponent();
		}

		private Dictionary<string, int> ExcelLetraPraNumero()
		{
			Dictionary<string, int> coluna = new Dictionary<string, int>();

			string[] indice = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
			int[] valor = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

			for (int i = 0; i < indice.Length; i++)
			{
				coluna.Add(indice[i], valor[i]);
			}

			return coluna;
		}

		private void frmConfiguracoes_Load(object sender, EventArgs e)
		{
			lblXlsxDirectory.Text = planCrud.excelPath;
			lblCsvDirectory.Text = csvCrud.csvPath;

			var coluna = ExcelLetraPraNumero();

			foreach (var item in coluna)
			{
				if (item.Value == planCrud.firstColumn)
				{
					tbCelula.Text = $"{Convert.ToString(item.Key)}{Convert.ToString(planCrud.firstLine)}";
				}
			}
		}

		private void btnMudarXlsx_Click(object sender, EventArgs e)
		{
			var plan = new frmPlanilha();
			var dialog = new OpenFileDialog();

			dialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx";
			dialog.FilterIndex = 1;

			DialogResult result = dialog.ShowDialog();

			if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
			{
				planCrud.excelPath = dialog.FileName;
				lblXlsxDirectory.Text = planCrud.excelPath;
			}
		}

		private void btnMudarCsv_Click(object sender, EventArgs e)
		{
			var file = new OpenFileDialog();

			file.Filter = "Arquivos separados por vírgula (*.csv)|*.csv";
			file.FilterIndex = 1;

			var result = file.ShowDialog();

			if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(file.FileName))
			{
				csvCrud.csvPath = file.FileName;
				lblCsvDirectory.Text = csvCrud.csvPath;
			}
		}

		private void tbCelula_TextChanged(object sender, EventArgs e)
		{

		}

		private void label11_Click(object sender, EventArgs e)
		{

		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(tbCelula.Text))
				{
					throw new Exception("O campo Célula inicial está vazio");
				}

				if (tbCelula.Text.Length != 2 || int.TryParse(tbCelula.Text[1].ToString(), out int _) == false ||
					int.TryParse(tbCelula.Text[0].ToString(), out _))
				{
					throw new Exception("Insira uma célula válida");
				}

				var coluna = ExcelLetraPraNumero();

				string primeiroCaractere = tbCelula.Text[0].ToString().ToUpper();
				string segundoCaractere = tbCelula.Text[1].ToString();

				int numeroColuna = coluna[primeiroCaractere];
				int numeroLinha = Convert.ToInt32(segundoCaractere);

				MessageBox.Show($"Coluna: {Convert.ToString(numeroColuna)} - Linha:{Convert.ToString(numeroLinha)}");

				Excel.Application app = new Excel.Application();
				Workbook pasta;
				Worksheet plan;

				var excelPath = @"C:\Users\Monica\Documents\Programação\Programação C#\TrabalhandoComCSV\Teste.xlsx";

				if (!File.Exists(excelPath))
				{
					CriarPlanilha(excelPath);
				}

				pasta = app.Workbooks.Open(excelPath);
				plan = pasta.Worksheets["Planilha1"];

				plan.Cells[numeroLinha, numeroColuna].Value = "teste";

				pasta.Save();
				pasta.Close();
				app.Quit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
