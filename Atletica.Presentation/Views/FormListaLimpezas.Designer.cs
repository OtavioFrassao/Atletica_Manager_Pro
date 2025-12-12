namespace Atletica.Presentation.Views
{
    partial class FormListaLimpezas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvLimpezas = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnMarcarConcluida = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVisualizarLista = new System.Windows.Forms.Button();
            this.btnVisualizarCalendario = new System.Windows.Forms.Button();
            this.pnlCalendario = new System.Windows.Forms.Panel();
            this.btnMesAnterior = new System.Windows.Forms.Button();
            this.btnProximoMes = new System.Windows.Forms.Button();
            this.lblMesAno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimpezas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLimpezas
            // 
            this.dgvLimpezas.AllowUserToAddRows = false;
            this.dgvLimpezas.AllowUserToDeleteRows = false;
            this.dgvLimpezas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLimpezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLimpezas.Location = new System.Drawing.Point(12, 50);
            this.dgvLimpezas.MultiSelect = false;
            this.dgvLimpezas.Name = "dgvLimpezas";
            this.dgvLimpezas.ReadOnly = true;
            this.dgvLimpezas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLimpezas.Size = new System.Drawing.Size(860, 400);
            this.dgvLimpezas.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNovo.Location = new System.Drawing.Point(12, 465);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 35);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEditar.Location = new System.Drawing.Point(125, 465);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 35);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExcluir.Location = new System.Drawing.Point(238, 465);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 35);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnMarcarConcluida
            // 
            this.btnMarcarConcluida.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMarcarConcluida.Location = new System.Drawing.Point(351, 465);
            this.btnMarcarConcluida.Name = "btnMarcarConcluida";
            this.btnMarcarConcluida.Size = new System.Drawing.Size(150, 35);
            this.btnMarcarConcluida.TabIndex = 4;
            this.btnMarcarConcluida.Text = "Marcar Concluída";
            this.btnMarcarConcluida.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFechar.Location = new System.Drawing.Point(772, 465);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(253, 25);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Cronograma de Limpezas";
            // 
            // btnVisualizarLista
            // 
            this.btnVisualizarLista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVisualizarLista.Location = new System.Drawing.Point(650, 15);
            this.btnVisualizarLista.Name = "btnVisualizarLista";
            this.btnVisualizarLista.Size = new System.Drawing.Size(100, 30);
            this.btnVisualizarLista.TabIndex = 7;
            this.btnVisualizarLista.Text = "📋 Lista";
            this.btnVisualizarLista.UseVisualStyleBackColor = true;
            // 
            // btnVisualizarCalendario
            // 
            this.btnVisualizarCalendario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVisualizarCalendario.Location = new System.Drawing.Point(760, 15);
            this.btnVisualizarCalendario.Name = "btnVisualizarCalendario";
            this.btnVisualizarCalendario.Size = new System.Drawing.Size(112, 30);
            this.btnVisualizarCalendario.TabIndex = 8;
            this.btnVisualizarCalendario.Text = "📅 Calendário";
            this.btnVisualizarCalendario.UseVisualStyleBackColor = true;
            // 
            // pnlCalendario
            // 
            this.pnlCalendario.AutoScroll = true;
            this.pnlCalendario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalendario.Location = new System.Drawing.Point(12, 90);
            this.pnlCalendario.Name = "pnlCalendario";
            this.pnlCalendario.Size = new System.Drawing.Size(860, 360);
            this.pnlCalendario.TabIndex = 9;
            this.pnlCalendario.Visible = false;
            // 
            // btnMesAnterior
            // 
            this.btnMesAnterior.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMesAnterior.Location = new System.Drawing.Point(12, 50);
            this.btnMesAnterior.Name = "btnMesAnterior";
            this.btnMesAnterior.Size = new System.Drawing.Size(40, 30);
            this.btnMesAnterior.TabIndex = 10;
            this.btnMesAnterior.Text = "◄";
            this.btnMesAnterior.UseVisualStyleBackColor = true;
            this.btnMesAnterior.Visible = false;
            // 
            // btnProximoMes
            // 
            this.btnProximoMes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProximoMes.Location = new System.Drawing.Point(832, 50);
            this.btnProximoMes.Name = "btnProximoMes";
            this.btnProximoMes.Size = new System.Drawing.Size(40, 30);
            this.btnProximoMes.TabIndex = 11;
            this.btnProximoMes.Text = "►";
            this.btnProximoMes.UseVisualStyleBackColor = true;
            this.btnProximoMes.Visible = false;
            // 
            // lblMesAno
            // 
            this.lblMesAno.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMesAno.Location = new System.Drawing.Point(60, 50);
            this.lblMesAno.Name = "lblMesAno";
            this.lblMesAno.Size = new System.Drawing.Size(760, 30);
            this.lblMesAno.TabIndex = 12;
            this.lblMesAno.Text = "Dezembro 2025";
            this.lblMesAno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMesAno.Visible = false;
            // 
            // FormListaLimpezas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.lblMesAno);
            this.Controls.Add(this.btnProximoMes);
            this.Controls.Add(this.btnMesAnterior);
            this.Controls.Add(this.pnlCalendario);
            this.Controls.Add(this.btnVisualizarCalendario);
            this.Controls.Add(this.btnVisualizarLista);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnMarcarConcluida);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgvLimpezas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormListaLimpezas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cronograma de Limpezas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimpezas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.DataGridView dgvLimpezas;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnExcluir;
        public System.Windows.Forms.Button btnMarcarConcluida;
        public System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Button btnVisualizarLista;
        public System.Windows.Forms.Button btnVisualizarCalendario;
        public System.Windows.Forms.Panel pnlCalendario;
        public System.Windows.Forms.Button btnMesAnterior;
        public System.Windows.Forms.Button btnProximoMes;
        public System.Windows.Forms.Label lblMesAno;
    }
}
