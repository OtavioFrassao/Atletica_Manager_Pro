using Atletica.Application.DTOs;
using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atletica.Application.Services
{
    public class TarefaLimpezaService
    {
        private readonly ITarefaLimpezaRepository _tarefaRepository;
        private readonly IMembroRepository _membroRepository;

        public TarefaLimpezaService(ITarefaLimpezaRepository tarefaRepository, IMembroRepository membroRepository)
        {
            _tarefaRepository = tarefaRepository;
            _membroRepository = membroRepository;
        }

        public async Task<IEnumerable<TarefaLimpezaDto>> GetAllTarefasAsync()
        {
            var tarefas = await _tarefaRepository.GetAllAsync();
            return tarefas.Select(t => MapToDto(t));
        }

        public async Task<TarefaLimpezaDto> GetTarefaByIdAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
                return null;

            return MapToDto(tarefa);
        }

        public async Task<IEnumerable<TarefaLimpezaDto>> GetTarefasPendentesAsync()
        {
            var tarefas = await _tarefaRepository.GetPendentesAsync();
            return tarefas.Select(t => MapToDto(t));
        }

        public async Task<IEnumerable<TarefaLimpezaDto>> GetTarefasByMembroAsync(int membroId)
        {
            var tarefas = await _tarefaRepository.GetByMembroIdAsync(membroId);
            return tarefas.Select(t => MapToDto(t));
        }

        public async Task<IEnumerable<TarefaLimpezaDto>> GetTarefasByDataAsync(DateTime data)
        {
            var tarefas = await _tarefaRepository.GetByDataAsync(data);
            return tarefas.Select(t => MapToDto(t));
        }

        public async Task<TarefaLimpezaDto> CreateTarefaAsync(CreateTarefaLimpezaDto createDto)
        {
            // Valida se o membro existe
            var membroExists = await _membroRepository.ExistsAsync(createDto.MembroResponsavelId);
            if (!membroExists)
                throw new InvalidOperationException("O membro responsável especificado não existe.");

            // Verifica se já existe outra tarefa na mesma data (regra de negócio opcional)
            var existeTarefa = await _tarefaRepository.ExisteTarefaNaDataAsync(createDto.Data);
            if (existeTarefa)
                throw new InvalidOperationException("Já existe uma tarefa agendada para esta data.");

            var tarefa = new TarefaLimpeza(
                createDto.Data,
                createDto.Descricao,
                createDto.MembroResponsavelId
            );

            var createdTarefa = await _tarefaRepository.AddAsync(tarefa);
            
            // Recarrega para obter o membro
            var tarefaCompleta = await _tarefaRepository.GetByIdAsync(createdTarefa.Id);

            return MapToDto(tarefaCompleta);
        }

        public async Task<bool> UpdateTarefaAsync(UpdateTarefaLimpezaDto updateDto)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(updateDto.Id);
            if (tarefa == null)
                return false;

            // Valida se o membro existe
            var membroExists = await _membroRepository.ExistsAsync(updateDto.MembroResponsavelId);
            if (!membroExists)
                throw new InvalidOperationException("O membro responsável especificado não existe.");

            // Verifica se já existe outra tarefa na mesma data (excluindo a atual)
            var existeTarefa = await _tarefaRepository.ExisteTarefaNaDataAsync(updateDto.Data, updateDto.Id);
            if (existeTarefa)
                throw new InvalidOperationException("Já existe uma tarefa agendada para esta data.");

            tarefa.AtualizarDados(
                updateDto.Data,
                updateDto.Descricao,
                updateDto.MembroResponsavelId,
                updateDto.Concluido
            );

            await _tarefaRepository.UpdateAsync(tarefa);
            return true;
        }

        public async Task<bool> MarcarComoConcluidoAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
                return false;

            tarefa.MarcarComoConcluido();
            await _tarefaRepository.UpdateAsync(tarefa);
            return true;
        }

        public async Task<bool> MarcarComoPendenteAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
                return false;

            tarefa.MarcarComoPendente();
            await _tarefaRepository.UpdateAsync(tarefa);
            return true;
        }

        public async Task<bool> DeleteTarefaAsync(int id)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
                return false;

            await _tarefaRepository.DeleteAsync(id);
            return true;
        }

        private TarefaLimpezaDto MapToDto(TarefaLimpeza tarefa)
        {
            return new TarefaLimpezaDto
            {
                Id = tarefa.Id,
                Data = tarefa.Data,
                Descricao = tarefa.Descricao,
                Concluido = tarefa.Concluido,
                MembroResponsavelId = tarefa.MembroResponsavelId,
                MembroResponsavelNome = tarefa.MembroResponsavel?.Nome ?? "",
                MembroResponsavelCargo = tarefa.MembroResponsavel?.Cargo?.Nome ?? ""
            };
        }
    }
}
