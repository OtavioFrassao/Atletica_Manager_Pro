namespace Atletica_Manager_Pro
{
    partial class Form1
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
            cadastroLabel = new ReaLTaiizor.Controls.FoxTextBox();
            SuspendLayout();
            // 
            // cadastroLabel
            // 
            cadastroLabel.BackColor = Color.Transparent;
            cadastroLabel.EnabledCalc = true;
            cadastroLabel.Font = new Font("Segoe UI", 25F);
            cadastroLabel.ForeColor = Color.Black;
            cadastroLabel.Location = new Point(293, 29);
            cadastroLabel.MaxLength = 32767;
            cadastroLabel.MultiLine = false;
            cadastroLabel.Name = "cadastroLabel";
            cadastroLabel.ReadOnly = false;
            cadastroLabel.Size = new Size(182, 43);
            cadastroLabel.TabIndex = 0;
            cadastroLabel.Text = "Cadastro";
            cadastroLabel.TextAlign = HorizontalAlignment.Left;
            cadastroLabel.UseSystemPasswordChar = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cadastroLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.FoxTextBox cadastroLabel;
    }
}
