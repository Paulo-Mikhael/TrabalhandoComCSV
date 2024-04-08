﻿using System;
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
using Logica;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace TrabalhandoComCSV
{
	public partial class frmPlanilha : Form
	{
		Logica.csvCrud csvCrud = new Logica.csvCrud();
		Logica.planCrud planCrud = new Logica.planCrud();

		public frmPlanilha()
		{
			InitializeComponent();
		}

		private void frmPlanilha_Load(object sender, EventArgs e)
		{
			int actualLine = planCrud.actualLine;
			CarregarPlanilha();
			CarregaDadosCsvPlanilha();
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.actualLine - 2);
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			CarregarPlanilha();
			Cursor = Cursors.Default;
		}

		private void CarregarPlanilha()
		{
			try
			{
				var dadosPlanilha = planCrud.CarregarPlanilha();

				lblStatus.Text = "Status: Carregando dados...";

				tbId.Text = dadosPlanilha[0];
				mtbCpf.Text = dadosPlanilha[1];
				tbNome.Text = dadosPlanilha[2];
				cdSexo.Text = dadosPlanilha[3];
				tbEndereco.Text = dadosPlanilha[4];
				mtbNumero.Text = dadosPlanilha[5];
				tbBairro.Text = dadosPlanilha[6];
				mtbCep.Text = dadosPlanilha[7];
				tbMunicipio.Text = dadosPlanilha[8];
				tbEstado.Text = dadosPlanilha[9];

				lblStatus.Text = "Status: Pronto";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro");
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "Status: Carregando a planilha de clientes, aguarde...";
			btnSalvar.Enabled = false;
			try
			{
				Cursor = Cursors.WaitCursor;
				planCrud.AtualizaPlanilha(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbMunicipio.Text, tbEstado.Text);
				csvCrud.AtualizaCsv(tbId.Text, mtbCpf.Text, tbNome.Text, cdSexo.Text, tbEndereco.Text, mtbNumero.Text, tbBairro.Text,
					mtbCep.Text, tbMunicipio.Text, tbEstado.Text);
				Cursor = Cursors.Default;
				MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				lblStatus.Text = "Status: Pronto";
				btnSalvar.Enabled = true;
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

		public void CarregaDadosCsvPlanilha()
		{
			try
			{
				planCrud.CarregarCsvPlanilha();
				lblTotal.Text = $"/ {Convert.ToString(planCrud.lastLine - 2)}";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnProximo_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (btnProximo.Enabled == true)
			{
				planCrud.actualLine++;
				int actualLine = planCrud.actualLine;

				lblStatus.Text = "Status: Carregando...";

				btnProximo.Enabled = false;
				btnAnterior.Enabled = false;

				if (actualLine <= planCrud.lastLine)
				{
					CarregarPlanilha();
					lblStatus.Text = "Status: Pronto";
					tbLinha.Text = Convert.ToString(actualLine - 2);
				}
				else if (actualLine > planCrud.lastLine)
				{
					planCrud.actualLine--;
					lblStatus.Text = "Status: Sem mais dados";
				}

				btnProximo.Enabled = true;
				btnAnterior.Enabled = true;
			}
			Cursor = Cursors.Default;
		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (btnAnterior.Enabled == true)
			{
				planCrud.actualLine--;
				int actualLine = planCrud.actualLine;

				lblStatus.Text = "Status: Carregando...";

				btnProximo.Enabled = false;
				btnAnterior.Enabled = false;

				if (actualLine >= planCrud.firstLine)
				{
					CarregarPlanilha();
					lblStatus.Text = "Status: Pronto";
					tbLinha.Text = Convert.ToString(actualLine - 2);
				}
				else if (actualLine < planCrud.firstLine)
				{
					planCrud.actualLine++;
					lblStatus.Text = "Status: Início da tabela";
				}

				btnProximo.Enabled = true;
				btnAnterior.Enabled = true;
			}
			Cursor = Cursors.Default;
		}

		private void btnPrimeiro_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			lblStatus.Text = "Status: Carregando...";
			planCrud.actualLine = 3;
			CarregarPlanilha();
			Cursor = Cursors.Default;
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.actualLine - 2);
		}

		private void btnUltimo_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			lblStatus.Text = "Status: Carregando...";
			planCrud.actualLine = planCrud.lastLine;
			CarregarPlanilha();
			Cursor = Cursors.Default;
			lblStatus.Text = "Status: Pronto";
			tbLinha.Text = Convert.ToString(planCrud.lastLine - 2);
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			try
			{
				var result = MessageBox.Show($"Deseja excluir o cliente {tbNome.Text} de ID {tbId.Text}?", "Confirmação",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.OK)
				{
					Cursor = Cursors.WaitCursor;
					btnExcluir.Visible = false;

					csvCrud.ExcluirCsv();

					LimparCadastro();

					CarregarPlanilha();

					tbLinha.Text = Convert.ToString(planCrud.actualLine - 2);
					lblTotal.Text = $"/ {Convert.ToString(planCrud.lastLine - 2)}";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				btnExcluir.Visible = true;
				Cursor = Cursors.Default;
			}
		}

		private void btnAviso_MouseEnter(object sender, EventArgs e)
		{
			btnAviso.BackgroundImage = Properties.Resources.aviso;
		}

		private void btnAviso_MouseLeave(object sender, EventArgs e)
		{
			btnAviso.BackgroundImage = Properties.Resources.aviso_hover;
		}

		private void btnAviso_MouseHover(object sender, EventArgs e)
		{
			btnAviso.BackColor = Color.Sienna;
		}

		private void tbLinha_Leave(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (int.TryParse(tbLinha.Text, out int valor) == true && valor <= planCrud.lastLine)
			{
				planCrud.actualLine = valor + 2;
				CarregarPlanilha();
			}
			else if (int.TryParse(tbLinha.Text, out _) == false || valor > planCrud.lastLine)
			{
				planCrud.actualLine = planCrud.firstLine;
				CarregarPlanilha();
				tbLinha.Text = Convert.ToString(planCrud.firstLine - 2);
			}
			Cursor = Cursors.Default;
		}

		private void lblStatus_Click(object sender, EventArgs e)
		{

		}

		private void frmPlanilha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.S && e.Control)
			{
				btnSalvar_Click(sender, e);
			}

			if (e.KeyCode == Keys.E && e.Control)
			{
				btnExcluir_Click(sender, e);
			}

			if (e.KeyCode == Keys.F5)
			{
				btnAbrir_Click(sender, e);
			}

			if (e.KeyCode == Keys.Down && e.Shift)
			{
				btnUltimo_Click(sender, e);
			}

			if (e.KeyCode == Keys.Up && e.Shift)
			{
				btnPrimeiro_Click(sender, e);
			}

			if (e.KeyCode == Keys.Left && e.Shift)
			{
				btnAnterior_Click(sender, e);
			}

			if (e.KeyCode == Keys.Right && e.Shift)
			{
				btnProximo_Click(sender, e);
			}
		}
	}
}
