namespace Atletica.Presentation.Views
{
    partial class FormListaEventos
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
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVisualizarLista = new System.Windows.Forms.Button();
            this.btnVisualizarCalendario = new System.Windows.Forms.Button();
            this.pnlCalendario = new System.Windows.Forms.Panel();
            this.btnMesAnterior = new System.Windows.Forms.Button();
            this.btnProximoMes = new System.Windows.Forms.Button();
            this.lblMesAno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.AllowUserToAddRows = false;
            this.dgvEventos.AllowUserToDeleteRows = false;
            this.dgvEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(12, 50);
            this.dgvEventos.MultiSelect = false;
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.RowHeadersWidth = 51;
            this.dgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos.Size = new System.Drawing.Size(860, 400);
            this.dgvEventos.TabIndex = 0;
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
            this.btnEditar.Location = new System.Drawing.Point(120, 465);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 35);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExcluir.Location = new System.Drawing.Point(228, 465);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 35);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFechar.Location = new System.Drawing.Point(772, 465);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(228, 25);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Agendamento de Eventos";
            // 
            // btnVisualizarLista
            // 
            this.btnVisualizarLista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVisualizarLista.Location = new System.Drawing.Point(650, 15);
            this.btnVisualizarLista.Name = "btnVisualizarLista";
            this.btnVisualizarLista.Size = new System.Drawing.Size(100, 30);
            this.btnVisualizarLista.TabIndex = 6;
            this.btnVisualizarLista.Text = "Lista";
            this.btnVisualizarLista.UseVisualStyleBackColor = true;
            // 
            // btnVisualizarCalendario
            // 
            this.btnVisualizarCalendario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVisualizarCalendario.Location = new System.Drawing.Point(760, 15);
            this.btnVisualizarCalendario.Name = "btnVisualizarCalendario";
            this.btnVisualizarCalendario.Size = new System.Drawing.Size(112, 30);
            this.btnVisualizarCalendario.TabIndex = 7;
            this.btnVisualizarCalendario.Text = "Calendario";
            this.btnVisualizarCalendario.UseVisualStyleBackColor = true;
            // 
            // pnlCalendario
            // 
            this.pnlCalendario.AutoScroll = true;
            this.pnlCalendario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalendario.Location = new System.Drawing.Point(12, 90);
            this.pnlCalendario.Name = "pnlCalendario";
            this.pnlCalendario.Size = new System.Drawing.Size(860, 360);
            this.pnlCalendario.TabIndex = 8;
            this.pnlCalendario.Visible = false;
            // 
            // btnMesAnterior
            // 
            this.btnMesAnterior.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMesAnterior.Location = new System.Drawing.Point(12, 50);
            this.btnMesAnterior.Name = "btnMesAnterior";
            this.btnMesAnterior.Size = new System.Drawing.Size(40, 30);
            this.btnMesAnterior.TabIndex = 9;
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
            this.btnProximoMes.TabIndex = 10;
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
            this.lblMesAno.TabIndex = 11;
            this.lblMesAno.Text = "Dezembro 2025";
            this.lblMesAno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMesAno.Visible = false;
            // 
            // FormListaEventos
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
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgvEventos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormListaEventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendamento de Eventos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.DataGridView dgvEventos;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnExcluir;
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
