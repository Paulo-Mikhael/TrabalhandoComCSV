namespace TrabalhandoComCSV
{
	partial class frmPrincipal
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			tbId = new TextBox();
			tbNome = new TextBox();
			tbEndereco = new TextBox();
			tbBairro = new TextBox();
			tbMunicipio = new TextBox();
			label9 = new Label();
			label10 = new Label();
			label11 = new Label();
			tbEstado = new TextBox();
			mtbCpf = new MaskedTextBox();
			mtbNumero = new MaskedTextBox();
			mtbCep = new MaskedTextBox();
			cdSexo = new ComboBox();
			btnSalvar = new Button();
			tsFerramentas = new ToolStrip();
			btnPlanilha = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			toolStripSeparator3 = new ToolStripSeparator();
			btnConfiguracoes = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			tsFerramentas.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			label1.Location = new Point(218, 71);
			label1.Name = "label1";
			label1.Size = new Size(280, 37);
			label1.TabIndex = 0;
			label1.Text = "Cadastro de Clientes";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(105, 165);
			label2.Name = "label2";
			label2.Size = new Size(26, 17);
			label2.TabIndex = 1;
			label2.Text = "ID:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(96, 199);
			label3.Name = "label3";
			label3.Size = new Size(35, 17);
			label3.TabIndex = 1;
			label3.Text = "CPF:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(82, 233);
			label4.Name = "label4";
			label4.Size = new Size(49, 17);
			label4.TabIndex = 1;
			label4.Text = "Nome:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(90, 267);
			label5.Name = "label5";
			label5.Size = new Size(41, 17);
			label5.TabIndex = 1;
			label5.Text = "Sexo:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(63, 301);
			label6.Name = "label6";
			label6.Size = new Size(68, 17);
			label6.TabIndex = 1;
			label6.Text = "Endereço:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(82, 335);
			label7.Name = "label7";
			label7.Size = new Size(49, 17);
			label7.TabIndex = 1;
			label7.Text = "Bairro:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(57, 369);
			label8.Name = "label8";
			label8.Size = new Size(74, 17);
			label8.TabIndex = 1;
			label8.Text = "Município:";
			// 
			// tbId
			// 
			tbId.BackColor = Color.LightSkyBlue;
			tbId.Location = new Point(137, 162);
			tbId.Name = "tbId";
			tbId.Size = new Size(100, 25);
			tbId.TabIndex = 0;
			tbId.TabStop = false;
			// 
			// tbNome
			// 
			tbNome.BackColor = Color.LightSkyBlue;
			tbNome.Location = new Point(137, 230);
			tbNome.Name = "tbNome";
			tbNome.Size = new Size(517, 25);
			tbNome.TabIndex = 2;
			// 
			// tbEndereco
			// 
			tbEndereco.BackColor = Color.LightSkyBlue;
			tbEndereco.Location = new Point(137, 298);
			tbEndereco.Name = "tbEndereco";
			tbEndereco.Size = new Size(324, 25);
			tbEndereco.TabIndex = 4;
			// 
			// tbBairro
			// 
			tbBairro.BackColor = Color.LightSkyBlue;
			tbBairro.Location = new Point(137, 332);
			tbBairro.Name = "tbBairro";
			tbBairro.Size = new Size(324, 25);
			tbBairro.TabIndex = 5;
			// 
			// tbMunicipio
			// 
			tbMunicipio.BackColor = Color.LightSkyBlue;
			tbMunicipio.Location = new Point(137, 366);
			tbMunicipio.Name = "tbMunicipio";
			tbMunicipio.Size = new Size(324, 25);
			tbMunicipio.TabIndex = 6;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(479, 301);
			label9.Name = "label9";
			label9.Size = new Size(62, 17);
			label9.TabIndex = 1;
			label9.Text = "Número:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(506, 335);
			label10.Name = "label10";
			label10.Size = new Size(35, 17);
			label10.TabIndex = 1;
			label10.Text = "CEP:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(488, 369);
			label11.Name = "label11";
			label11.Size = new Size(53, 17);
			label11.TabIndex = 1;
			label11.Text = "Estado:";
			// 
			// tbEstado
			// 
			tbEstado.BackColor = Color.LightSkyBlue;
			tbEstado.Location = new Point(547, 366);
			tbEstado.Name = "tbEstado";
			tbEstado.Size = new Size(107, 25);
			tbEstado.TabIndex = 9;
			// 
			// mtbCpf
			// 
			mtbCpf.BackColor = Color.LightSkyBlue;
			mtbCpf.Location = new Point(137, 196);
			mtbCpf.Mask = "999,999,999-99";
			mtbCpf.Name = "mtbCpf";
			mtbCpf.Size = new Size(100, 25);
			mtbCpf.TabIndex = 1;
			// 
			// mtbNumero
			// 
			mtbNumero.BackColor = Color.LightSkyBlue;
			mtbNumero.Location = new Point(547, 298);
			mtbNumero.Mask = "(99) 99999-9999";
			mtbNumero.Name = "mtbNumero";
			mtbNumero.Size = new Size(107, 25);
			mtbNumero.TabIndex = 7;
			// 
			// mtbCep
			// 
			mtbCep.BackColor = Color.LightSkyBlue;
			mtbCep.Location = new Point(547, 332);
			mtbCep.Mask = "99,999-999";
			mtbCep.Name = "mtbCep";
			mtbCep.Size = new Size(107, 25);
			mtbCep.TabIndex = 8;
			// 
			// cdSexo
			// 
			cdSexo.BackColor = Color.LightSkyBlue;
			cdSexo.DropDownStyle = ComboBoxStyle.DropDownList;
			cdSexo.FormattingEnabled = true;
			cdSexo.Items.AddRange(new object[] { "Masculino", "Feminino" });
			cdSexo.Location = new Point(137, 264);
			cdSexo.Name = "cdSexo";
			cdSexo.Size = new Size(194, 25);
			cdSexo.TabIndex = 3;
			// 
			// btnSalvar
			// 
			btnSalvar.BackColor = Color.Blue;
			btnSalvar.FlatAppearance.BorderSize = 2;
			btnSalvar.FlatStyle = FlatStyle.Flat;
			btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
			btnSalvar.ImageAlign = ContentAlignment.MiddleRight;
			btnSalvar.Location = new Point(336, 447);
			btnSalvar.Name = "btnSalvar";
			btnSalvar.Size = new Size(96, 45);
			btnSalvar.TabIndex = 10;
			btnSalvar.Text = "Salvar";
			btnSalvar.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnSalvar.UseVisualStyleBackColor = false;
			btnSalvar.Click += btnSalvar_Click;
			// 
			// tsFerramentas
			// 
			tsFerramentas.Items.AddRange(new ToolStripItem[] { btnPlanilha, toolStripSeparator1, toolStripSeparator3, btnConfiguracoes, toolStripSeparator2 });
			tsFerramentas.Location = new Point(0, 0);
			tsFerramentas.Name = "tsFerramentas";
			tsFerramentas.Size = new Size(739, 54);
			tsFerramentas.TabIndex = 0;
			tsFerramentas.Text = "toolStrip1";
			// 
			// btnPlanilha
			// 
			btnPlanilha.ForeColor = SystemColors.ActiveCaptionText;
			btnPlanilha.Image = (Image)resources.GetObject("btnPlanilha.Image");
			btnPlanilha.ImageScaling = ToolStripItemImageScaling.None;
			btnPlanilha.ImageTransparentColor = Color.Magenta;
			btnPlanilha.Name = "btnPlanilha";
			btnPlanilha.Size = new Size(72, 51);
			btnPlanilha.Text = "Ler Planilha";
			btnPlanilha.TextImageRelation = TextImageRelation.ImageAboveText;
			btnPlanilha.Click += btnPlanilha_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 54);
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new Size(6, 54);
			// 
			// btnConfiguracoes
			// 
			btnConfiguracoes.Alignment = ToolStripItemAlignment.Right;
			btnConfiguracoes.BackgroundImageLayout = ImageLayout.None;
			btnConfiguracoes.ForeColor = SystemColors.ActiveCaptionText;
			btnConfiguracoes.Image = Properties.Resources.configuracao;
			btnConfiguracoes.ImageScaling = ToolStripItemImageScaling.None;
			btnConfiguracoes.ImageTransparentColor = Color.Magenta;
			btnConfiguracoes.Name = "btnConfiguracoes";
			btnConfiguracoes.Size = new Size(88, 51);
			btnConfiguracoes.Text = "Configurações";
			btnConfiguracoes.TextImageRelation = TextImageRelation.ImageAboveText;
			btnConfiguracoes.ToolTipText = "Configure os diretórios da planilha e CSV onde deseja salvar os dados";
			btnConfiguracoes.Click += btnConfiguracoes_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 54);
			// 
			// frmPrincipal
			// 
			AcceptButton = btnSalvar;
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.DodgerBlue;
			ClientSize = new Size(739, 517);
			Controls.Add(tsFerramentas);
			Controls.Add(btnSalvar);
			Controls.Add(cdSexo);
			Controls.Add(mtbCep);
			Controls.Add(mtbNumero);
			Controls.Add(mtbCpf);
			Controls.Add(tbNome);
			Controls.Add(tbMunicipio);
			Controls.Add(tbBairro);
			Controls.Add(tbEndereco);
			Controls.Add(tbEstado);
			Controls.Add(tbId);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(label11);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ForeColor = SystemColors.Control;
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "frmPrincipal";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Cadastro de dados";
			Load += frmPrincipal_Load;
			KeyDown += frmPrincipal_KeyPress;
			tsFerramentas.ResumeLayout(false);
			tsFerramentas.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private TextBox tbId;
		private TextBox tbNome;
		private TextBox tbEndereco;
		private TextBox tbBairro;
		private TextBox tbMunicipio;
		private Label label9;
		private Label label10;
		private Label label11;
		private TextBox tbEstado;
		private MaskedTextBox mtbCpf;
		private MaskedTextBox mtbNumero;
		private MaskedTextBox mtbCep;
		private ComboBox cdSexo;
		private Button btnSalvar;
		private ToolStrip tsFerramentas;
		private ToolStripButton btnPlanilha;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton btnConfiguracoes;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripSeparator toolStripSeparator2;
	}
}
