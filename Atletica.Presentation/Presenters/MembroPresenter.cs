using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atletica.Application.DTOs;
using Atletica.Application.Services;
using Atletica.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Atletica.Presentation.Presenters
{
    public class MembroPresenter
    {
        private readonly FormListaMembros _view;
        private readonly IServiceProvider _serviceProvider;

        public MembroPresenter(FormListaMembros view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.Load += async (s, e) => await CarregarMembrosAsync();
            _view.btnNovo.Click += BtnNovo_Click;
            _view.btnEditar.Click += async (s, e) => await BtnEditar_ClickAsync();
            _view.btnExcluir.Click += async (s, e) => await BtnExcluir_ClickAsync();
            _view.btnFechar.Click += (s, e) => _view.Close();
        }

        private async Task CarregarMembrosAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var membroService = scope.ServiceProvider.GetRequiredService<MembroService>();

                var membros = await membroService.GetAllMembrosAsync();
                _view.dgvMembros.DataSource = membros.ToList();

                if (_view.dgvMembros.Columns.Contains("CargoId"))
                    _view.dgvMembros.Columns["CargoId"].Visible = false;
                
                if (_view.dgvMembros.Columns.Contains("Id"))
                    _view.dgvMembros.Columns["Id"].Visible = false;
                
                // Configurar ordem e cabeçalhos
                if (_view.dgvMembros.Columns.Contains("Nome"))
                {
                    _view.dgvMembros.Columns["Nome"].DisplayIndex = 0;
                    _view.dgvMembros.Columns["Nome"].HeaderText = "Nome";
                }
                if (_view.dgvMembros.Columns.Contains("Curso"))
                {
                    _view.dgvMembros.Columns["Curso"].DisplayIndex = 1;
                    _view.dgvMembros.Columns["Curso"].HeaderText = "Curso";
                }
                if (_view.dgvMembros.Columns.Contains("Turma"))
                {
                    _view.dgvMembros.Columns["Turma"].DisplayIndex = 2;
                    _view.dgvMembros.Columns["Turma"].HeaderText = "Turma";
                    _view.dgvMembros.Columns["Turma"].Width = 60;
                }
                if (_view.dgvMembros.Columns.Contains("Matricula"))
                {
                    _view.dgvMembros.Columns["Matricula"].DisplayIndex = 3;
                    _view.dgvMembros.Columns["Matricula"].HeaderText = "Matrícula";
                    _view.dgvMembros.Columns["Matricula"].Width = 100;
                }
                if (_view.dgvMembros.Columns.Contains("Contato"))
                {
                    _view.dgvMembros.Columns["Contato"].DisplayIndex = 4;
                    _view.dgvMembros.Columns["Contato"].HeaderText = "Contato";
                    _view.dgvMembros.Columns["Contato"].Width = 120;
                }
                if (_view.dgvMembros.Columns.Contains("DataEntrada"))
                {
                    _view.dgvMembros.Columns["DataEntrada"].DisplayIndex = 5;
                    _view.dgvMembros.Columns["DataEntrada"].HeaderText = "Data Entrada";
                    _view.dgvMembros.Columns["DataEntrada"].Width = 100;
                }
                if (_view.dgvMembros.Columns.Contains("CargoNome"))
                {
                    _view.dgvMembros.Columns["CargoNome"].DisplayIndex = 6;
                    _view.dgvMembros.Columns["CargoNome"].HeaderText = "Cargo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar membros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnNovo_Click(object? sender, EventArgs e)
        {
            var formCadastro = new FormCadastroMembro();
            await CarregarCargosAsync(formCadastro);
            new CadastroMembroPresenter(formCadastro, _serviceProvider);

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                await CarregarMembrosAsync();
            }
        }

        private async Task BtnEditar_ClickAsync()
        {
            if (_view.dgvMembros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um membro para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var membroDto = (MembroDto)_view.dgvMembros.SelectedRows[0].DataBoundItem;
            var formCadastro = new FormCadastroMembro { MembroId = membroDto.Id };

            await CarregarCargosAsync(formCadastro);
            formCadastro.SetEditMode(membroDto.Nome, membroDto.Curso, membroDto.Turma, membroDto.Matricula,
                membroDto.Contato, membroDto.DataEntrada, membroDto.CargoId);

            new CadastroMembroPresenter(formCadastro, _serviceProvider);

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                await CarregarMembrosAsync();
            }
        }

        private async Task BtnExcluir_ClickAsync()
        {
            if (_view.dgvMembros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um membro para excluir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var membroDto = (MembroDto)_view.dgvMembros.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show($"Deseja realmente excluir o membro '{membroDto.Nome}'?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var membroService = scope.ServiceProvider.GetRequiredService<MembroService>();
                    await membroService.DeleteMembroAsync(membroDto.Id);

                    MessageBox.Show("Membro excluído com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await CarregarMembrosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir membro: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CarregarCargosAsync(FormCadastroMembro formCadastro)
        {
            using var scope = _serviceProvider.CreateScope();
            var cargoService = scope.ServiceProvider.GetRequiredService<CargoService>();
            var cargos = await cargoService.GetAllCargosAsync();

            formCadastro.cmbCargo.DataSource = cargos.ToList();
            formCadastro.cmbCargo.DisplayMember = "Nome";
            formCadastro.cmbCargo.ValueMember = "Id";
        }
    }

    public class CadastroMembroPresenter
    {
        private readonly FormCadastroMembro _view;
        private readonly IServiceProvider _serviceProvider;

        public CadastroMembroPresenter(FormCadastroMembro view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.btnSalvar.Click += async (s, e) => await BtnSalvar_ClickAsync();
            _view.btnCancelar.Click += (s, e) => _view.Close();
        }

        private async Task BtnSalvar_ClickAsync()
        {
            if (string.IsNullOrWhiteSpace(_view.txtNome.Text))
            {
                MessageBox.Show("O nome é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.txtCurso.Text))
            {
                MessageBox.Show("O curso é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.txtCurso.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.txtMatricula.Text))
            {
                MessageBox.Show("A matrícula é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.txtMatricula.Focus();
                return;
            }

            if (_view.cmbCargo.SelectedValue == null)
            {
                MessageBox.Show("Selecione um cargo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.cmbCargo.Focus();
                return;
            }

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var membroService = scope.ServiceProvider.GetRequiredService<MembroService>();

                if (_view.MembroId.HasValue)
                {
                    var updateDto = new UpdateMembroDto
                    {
                        Id = _view.MembroId.Value,
                        Nome = _view.txtNome.Text.Trim(),
                        Curso = _view.txtCurso.Text.Trim(),
                        Turma = _view.txtTurma.Text.Trim(),
                        Matricula = _view.txtMatricula.Text.Trim(),
                        Contato = _view.txtContato.Text.Trim(),
                        DataEntrada = _view.dtpDataEntrada.Value,
                        CargoId = (int)_view.cmbCargo.SelectedValue
                    };

                    await membroService.UpdateMembroAsync(updateDto);
                    MessageBox.Show("Membro atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var createDto = new CreateMembroDto
                    {
                        Nome = _view.txtNome.Text.Trim(),
                        Turma = _view.txtTurma.Text.Trim(),
                        Curso = _view.txtCurso.Text.Trim(),
                        Matricula = _view.txtMatricula.Text.Trim(),
                        Contato = _view.txtContato.Text.Trim(),
                        DataEntrada = _view.dtpDataEntrada.Value,
                        CargoId = (int)_view.cmbCargo.SelectedValue
                    };

                    await membroService.CreateMembroAsync(createDto);
                    MessageBox.Show("Membro cadastrado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _view.DialogResult = DialogResult.OK;
                _view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar membro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
