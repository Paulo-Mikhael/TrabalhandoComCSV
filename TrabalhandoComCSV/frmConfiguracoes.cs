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
			lblXlsxDirectory.Text = frmPlanilha.excelPath;
			lblCsvDirectory.Text = frmPlanilha.csvPath;
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
				frmPlanilha.excelPath = dialog.FileName;
				lblXlsxDirectory.Text = frmPlanilha.excelPath;
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
				frmPlanilha.csvPath = file.FileName;
				lblCsvDirectory.Text = frmPlanilha.csvPath;
			}
		}
	}
}
