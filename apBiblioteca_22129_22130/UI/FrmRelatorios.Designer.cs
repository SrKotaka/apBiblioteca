namespace apBiblioteca_22129_22130.UI
{
    partial class FrmRelatorios
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
            this.tbLeitores = new System.Windows.Forms.TabPage();
            this.dgvLeitores = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LivrosEmprestados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LivrosAtrasados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLivros = new System.Windows.Forms.TabPage();
            this.dgvLivros = new System.Windows.Forms.DataGridView();
            this.IdEmprestimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TituloLivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Devolvido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbLeitores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeitores)).BeginInit();
            this.tbLivros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLeitores
            // 
            this.tbLeitores.BackColor = System.Drawing.SystemColors.Window;
            this.tbLeitores.Controls.Add(this.dgvLeitores);
            this.tbLeitores.Location = new System.Drawing.Point(4, 25);
            this.tbLeitores.Name = "tbLeitores";
            this.tbLeitores.Padding = new System.Windows.Forms.Padding(3);
            this.tbLeitores.Size = new System.Drawing.Size(749, 308);
            this.tbLeitores.TabIndex = 1;
            this.tbLeitores.Text = "Leitores";
            // 
            // dgvLeitores
            // 
            this.dgvLeitores.AllowUserToAddRows = false;
            this.dgvLeitores.AllowUserToDeleteRows = false;
            this.dgvLeitores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLeitores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLeitores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeitores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NomeLeitor,
            this.LivrosEmprestados,
            this.LivrosAtrasados});
            this.dgvLeitores.Location = new System.Drawing.Point(4, 5);
            this.dgvLeitores.Name = "dgvLeitores";
            this.dgvLeitores.ReadOnly = true;
            this.dgvLeitores.RowHeadersWidth = 51;
            this.dgvLeitores.Size = new System.Drawing.Size(740, 278);
            this.dgvLeitores.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id.HeaderText = "Identificação";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 163;
            // 
            // NomeLeitor
            // 
            this.NomeLeitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NomeLeitor.HeaderText = "Nome";
            this.NomeLeitor.MinimumWidth = 6;
            this.NomeLeitor.Name = "NomeLeitor";
            this.NomeLeitor.ReadOnly = true;
            this.NomeLeitor.Width = 97;
            // 
            // LivrosEmprestados
            // 
            this.LivrosEmprestados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LivrosEmprestados.HeaderText = "Qtde. de Livros Emprestados no Momento";
            this.LivrosEmprestados.MinimumWidth = 6;
            this.LivrosEmprestados.Name = "LivrosEmprestados";
            this.LivrosEmprestados.ReadOnly = true;
            this.LivrosEmprestados.Width = 323;
            // 
            // LivrosAtrasados
            // 
            this.LivrosAtrasados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LivrosAtrasados.HeaderText = "Qtde. de Livros Atrasados No Momento";
            this.LivrosAtrasados.MinimumWidth = 6;
            this.LivrosAtrasados.Name = "LivrosAtrasados";
            this.LivrosAtrasados.ReadOnly = true;
            this.LivrosAtrasados.Width = 271;
            // 
            // tbLivros
            // 
            this.tbLivros.BackColor = System.Drawing.SystemColors.Window;
            this.tbLivros.Controls.Add(this.dgvLivros);
            this.tbLivros.Location = new System.Drawing.Point(4, 34);
            this.tbLivros.Name = "tbLivros";
            this.tbLivros.Padding = new System.Windows.Forms.Padding(3);
            this.tbLivros.Size = new System.Drawing.Size(749, 299);
            this.tbLivros.TabIndex = 0;
            this.tbLivros.Text = "Livros";
            // 
            // dgvLivros
            // 
            this.dgvLivros.AllowUserToAddRows = false;
            this.dgvLivros.AllowUserToDeleteRows = false;
            this.dgvLivros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLivros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEmprestimo,
            this.IdLivro,
            this.TituloLivro,
            this.IdLeitor,
            this.leitor,
            this.Devolvido,
            this.DiasAtraso});
            this.dgvLivros.Location = new System.Drawing.Point(4, 5);
            this.dgvLivros.Name = "dgvLivros";
            this.dgvLivros.ReadOnly = true;
            this.dgvLivros.RowHeadersWidth = 51;
            this.dgvLivros.Size = new System.Drawing.Size(740, 263);
            this.dgvLivros.TabIndex = 2;
            // 
            // IdEmprestimo
            // 
            this.IdEmprestimo.HeaderText = "IdEmprestimo";
            this.IdEmprestimo.MinimumWidth = 6;
            this.IdEmprestimo.Name = "IdEmprestimo";
            this.IdEmprestimo.ReadOnly = true;
            this.IdEmprestimo.Width = 172;
            // 
            // IdLivro
            // 
            this.IdLivro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IdLivro.HeaderText = "IdLivro";
            this.IdLivro.MinimumWidth = 6;
            this.IdLivro.Name = "IdLivro";
            this.IdLivro.ReadOnly = true;
            this.IdLivro.Width = 106;
            // 
            // TituloLivro
            // 
            this.TituloLivro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TituloLivro.HeaderText = "Livro";
            this.TituloLivro.MinimumWidth = 6;
            this.TituloLivro.Name = "TituloLivro";
            this.TituloLivro.ReadOnly = true;
            this.TituloLivro.Width = 88;
            // 
            // IdLeitor
            // 
            this.IdLeitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IdLeitor.HeaderText = "IdLeitor";
            this.IdLeitor.MinimumWidth = 6;
            this.IdLeitor.Name = "IdLeitor";
            this.IdLeitor.ReadOnly = true;
            this.IdLeitor.Width = 113;
            // 
            // leitor
            // 
            this.leitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.leitor.HeaderText = "Leitor";
            this.leitor.MinimumWidth = 6;
            this.leitor.Name = "leitor";
            this.leitor.ReadOnly = true;
            this.leitor.Width = 95;
            // 
            // Devolvido
            // 
            this.Devolvido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Devolvido.HeaderText = "Devolvido?";
            this.Devolvido.MinimumWidth = 6;
            this.Devolvido.Name = "Devolvido";
            this.Devolvido.ReadOnly = true;
            this.Devolvido.Width = 148;
            // 
            // DiasAtraso
            // 
            this.DiasAtraso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DiasAtraso.HeaderText = "Dias de Atraso";
            this.DiasAtraso.MinimumWidth = 6;
            this.DiasAtraso.Name = "DiasAtraso";
            this.DiasAtraso.ReadOnly = true;
            this.DiasAtraso.Width = 167;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbLivros);
            this.tabControl1.Controls.Add(this.tbLeitores);
            this.tabControl1.Location = new System.Drawing.Point(-1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 337);
            this.tabControl1.TabIndex = 1;
            // 
            // FrmRelatorios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(759, 338);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmRelatorios";
            this.Text = "Relatórios";
            this.tbLeitores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeitores)).EndInit();
            this.tbLivros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbLeitores;
        private System.Windows.Forms.DataGridView dgvLeitores;
        private System.Windows.Forms.TabPage tbLivros;
        private System.Windows.Forms.DataGridView dgvLivros;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeLeitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn LivrosEmprestados;
        private System.Windows.Forms.DataGridViewTextBoxColumn LivrosAtrasados;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmprestimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TituloLivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLeitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn leitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Devolvido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasAtraso;
    }
}