using Atletica.Application.DTOs;
using Atletica.Application.Services;
using Atletica.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atletica.Presentation.Presenters
{
    public class CargoPresenter
    {
        private readonly FormListaCargos _view;
        private readonly IServiceProvider _serviceProvider;

        public CargoPresenter(FormListaCargos view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            // Conectar eventos
            _view.Load += View_Load;
            _view.btnNovo.Click += BtnNovo_Click;
            _view.btnEditar.Click += BtnEditar_Click;
            _view.btnExcluir.Click += BtnExcluir_Click;
            _view.btnFechar.Click += BtnFechar_Click;
        }

        private async void View_Load(object? sender, EventArgs e)
        {
            await CarregarCargosAsync();
        }

        private async Task CarregarCargosAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var cargoService = scope.ServiceProvider.GetRequiredService<CargoService>();
                var cargos = await cargoService.GetAllCargosAsync();
                _view.dgvCargos.DataSource = cargos.ToList();
                
                // Configurar colunas
                if (_view.dgvCargos.Columns.Count > 0)
                {
                    _view.dgvCargos.Columns["Id"].Visible = false;
                    _view.dgvCargos.Columns["Nome"].HeaderText = "Nome";
                    _view.dgvCargos.Columns["Descricao"].HeaderText = "Descrição";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cargos: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnNovo_Click(object? sender, EventArgs e)
        {
            var formCadastro = new FormCadastroCargo();
            var presenter = new CadastroCargoPresenter(formCadastro, _serviceProvider);
            
            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                await CarregarCargosAsync();
            }
        }

        private async void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (_view.dgvCargos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cargo para editar.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cargoId = Convert.ToInt32(_view.dgvCargos.SelectedRows[0].Cells["Id"].Value);
            
            using var scope = _serviceProvider.CreateScope();
            var cargoService = scope.ServiceProvider.GetRequiredService<CargoService>();
            var cargo = await cargoService.GetCargoByIdAsync(cargoId);

            if (cargo != null)
            {
                var formCadastro = new FormCadastroCargo();
                formCadastro.SetEditMode(cargo.Id, cargo.Nome, cargo.Descricao);
                var presenter = new CadastroCargoPresenter(formCadastro, _serviceProvider);
                
                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    await CarregarCargosAsync();
                }
            }
        }

        private async void BtnExcluir_Click(object? sender, EventArgs e)
        {
            if (_view.dgvCargos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cargo para excluir.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cargoId = Convert.ToInt32(_view.dgvCargos.SelectedRows[0].Cells["Id"].Value);
            var cargoNome = _view.dgvCargos.SelectedRows[0].Cells["Nome"].Value.ToString();

            var result = MessageBox.Show(
                $"Deseja realmente excluir o cargo '{cargoNome}'?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var cargoService = scope.ServiceProvider.GetRequiredService<CargoService>();
                    await cargoService.DeleteCargoAsync(cargoId);
                    MessageBox.Show("Cargo excluído com sucesso!", "Sucesso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CarregarCargosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir cargo: {ex.Message}", "Erro", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnFechar_Click(object? sender, EventArgs e)
        {
            _view.Close();
        }
    }

    public class CadastroCargoPresenter
    {
        private readonly FormCadastroCargo _view;
        private readonly IServiceProvider _serviceProvider;

        public CadastroCargoPresenter(FormCadastroCargo view, IServiceProvider serviceProvider)
        {
            _view = view;
            _serviceProvider = serviceProvider;

            _view.btnSalvar.Click += BtnSalvar_Click;
            _view.btnCancelar.Click += BtnCancelar_Click;
        }

        private async void BtnSalvar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.txtNome.Text))
                {
                    MessageBox.Show("O nome do cargo é obrigatório.", "Validação", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _view.txtNome.Focus();
                    return;
                }

                using var scope = _serviceProvider.CreateScope();
                var cargoService = scope.ServiceProvider.GetRequiredService<CargoService>();

                if (_view.CargoId.HasValue)
                {
                    // Edição
                    var updateDto = new UpdateCargoDto
                    {
                        Id = _view.CargoId.Value,
                        Nome = _view.txtNome.Text.Trim(),
                        Descricao = _view.txtDescricao.Text.Trim()
                    };

                    await cargoService.UpdateCargoAsync(updateDto);
                    MessageBox.Show("Cargo atualizado com sucesso!", "Sucesso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Criação
                    var createDto = new CreateCargoDto
                    {
                        Nome = _view.txtNome.Text.Trim(),
                        Descricao = _view.txtDescricao.Text.Trim()
                    };

                    await cargoService.CreateCargoAsync(createDto);
                    MessageBox.Show("Cargo cadastrado com sucesso!", "Sucesso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _view.DialogResult = DialogResult.OK;
                _view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cargo: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            _view.DialogResult = DialogResult.Cancel;
            _view.Close();
        }
    }
}
