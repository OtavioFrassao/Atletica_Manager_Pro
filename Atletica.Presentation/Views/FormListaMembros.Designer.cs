namespace Atletica.Presentation.Views
{
    partial class FormListaMembros
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
            this.dgvMembros = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembros
            // 
            this.dgvMembros.AllowUserToAddRows = false;
            this.dgvMembros.AllowUserToDeleteRows = false;
            this.dgvMembros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembros.Location = new System.Drawing.Point(12, 50);
            this.dgvMembros.MultiSelect = false;
            this.dgvMembros.Name = "dgvMembros";
            this.dgvMembros.ReadOnly = true;
            this.dgvMembros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembros.Size = new System.Drawing.Size(860, 400);
            this.dgvMembros.TabIndex = 0;
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
            this.lblTitulo.Size = new System.Drawing.Size(203, 25);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Listagem de Membros";
            // 
            // FormListaMembros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgvMembros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormListaMembros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Membros";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.DataGridView dgvMembros;
        public System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnExcluir;
        public System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
