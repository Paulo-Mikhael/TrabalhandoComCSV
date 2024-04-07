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

namespace TrabalhandoComCSV
{
	public partial class frmConfiguracoes : Form
	{
		public frmConfiguracoes()
		{
			InitializeComponent();
		}

		private void frmConfiguracoes_Load(object sender, EventArgs e)
		{
			lblXlsxDirectory.Text = planCrud.excelPath;
			lblCsvDirectory.Text = csvCrud.csvPath;
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
			string[] alfabeto = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
			int[] indice = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27 };

			Dictionary<string, int> coluna = new Dictionary<string, int>();

			for (int i = 0; i < alfabeto.Length; i++)
			{
				coluna.Add(alfabeto[i], indice[i]);
			}
		}
	}
}
