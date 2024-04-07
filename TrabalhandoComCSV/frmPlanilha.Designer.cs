namespace TrabalhandoComCSV
{
	partial class frmPlanilha
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanilha));
			cdSexo = new ComboBox();
			mtbCep = new MaskedTextBox();
			mtbNumero = new MaskedTextBox();
			mtbCpf = new MaskedTextBox();
			tbNome = new TextBox();
			tbMunicipio = new TextBox();
			tbBairro = new TextBox();
			tbEndereco = new TextBox();
			tbEstado = new TextBox();
			tbId = new TextBox();
			label8 = new Label();
			label7 = new Label();
			label11 = new Label();
			label10 = new Label();
			label9 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			btnSalvar = new Button();
			lblStatus = new Label();
			label1 = new Label();
			btnAnterior = new Button();
			btnProximo = new Button();
			btnExcluir = new Button();
			btnUltimo = new Button();
			btnPrimeiro = new Button();
			label12 = new Label();
			tbLinha = new TextBox();
			lblTotal = new Label();
			btnAviso = new Button();
			btnAbrir = new Button();
			SuspendLayout();
			// 
			// cdSexo
			// 
			cdSexo.BackColor = SystemColors.ActiveBorder;
			cdSexo.DropDownStyle = ComboBoxStyle.DropDownList;
			cdSexo.FormattingEnabled = true;
			cdSexo.Items.AddRange(new object[] { "Masculino", "Feminino" });
			cdSexo.Location = new Point(112, 191);
			cdSexo.Name = "cdSexo";
			cdSexo.Size = new Size(194, 25);
			cdSexo.TabIndex = 24;
			// 
			// mtbCep
			// 
			mtbCep.BackColor = SystemColors.ActiveBorder;
			mtbCep.Location = new Point(522, 259);
			mtbCep.Mask = "99,999-999";
			mtbCep.Name = "mtbCep";
			mtbCep.Size = new Size(107, 25);
			mtbCep.TabIndex = 23;
			// 
			// mtbNumero
			// 
			mtbNumero.BackColor = SystemColors.ActiveBorder;
			mtbNumero.Location = new Point(522, 225);
			mtbNumero.Mask = "(99) 99999-9999";
			mtbNumero.Name = "mtbNumero";
			mtbNumero.Size = new Size(107, 25);
			mtbNumero.TabIndex = 22;
			// 
			// mtbCpf
			// 
			mtbCpf.BackColor = SystemColors.ActiveBorder;
			mtbCpf.Location = new Point(112, 123);
			mtbCpf.Mask = "999,999,999-99";
			mtbCpf.Name = "mtbCpf";
			mtbCpf.Size = new Size(100, 25);
			mtbCpf.TabIndex = 21;
			// 
			// tbNome
			// 
			tbNome.BackColor = SystemColors.ActiveBorder;
			tbNome.Location = new Point(112, 157);
			tbNome.Name = "tbNome";
			tbNome.Size = new Size(517, 25);
			tbNome.TabIndex = 19;
			tbNome.TextChanged += tbNome_TextChanged;
			// 
			// tbMunicipio
			// 
			tbMunicipio.BackColor = SystemColors.ActiveBorder;
			tbMunicipio.Location = new Point(112, 293);
			tbMunicipio.Name = "tbMunicipio";
			tbMunicipio.Size = new Size(324, 25);
			tbMunicipio.TabIndex = 18;
			// 
			// tbBairro
			// 
			tbBairro.BackColor = SystemColors.ActiveBorder;
			tbBairro.Location = new Point(112, 259);
			tbBairro.Name = "tbBairro";
			tbBairro.Size = new Size(324, 25);
			tbBairro.TabIndex = 17;
			// 
			// tbEndereco
			// 
			tbEndereco.BackColor = SystemColors.ActiveBorder;
			tbEndereco.Location = new Point(112, 225);
			tbEndereco.Name = "tbEndereco";
			tbEndereco.Size = new Size(324, 25);
			tbEndereco.TabIndex = 16;
			// 
			// tbEstado
			// 
			tbEstado.BackColor = SystemColors.ActiveBorder;
			tbEstado.Location = new Point(522, 293);
			tbEstado.Name = "tbEstado";
			tbEstado.Size = new Size(107, 25);
			tbEstado.TabIndex = 20;
			// 
			// tbId
			// 
			tbId.BackColor = SystemColors.ActiveBorder;
			tbId.Location = new Point(112, 89);
			tbId.Name = "tbId";
			tbId.Size = new Size(100, 25);
			tbId.TabIndex = 15;
			tbId.TextChanged += tbId_TextChanged;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(32, 296);
			label8.Name = "label8";
			label8.Size = new Size(74, 17);
			label8.TabIndex = 13;
			label8.Text = "Município:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(57, 262);
			label7.Name = "label7";
			label7.Size = new Size(49, 17);
			label7.TabIndex = 12;
			label7.Text = "Bairro:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(463, 296);
			label11.Name = "label11";
			label11.Size = new Size(53, 17);
			label11.TabIndex = 11;
			label11.Text = "Estado:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(481, 262);
			label10.Name = "label10";
			label10.Size = new Size(35, 17);
			label10.TabIndex = 10;
			label10.Text = "CEP:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(454, 228);
			label9.Name = "label9";
			label9.Size = new Size(62, 17);
			label9.TabIndex = 9;
			label9.Text = "Número:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(38, 228);
			label6.Name = "label6";
			label6.Size = new Size(68, 17);
			label6.TabIndex = 8;
			label6.Text = "Endereço:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(65, 194);
			label5.Name = "label5";
			label5.Size = new Size(41, 17);
			label5.TabIndex = 7;
			label5.Text = "Sexo:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(57, 160);
			label4.Name = "label4";
			label4.Size = new Size(49, 17);
			label4.TabIndex = 6;
			label4.Text = "Nome:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(71, 126);
			label3.Name = "label3";
			label3.Size = new Size(35, 17);
			label3.TabIndex = 14;
			label3.Text = "CPF:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(80, 92);
			label2.Name = "label2";
			label2.Size = new Size(26, 17);
			label2.TabIndex = 5;
			label2.Text = "ID:";
			// 
			// btnSalvar
			// 
			btnSalvar.BackColor = Color.DarkOrchid;
			btnSalvar.FlatAppearance.BorderSize = 2;
			btnSalvar.FlatStyle = FlatStyle.Flat;
			btnSalvar.ImageAlign = ContentAlignment.MiddleRight;
			btnSalvar.Location = new Point(38, 449);
			btnSalvar.Name = "btnSalvar";
			btnSalvar.Size = new Size(108, 37);
			btnSalvar.TabIndex = 25;
			btnSalvar.Text = "Salvar dados";
			btnSalvar.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnSalvar.UseVisualStyleBackColor = false;
			btnSalvar.Click += btnSalvar_Click;
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Location = new Point(38, 414);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(50, 17);
			lblStatus.TabIndex = 5;
			lblStatus.Text = "Status:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.Yellow;
			label1.Location = new Point(16, 14);
			label1.Name = "label1";
			label1.Size = new Size(600, 51);
			label1.TabIndex = 0;
			label1.Text = resources.GetString("label1.Text");
			label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Click += label1_Click;
			// 
			// btnAnterior
			// 
			btnAnterior.BackColor = Color.RoyalBlue;
			btnAnterior.FlatAppearance.BorderSize = 2;
			btnAnterior.FlatStyle = FlatStyle.Flat;
			btnAnterior.ImageAlign = ContentAlignment.MiddleRight;
			btnAnterior.Location = new Point(431, 449);
			btnAnterior.Name = "btnAnterior";
			btnAnterior.Size = new Size(96, 37);
			btnAnterior.TabIndex = 25;
			btnAnterior.Text = "Anterior";
			btnAnterior.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnAnterior.UseVisualStyleBackColor = false;
			btnAnterior.Click += btnAnterior_Click;
			// 
			// btnProximo
			// 
			btnProximo.BackColor = Color.RoyalBlue;
			btnProximo.FlatAppearance.BorderSize = 2;
			btnProximo.FlatStyle = FlatStyle.Flat;
			btnProximo.ImageAlign = ContentAlignment.MiddleRight;
			btnProximo.Location = new Point(533, 449);
			btnProximo.Name = "btnProximo";
			btnProximo.Size = new Size(96, 37);
			btnProximo.TabIndex = 25;
			btnProximo.Text = "Proximo";
			btnProximo.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnProximo.UseVisualStyleBackColor = false;
			btnProximo.Click += btnProximo_Click;
			// 
			// btnExcluir
			// 
			btnExcluir.BackColor = Color.DarkRed;
			btnExcluir.FlatAppearance.BorderSize = 2;
			btnExcluir.FlatStyle = FlatStyle.Flat;
			btnExcluir.ImageAlign = ContentAlignment.MiddleRight;
			btnExcluir.Location = new Point(292, 449);
			btnExcluir.Name = "btnExcluir";
			btnExcluir.Size = new Size(96, 37);
			btnExcluir.TabIndex = 25;
			btnExcluir.Text = "Excluir";
			btnExcluir.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnExcluir.UseVisualStyleBackColor = false;
			btnExcluir.Click += btnExcluir_Click;
			// 
			// btnUltimo
			// 
			btnUltimo.BackColor = Color.Orange;
			btnUltimo.FlatAppearance.BorderSize = 2;
			btnUltimo.FlatStyle = FlatStyle.Flat;
			btnUltimo.ImageAlign = ContentAlignment.MiddleRight;
			btnUltimo.Location = new Point(533, 394);
			btnUltimo.Name = "btnUltimo";
			btnUltimo.Size = new Size(96, 37);
			btnUltimo.TabIndex = 25;
			btnUltimo.Text = "Ultimo";
			btnUltimo.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnUltimo.UseVisualStyleBackColor = false;
			btnUltimo.Click += btnUltimo_Click;
			// 
			// btnPrimeiro
			// 
			btnPrimeiro.BackColor = Color.Orange;
			btnPrimeiro.FlatAppearance.BorderSize = 2;
			btnPrimeiro.FlatStyle = FlatStyle.Flat;
			btnPrimeiro.ImageAlign = ContentAlignment.MiddleRight;
			btnPrimeiro.Location = new Point(431, 394);
			btnPrimeiro.Name = "btnPrimeiro";
			btnPrimeiro.Size = new Size(96, 37);
			btnPrimeiro.TabIndex = 25;
			btnPrimeiro.Text = "Primeiro";
			btnPrimeiro.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnPrimeiro.UseVisualStyleBackColor = false;
			btnPrimeiro.Click += btnPrimeiro_Click;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(38, 362);
			label12.Name = "label12";
			label12.Size = new Size(46, 17);
			label12.TabIndex = 5;
			label12.Text = "Linha:";
			// 
			// tbLinha
			// 
			tbLinha.BackColor = SystemColors.ActiveBorder;
			tbLinha.Location = new Point(90, 359);
			tbLinha.Name = "tbLinha";
			tbLinha.Size = new Size(45, 25);
			tbLinha.TabIndex = 15;
			tbLinha.TextAlign = HorizontalAlignment.Center;
			// 
			// lblTotal
			// 
			lblTotal.AutoSize = true;
			lblTotal.ForeColor = SystemColors.ActiveCaptionText;
			lblTotal.Location = new Point(141, 362);
			lblTotal.Name = "lblTotal";
			lblTotal.Size = new Size(25, 17);
			lblTotal.TabIndex = 5;
			lblTotal.Text = "/ 7";
			// 
			// btnAviso
			// 
			btnAviso.BackColor = Color.Sienna;
			btnAviso.BackgroundImage = Properties.Resources.aviso_hover;
			btnAviso.BackgroundImageLayout = ImageLayout.Stretch;
			btnAviso.Cursor = Cursors.Hand;
			btnAviso.FlatAppearance.BorderSize = 0;
			btnAviso.FlatAppearance.MouseDownBackColor = Color.Sienna;
			btnAviso.FlatAppearance.MouseOverBackColor = Color.Sienna;
			btnAviso.FlatStyle = FlatStyle.Flat;
			btnAviso.ForeColor = Color.Violet;
			btnAviso.Location = new Point(619, 23);
			btnAviso.Name = "btnAviso";
			btnAviso.Size = new Size(37, 37);
			btnAviso.TabIndex = 0;
			btnAviso.TabStop = false;
			btnAviso.UseVisualStyleBackColor = false;
			btnAviso.Click += btnAviso_Click;
			btnAviso.MouseEnter += btnAviso_MouseEnter;
			btnAviso.MouseLeave += btnAviso_MouseLeave;
			btnAviso.MouseHover += btnAviso_MouseHover;
			// 
			// btnAbrir
			// 
			btnAbrir.BackColor = Color.DarkOrchid;
			btnAbrir.FlatAppearance.BorderSize = 2;
			btnAbrir.FlatStyle = FlatStyle.Flat;
			btnAbrir.ImageAlign = ContentAlignment.MiddleRight;
			btnAbrir.Location = new Point(152, 449);
			btnAbrir.Name = "btnAbrir";
			btnAbrir.Size = new Size(96, 37);
			btnAbrir.TabIndex = 25;
			btnAbrir.Text = "Atualizar";
			btnAbrir.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnAbrir.UseVisualStyleBackColor = false;
			btnAbrir.Click += btnAbrir_Click;
			// 
			// frmPlanilha
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.Sienna;
			ClientSize = new Size(668, 502);
			Controls.Add(btnAviso);
			Controls.Add(btnSalvar);
			Controls.Add(btnProximo);
			Controls.Add(btnPrimeiro);
			Controls.Add(btnUltimo);
			Controls.Add(btnAnterior);
			Controls.Add(btnExcluir);
			Controls.Add(btnAbrir);
			Controls.Add(cdSexo);
			Controls.Add(mtbCep);
			Controls.Add(mtbNumero);
			Controls.Add(mtbCpf);
			Controls.Add(tbNome);
			Controls.Add(tbMunicipio);
			Controls.Add(tbBairro);
			Controls.Add(tbEndereco);
			Controls.Add(tbEstado);
			Controls.Add(tbLinha);
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
			Controls.Add(label1);
			Controls.Add(lblTotal);
			Controls.Add(label12);
			Controls.Add(lblStatus);
			Controls.Add(label2);
			Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ForeColor = SystemColors.ButtonHighlight;
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "frmPlanilha";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Ler dados da planilha EXCEL";
			FormClosing += frmPlanilha_FormClosing;
			Load += frmPlanilha_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox cdSexo;
		private MaskedTextBox mtbCep;
		private MaskedTextBox mtbNumero;
		private MaskedTextBox mtbCpf;
		private TextBox tbNome;
		private TextBox tbMunicipio;
		private TextBox tbBairro;
		private TextBox tbEndereco;
		private TextBox tbEstado;
		private TextBox tbId;
		private Label label8;
		private Label label7;
		private Label label11;
		private Label label10;
		private Label label9;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Button btnSalvar;
		private Label lblStatus;
		private Label label1;
		private Button btnAnterior;
		private Button btnProximo;
		private Button btnExcluir;
		private Button btnUltimo;
		private Button btnPrimeiro;
		private Label label12;
		private TextBox tbLinha;
		private Label lblTotal;
		private Button btnAviso;
		private Button btnAbrir;
	}
}