using System;
using System.Windows.Forms;

namespace Atletica.Presentation.Views
{
    public partial class FormCadastroCargo : Form
    {
        public int? CargoId { get; set; }

        public FormCadastroCargo()
        {
            InitializeComponent();
        }

        public void SetEditMode(int id, string nome, string descricao)
        {
            CargoId = id;
            txtNome.Text = nome;
            txtDescricao.Text = descricao;
            this.Text = "Editar Cargo";
            lblTitulo.Text = "Editar Cargo";
        }
    }
}
