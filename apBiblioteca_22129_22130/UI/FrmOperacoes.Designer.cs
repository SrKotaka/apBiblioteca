namespace apBiblioteca_22129_22130.UI
{
    partial class FrmOperacoes
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
            this.tbLista = new System.Windows.Forms.TabPage();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.clCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDevolucao = new System.Windows.Forms.TabPage();
            this.dtDevolucaoReal = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarDevolucao = new System.Windows.Forms.Button();
            this.txtIdCadastro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEmprestimo = new System.Windows.Forms.TabPage();
            this.btnHelp = new System.Windows.Forms.Button();
            this.dtDevolucaoPrevista = new System.Windows.Forms.DateTimePicker();
            this.dtDataEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.txtIdEmprestimo = new System.Windows.Forms.TextBox();
            this.txtIdLivro = new System.Windows.Forms.TextBox();
            this.txtIdLeitor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.tbDevolucao.SuspendLayout();
            this.tbEmprestimo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLista
            // 
            this.tbLista.Controls.Add(this.dgvLista);
            this.tbLista.Controls.Add(this.label1);
            this.tbLista.Location = new System.Drawing.Point(4, 22);
            this.tbLista.Name = "tbLista";
            this.tbLista.Padding = new System.Windows.Forms.Padding(3);
            this.tbLista.Size = new System.Drawing.Size(999, 239);
            this.tbLista.TabIndex = 2;
            this.tbLista.Text = "Lista";
            this.tbLista.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLista.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clCheck});
            this.dgvLista.Location = new System.Drawing.Point(3, 0);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 51;
            this.dgvLista.Size = new System.Drawing.Size(990, 236);
            this.dgvLista.TabIndex = 2;
            // 
            // clCheck
            // 
            this.clCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clCheck.HeaderText = "Selecionar";
            this.clCheck.MinimumWidth = 6;
            this.clCheck.Name = "clCheck";
            this.clCheck.ReadOnly = true;
            this.clCheck.Width = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // tbDevolucao
            // 
            this.tbDevolucao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tbDevolucao.Controls.Add(this.dtDevolucaoReal);
            this.tbDevolucao.Controls.Add(this.btnRegistrarDevolucao);
            this.tbDevolucao.Controls.Add(this.txtIdCadastro);
            this.tbDevolucao.Controls.Add(this.label6);
            this.tbDevolucao.Controls.Add(this.label5);
            this.tbDevolucao.Location = new System.Drawing.Point(4, 22);
            this.tbDevolucao.Name = "tbDevolucao";
            this.tbDevolucao.Padding = new System.Windows.Forms.Padding(3);
            this.tbDevolucao.Size = new System.Drawing.Size(999, 239);
            this.tbDevolucao.TabIndex = 1;
            this.tbDevolucao.Text = "Devoluções";
            // 
            // dtDevolucaoReal
            // 
            this.dtDevolucaoReal.Location = new System.Drawing.Point(301, 80);
            this.dtDevolucaoReal.Name = "dtDevolucaoReal";
            this.dtDevolucaoReal.Size = new System.Drawing.Size(347, 19);
            this.dtDevolucaoReal.TabIndex = 21;
            // 
            // btnRegistrarDevolucao
            // 
            this.btnRegistrarDevolucao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarDevolucao.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRegistrarDevolucao.Location = new System.Drawing.Point(301, 129);
            this.btnRegistrarDevolucao.Name = "btnRegistrarDevolucao";
            this.btnRegistrarDevolucao.Size = new System.Drawing.Size(209, 31);
            this.btnRegistrarDevolucao.TabIndex = 17;
            this.btnRegistrarDevolucao.Text = "Registrar Devolução";
            this.btnRegistrarDevolucao.UseVisualStyleBackColor = false;
            this.btnRegistrarDevolucao.Click += new System.EventHandler(this.btnRegistrarDevolucao_Click_1);
            // 
            // txtIdCadastro
            // 
            this.txtIdCadastro.Location = new System.Drawing.Point(301, 34);
            this.txtIdCadastro.Name = "txtIdCadastro";
            this.txtIdCadastro.Size = new System.Drawing.Size(209, 19);
            this.txtIdCadastro.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Data Devolução Real:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Identificação do Emprestimo:";
            // 
            // tbEmprestimo
            // 
            this.tbEmprestimo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tbEmprestimo.Controls.Add(this.btnHelp);
            this.tbEmprestimo.Controls.Add(this.dtDevolucaoPrevista);
            this.tbEmprestimo.Controls.Add(this.dtDataEmprestimo);
            this.tbEmprestimo.Controls.Add(this.btnExcluir);
            this.tbEmprestimo.Controls.Add(this.btnExibir);
            this.tbEmprestimo.Controls.Add(this.btnAlterar);
            this.tbEmprestimo.Controls.Add(this.btnNovo);
            this.tbEmprestimo.Controls.Add(this.btnProcurar);
            this.tbEmprestimo.Controls.Add(this.txtIdEmprestimo);
            this.tbEmprestimo.Controls.Add(this.txtIdLivro);
            this.tbEmprestimo.Controls.Add(this.txtIdLeitor);
            this.tbEmprestimo.Controls.Add(this.label9);
            this.tbEmprestimo.Controls.Add(this.label8);
            this.tbEmprestimo.Controls.Add(this.label4);
            this.tbEmprestimo.Controls.Add(this.label3);
            this.tbEmprestimo.Controls.Add(this.label2);
            this.tbEmprestimo.Location = new System.Drawing.Point(4, 22);
            this.tbEmprestimo.Name = "tbEmprestimo";
            this.tbEmprestimo.Padding = new System.Windows.Forms.Padding(3);
            this.tbEmprestimo.Size = new System.Drawing.Size(999, 239);
            this.tbEmprestimo.TabIndex = 0;
            this.tbEmprestimo.Text = "Empréstimos";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnHelp.Location = new System.Drawing.Point(689, 171);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(109, 33);
            this.btnHelp.TabIndex = 22;
            this.btnHelp.Text = "Ajuda";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dtDevolucaoPrevista
            // 
            this.dtDevolucaoPrevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.dtDevolucaoPrevista.Location = new System.Drawing.Point(585, 81);
            this.dtDevolucaoPrevista.Name = "dtDevolucaoPrevista";
            this.dtDevolucaoPrevista.Size = new System.Drawing.Size(390, 19);
            this.dtDevolucaoPrevista.TabIndex = 21;
            // 
            // dtDataEmprestimo
            // 
            this.dtDataEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.dtDataEmprestimo.Location = new System.Drawing.Point(585, 43);
            this.dtDataEmprestimo.Name = "dtDataEmprestimo";
            this.dtDataEmprestimo.Size = new System.Drawing.Size(390, 19);
            this.dtDataEmprestimo.TabIndex = 20;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnExcluir.Location = new System.Drawing.Point(357, 174);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(109, 31);
            this.btnExcluir.TabIndex = 19;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // btnExibir
            // 
            this.btnExibir.BackColor = System.Drawing.Color.Transparent;
            this.btnExibir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExibir.Location = new System.Drawing.Point(517, 174);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(109, 31);
            this.btnExibir.TabIndex = 18;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyleBackColor = false;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click_1);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnAlterar.Location = new System.Drawing.Point(200, 174);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(109, 31);
            this.btnAlterar.TabIndex = 17;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click_1);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnNovo.Location = new System.Drawing.Point(35, 174);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(109, 31);
            this.btnNovo.TabIndex = 16;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click_1);
            // 
            // btnProcurar
            // 
            this.btnProcurar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProcurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnProcurar.Location = new System.Drawing.Point(845, 171);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(109, 33);
            this.btnProcurar.TabIndex = 15;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = false;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click_1);
            // 
            // txtIdEmprestimo
            // 
            this.txtIdEmprestimo.Location = new System.Drawing.Point(236, 38);
            this.txtIdEmprestimo.Name = "txtIdEmprestimo";
            this.txtIdEmprestimo.Size = new System.Drawing.Size(110, 19);
            this.txtIdEmprestimo.TabIndex = 14;
            // 
            // txtIdLivro
            // 
            this.txtIdLivro.Location = new System.Drawing.Point(236, 113);
            this.txtIdLivro.Name = "txtIdLivro";
            this.txtIdLivro.Size = new System.Drawing.Size(110, 19);
            this.txtIdLivro.TabIndex = 9;
            // 
            // txtIdLeitor
            // 
            this.txtIdLeitor.Location = new System.Drawing.Point(236, 76);
            this.txtIdLeitor.Name = "txtIdLeitor";
            this.txtIdLeitor.Size = new System.Drawing.Size(110, 19);
            this.txtIdLeitor.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label9.Location = new System.Drawing.Point(31, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "idEmprestimo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label8.Location = new System.Drawing.Point(381, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Devolução Prevista:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label4.Location = new System.Drawing.Point(381, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data do Emprestimo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label3.Location = new System.Drawing.Point(32, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "idLivro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label2.Location = new System.Drawing.Point(32, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "idLeitor:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbEmprestimo);
            this.tabControl1.Controls.Add(this.tbDevolucao);
            this.tabControl1.Controls.Add(this.tbLista);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 265);
            this.tabControl1.TabIndex = 0;
            // 
            // FrmOperacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 264);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "FrmOperacoes";
            this.Text = "Operações";
            this.tbLista.ResumeLayout(false);
            this.tbLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.tbDevolucao.ResumeLayout(false);
            this.tbDevolucao.PerformLayout();
            this.tbEmprestimo.ResumeLayout(false);
            this.tbEmprestimo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbDevolucao;
        private System.Windows.Forms.TextBox txtIdCadastro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tbEmprestimo;
        private System.Windows.Forms.TextBox txtIdEmprestimo;
        private System.Windows.Forms.TextBox txtIdLivro;
        private System.Windows.Forms.TextBox txtIdLeitor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRegistrarDevolucao;
        private System.Windows.Forms.DateTimePicker dtDataEmprestimo;
        private System.Windows.Forms.DateTimePicker dtDevolucaoPrevista;
        private System.Windows.Forms.DateTimePicker dtDevolucaoReal;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clCheck;
        private System.Windows.Forms.Button btnHelp;
    }
}