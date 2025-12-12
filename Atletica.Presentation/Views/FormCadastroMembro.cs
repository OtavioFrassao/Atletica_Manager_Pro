using System;
using System.Windows.Forms;

namespace Atletica.Presentation.Views
{
    public partial class FormCadastroMembro : Form
    {
        public int? MembroId { get; set; }

        public FormCadastroMembro()
        {
            InitializeComponent();
            dtpDataEntrada.Value = DateTime.Now;
        }

        public void SetEditMode(string nome, string curso, string turma, string matricula, string contato, DateTime dataEntrada, int cargoId)
        {
            lblTitulo.Text = "Editar Membro";
            txtNome.Text = nome;
            txtCurso.Text = curso;
            txtTurma.Text = turma;
            txtMatricula.Text = matricula;
            txtContato.Text = contato;
            dtpDataEntrada.Value = dataEntrada;
            cmbCargo.SelectedValue = cargoId;
        }
    }
}
